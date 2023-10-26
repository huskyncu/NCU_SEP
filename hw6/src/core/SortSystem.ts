import { BookInfo } from "@externals/simple-db";
import { BaseSystem } from "./BaseSystem";

export class SortSystem extends BaseSystem {
    public static ASC = "ASC";

    public static DESC = "DESC";

    private sortType = "ASC";

    constructor() {
        super("Sort Update");
    }

    /**
     * 設定 Sort Type \
     * ASC 與 DESC 兩種 */
    public setSortType(sortType: string) {
        switch (sortType) {
            case SortSystem.ASC:
                break;
            case SortSystem.DESC:
                break;
            default:
                throw new Error("It must be ASC or DESC");
        }
        this.sortType = sortType;
    }

    public getSortType() {
        return this.sortType;
    }
    public async process(prevItems: BookInfo[]) {
        if (this.sortType === SortSystem.ASC) {
            this.items = prevItems.sort((a, b) => a.title.localeCompare(b.title));
        }
        else {
            this.items = prevItems.sort((a, b) => b.title.localeCompare(a.title));
        }
    }
}
