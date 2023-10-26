import { BookDataBaseService, BookInfo } from "@externals/simple-db";
import { HashGenerator } from "../utils/HashGenerator";
import { BaseSystem } from "./BaseSystem";

export class DataBaseSystem extends BaseSystem {
    // 做資料庫互動的服務
    db: BookDataBaseService = null;

    // 產生 ISBN
    hashGenerator: HashGenerator = null;

    // 連接 DB 時最大的嘗試重複連線的次數
    public static retryTimes = 5;

    constructor(db?: BookDataBaseService, hashg?: HashGenerator) {
        super("Data Base Update");
        this.db = db || new BookDataBaseService();
        this.hashGenerator = hashg || new HashGenerator();
    }

    // 用於與資料庫做連線
    // 如果連線失敗則每個 0.5s 重複嘗試
    // 如果超過 5 次連續無法連線就直接產生一個錯誤
    // 如果連線成功，就先將 Book 的資料讀入
    public async connectDB() {
        let count = 0;
        while(true) {
            try {
                const res = await this.db.setUp("http://localhost", 4000);
                this.items = await this.db.getBooks();
                return res;
            } 
            catch (e) {
                await this.retryDelay();
                if (++count >= DataBaseSystem.retryTimes) {
                    throw new Error("Cannnot connect to DB");
                };
            }
        }
    }

    // 用於 Delay
    private async retryDelay() {
        return new Promise((resolve) => setTimeout(resolve, 500));
    }

    // 新增新的書
    // Title 與 Author 都必須有值，並且會呼叫 HashGenerator 來產生隨機的 ISBN
    // 如果沒有值則會產生一個錯誤
    public async addBook(title: string, author: string) {
        try {
            if (title && author) {
                // 隨機產生一個 ISBN
                const bookISBN = this.hashGenerator.simpleISBN("000-00-00000-00-0");
                await this.db.addBook({
                    ISBN: bookISBN,
                    title: title,
                    author: author,
                });
            }
            else {
                throw new Error("Title or Author cannot be null");
            }
        }
        catch(e) {
            throw new Error("Add book failed");
        }
    }

    public async deleteBook(bookISBN: string) {
        try {
            if (bookISBN) {
                await this.db.deleteBook(bookISBN);
            }
            else {
                throw new Error("ISBN cannot be empty");
            }
        }
        catch(e) {
            throw new Error("Delete book failed");
        }
    }

    public async process(prevItems: BookInfo[]) {
        try {
            this.items = await this.db.getBooks();
        }
        catch(e) {
            /** Do nothing */
        }
    }
}
