import { BookInfo } from "@externals/simple-db";

import { DisplayRangeSystem } from "./DisplayRangeSystem";
import { WordPuritySystem } from "./WordPuritySystem";
import { FilterSystem } from "./FilterSystem";
import { BaseSystem } from "./BaseSystem";
import { SortSystem } from "./SortSystem";

import { DataBaseSystem } from "./DataBaseSystem";
import { WordPurityService } from "@externals/word-purity";

export enum UpdateType {
    Data,
    Purity,
    Filter,
    Sort,
    Range,
}

export class ListViewerManager {
    private processors: BaseSystem[];

    private updateMsg: string[] = [];

    constructor() {}

    /**
     * 初始化所有的 System \
     * 並且 System 的順序也在這邊做調整 */
    public async setUp() {
        const db = new DataBaseSystem();
        await db.connectDB();
        this.processors = [
            db,
            new WordPuritySystem(new WordPurityService()),
            new FilterSystem(),
            new SortSystem(),
            new DisplayRangeSystem(),
        ]
    }

    /**
     * 利用簡單的 For 迴圈去更新 System \
     * 而 UpdateType 是把 Enum 轉換成 Number 這樣就可以直接有起始更新點
     * @param updateType 起始更新點 */
    public async updateResult(updateType: UpdateType) {
        this.updateMsg = [];
        for (let i = updateType; i < this.processors.length; i += 1) {
            const preItems = (i - 1) < 0 ? [] : this.processors[i - 1].getItems();
            await this.processors[i].process(preItems);
            // 把系統中的 Update Message 存入進更新 Msg
            this.updateMsg.push(this.processors[i].getUpdateMessage());
        }
    }

    public getUpdateMessage() {
        return this.updateMsg;
    }

    public getProcessor<T extends BaseSystem>(type: UpdateType): T {
        return this.processors[type] as T;
    }

    /**
     * 取出 System 中的最後一個 BookInfo Item \
     * 做為顯示用途
     * @returns 格式化後的物件 */
    public generateDisplayItemRow() {
        return this.processors.at(-1).getItems().map<BookInfo>((val, index) => ({
            ISBN:   val.ISBN,
            title:  val.title,
            author: val.author,
        }));
    }
}