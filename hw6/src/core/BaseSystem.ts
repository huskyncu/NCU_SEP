import { BookInfo } from "@externals/simple-db";

export abstract class BaseSystem {
    protected items: BookInfo[] = [];

    protected updateMessage: string;

    constructor(updateMessage: string) {
        this.updateMessage = updateMessage;
    }

    public abstract process(prevItems: BookInfo[]): void;

    public getItems() {
        return this.items;
    }

    public getUpdateMessage() {
        return this.updateMessage;
    }
}
