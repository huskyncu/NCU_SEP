
export class InputNegativeError extends Error {
    constructor() {
        super("input a or b is negative value");
        Object.setPrototypeOf(this, InputNegativeError.prototype);
    }
}

export class InputNonIntegerError extends Error {
    constructor() {
        super("input a or b is non integer value");
        Object.setPrototypeOf(this, InputNonIntegerError.prototype);
    }
}

export class ErrorCatchExample {

    constructor() {}
    
    /**
     * 當 A 與 B 都為正數，並且非浮點數時做相加 \
     * 其餘不符合 A 與 B 的規則則拋出錯誤 */
    public positiveIntegerSum(a: number, b: number) {
        if (a < 0 || b < 0) {
            throw new InputNegativeError()
        }
        if (Number.isInteger(a) && Number.isInteger(b)) {
            return a + b
        }
        throw new InputNonIntegerError()
    }
}