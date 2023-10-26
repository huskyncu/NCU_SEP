import { ErrorCatchExample, InputNegativeError, InputNonIntegerError } from "./ErrorCatchExample";


describe("ErrorCatchExample class", () => {

    describe("positiveIntegerSum function", () => {

        // 一般使用
        test("Should return sum of two integer", () => {
            // Arrange
            const errorExample = new ErrorCatchExample();

            // Act
            const result = errorExample.positiveIntegerSum(1, 2);

            // Assert
            expect(result).toEqual(3)
        });

        // 當 A 或 B 為負數時要拋出 (InputNegativeError) 錯誤
        test("Should throw InputNegativeError when input number less than 0", () => {
            // Arrange
            const errorExample = new ErrorCatchExample();

            // Act
            // Explanation:
            // 利用 const <函式變數> = () => <執行會發生例外的 Function>
            // 這樣所拋出的錯誤會被 <函式變數> 給接收進而進一步驗證
            const fn = () => errorExample.positiveIntegerSum(-1, 2);

            // Assert
            expect(fn).toThrow(InputNegativeError)
        });

        // 當 A 或 B 為為浮點數時要拋出 (InputNonIntegerError) 錯誤
        test("Should throw InputNegativeError when input number less than 0", () => {
            // Arrange
            const errorExample = new ErrorCatchExample();

            // Act
            const fn = () => errorExample.positiveIntegerSum(5.5, 2);

            // Assert
            expect(fn).toThrow(InputNonIntegerError)
        });
    });
});