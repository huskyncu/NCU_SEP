
export class HashGenerator {
    constructor() {}

    /**
     * 產生只包含 `A-Z` 隨機字串
     * @param charaterNum 隨機字串的長度 */
    public g(charaterNum: number) {
        if (charaterNum <= 0) {
            throw new Error("Hash number can't less than 0");
        }
        let str = "";
        for (let i = 0; i < charaterNum; i += 1) {
            str += String.fromCharCode((Math.random() * 26) + 65);
        }
        return str;
    }

    /**
     * 將輸入的字串轉換成 ISBN \
     * 並且會將所有除了 `-` 字元都轉換成隨機 `0-9` 數字 \
     * 例如：
     *   - `00-00` => `12-32`
     *   - `000-0-00--` => `123-4-56--`
     * @param pattern 要產生的 Pattern
     * @returns 只包含 `0-9` 與 `-` 的字串 */
    public simpleISBN(pattern: string) {
        let res = "";
        for (let i = 0; i < pattern.length; i += 1) {
            const patternCh = pattern.charAt(i);
            if (patternCh === '-') {
                res += patternCh
            }
            else {
                res += String.fromCharCode((Math.random() * 10) + 48);
            }
        }
        return res;
    }
}
