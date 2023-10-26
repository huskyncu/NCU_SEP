import { BookInfo } from "@externals/simple-db";
import { BaseSystem } from "./BaseSystem";

export class DisplayRangeSystem extends BaseSystem {
    protected endRange = 10;

    protected startRange = 1;

    constructor() {
        super("Display Range Update");
    }

    /**
     * 轉換用的 Method
     * @param val Number 或 String 值
     * @returns 非負 Integer */
    private convertNum(val: number | string) {
        if (typeof val === 'string') {
            const newVal = Number.parseInt(val, 10);
            if (Number.isNaN(newVal)) {
                throw new Error("Invalid String Input");
            }
            return newVal;
        }
        else if (Number.isInteger(val) === false) {
            throw new Error("Invalid Float Input");
        }
        else if (val <= 0) {
            throw new Error("Cannot be less than 0");
        }
        return val;
    }

    /**
     * 可同時支援 Number 與 String 的輸入 \
     * 然後可以將此值做轉換以及驗證
     * @param startRange 開始的範圍
     * @param endRange 結束的範圍 */
    public setRange(startRange: number | string, endRange?: number | string) {
        const sRange = this.convertNum(startRange);
        const eRange = this.convertNum(endRange);
        if (eRange < sRange) {
            throw new Error("End Range cannot less than Start Range");
        }
        this.startRange = sRange;
        this.endRange = eRange;
    }
    
    public async process(prevItems: BookInfo[]) {
        this.items = prevItems.slice(this.startRange - 1, this.endRange);
    }

    public getStartRange() {
        return this.startRange;
    }

    public getEndRange() {
        return this.endRange;
    }
}
