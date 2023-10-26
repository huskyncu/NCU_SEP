import { BookInfo } from "@externals/simple-db";
import { BaseSystem } from "./BaseSystem";

export class FilterSystem extends BaseSystem {
    private filterWord: string = "";
    private ignoreCase: boolean = false;
    constructor() {
        super("Filter Update");
    }

    public setFilterWord(filterWord: string) {
        this.filterWord = filterWord;
    }

    public getFilterWord() {
        return this.filterWord;
    }

    public setIgnoreCase(ignoreCase: boolean) {
        this.ignoreCase = ignoreCase;
    }

    public isIgnoreCase() {
        return this.ignoreCase
    }

    public async process(prevItems: BookInfo[]) {
        const regex = new RegExp(this.filterWord, this.ignoreCase ? 'i' : '');
        this.items = prevItems.filter((val) => regex.test(val.title));
    }
}

