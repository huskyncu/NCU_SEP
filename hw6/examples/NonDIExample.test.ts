import { NonDIExampleClock } from "./NonDIExample";
import { GearMechanism } from "./GearMechanism";

/* 將整個模組都 Auto-Mock 掉
 * 這樣代表再測試的時候 GearMechanism 已經是都被 Mock 了
 * 你可以試著把這行註解掉
 * 會發現 `expect(GearMechanism.prototype.reset).toBeCalledTimes(1)` 不會過了 */
jest.mock('./GearMechanism');


// 最基本方法
describe("Clock class (Non-Dependency Injection)", () => {

    beforeEach(() => {
        /* 因為無法直接對 new 出的 GearMechanism 物件直接做存取
         * 所以直接採用 Global 的方式做呼叫的計算
         * 但是因為是 Global 所以在每次測試之前都要先復原上個測試的結果
         * 
         * 假如註解掉這行:
         * 會發現 Test 不會過
         * 因為 `expect(GearMechanism).toBeCalledTimes(1)` 這行是測試 GearMechanism 的 Constructor 有被呼叫
         * 但是每個 Test 中都有呼叫，所以最後兩個 Testcase 應該 expect 會是 2 與 3 */
        jest.resetAllMocks();
    })

    // 最簡單的例子
    // 測試當 clock 呼叫 reset method 時，GearMechanism 的 reset method 真的有被呼叫
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const clock = new NonDIExampleClock("Test Clock");

        // Act
        clock.reset();

        // Assert
        expect(GearMechanism).toBeCalledTimes(1);  // 驗證 GearMechanism constructor 有被呼叫 1 次
        expect(GearMechanism.prototype.reset).toBeCalledTimes(1); // 驗證 GearMechanism 的 reset method 有被呼叫 1 次
    });

    
    // 當 Mock 的物件需要自訂義 Function 要回傳的值時 `mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);`
    // 測試當 clock 呼叫 getTime 行為與 GearMechanism 互動是正確的，並且取得的值也是相同的
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const mockValue = 16;
        GearMechanism.prototype.getPassTime = jest.fn().mockReturnValue(mockValue);  // mock 改成 class Name 加上 prototype
        const clock = new NonDIExampleClock("Test Clock");

        // Act
        const resultTime = clock.getTime();

        // Assert
        expect(GearMechanism).toBeCalledTimes(1)
        expect(GearMechanism.prototype.getPassTime).toBeCalledTimes(1);
        expect(resultTime).toEqual(mockValue);
    });

    // 當 Mock 的物件需要自訂義 Function 要回傳的值時 `mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);`
    // 測試當 clock 呼叫 getTime 行為與 GearMechanism 互動是正確的，並且取得的值也是相同的
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const mockValue = -16;  // 注意，這個值是負的，所以 expect 應該會是 0
        GearMechanism.prototype.getPassTime = jest.fn().mockReturnValue(mockValue);
        const clock = new NonDIExampleClock("Test Clock");

        // Act
        const resultTime = clock.getTime();

        // Assert
        expect(GearMechanism).toBeCalledTimes(1)
        expect(GearMechanism.prototype.getPassTime).toBeCalledTimes(1);
        expect(resultTime).toEqual(0);
    });
});

