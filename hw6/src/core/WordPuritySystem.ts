import { BookInfo } from "@externals/simple-db";
import { WordPurityService } from "@externals/word-purity";

import { BaseSystem } from "./BaseSystem";

export class WordPuritySystem extends BaseSystem {
    // 用於將敏感文字過濾掉的服務
    protected domPurity: WordPurityService;

    protected disable: boolean;

    constructor(domPurity: WordPurityService) {
        super("Dom Purity Update");
        this.domPurity = domPurity;
        // 添加敏感文字
        this.domPurity.addWord([
            "Copperfield",
            "Wonderland"
        ]);
    }

    /**
     * 是否要關閉此功能 */
    public setDisablePurity(flag: boolean) {
        this.disable = flag;
    }

    public isDisablePurity() {
        return this.disable;
    }

    /**
     * 對每個 BookInfo 中的 Title 做處理 */
    private purityItems(prevItems: BookInfo[]) {
        return prevItems.map<BookInfo>((val) => {
            return {
                ...val,
                title: this.domPurity.purity(val.title),
            };
        });
    }

    public async process(prevItems: BookInfo[]) {
        this.items = this.disable ? prevItems : this.purityItems(prevItems);
    }
}