import { BookInfo } from "./interface";
export declare class BookDataBaseService {
    private bookMap;
    constructor();
    setUp(url: string, port: number): Promise<string>;
    addBook(book: BookInfo): Promise<string>;
    deleteBook(bookISBN: string): Promise<string>;
    getBooks(): Promise<BookInfo[]>;
}
//# sourceMappingURL=service.d.ts.map