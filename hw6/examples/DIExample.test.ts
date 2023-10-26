import { DIExampleClock } from "./DIExample";
import { GearMechanism } from "./GearMechanism";

/* 將整個模組都 Auto-Mock 掉
 * 這樣代表再測試的時候 GearMechanism 已經是都被 Mock 了
 * 所以再測試時直接 new GearMechanism() 就是一個 Mock Object
 * 你可以試著把這行註解掉
 * 會發現 `expect(mockedGearMech.reset).toBeCalledTimes(1)` 不會過了 */
jest.mock('./GearMechanism');


// 最基本方法
describe("Clock class (Dependency Injection)", () => {

    // 最簡單的例子
    // 測試當 clock 呼叫 reset method 時，GearMechanism 的 reset method 真的有被呼叫
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const mockedGearMech = new GearMechanism() as jest.Mocked<GearMechanism>;  // `as jest.Mocked<GearMechanism>` 強制轉型，可有可無 
        const clock = new DIExampleClock("Test Clock", mockedGearMech);

        // Act
        clock.reset();

        // Assert
        expect(mockedGearMech.reset).toBeCalledTimes(1)
    });

    
    // 當 Mock 的物件需要自訂義 Function 要回傳的值時 `mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);`
    // 測試當 clock 呼叫 getTime 行為與 GearMechanism 互動是正確的，並且取得的值也是相同的
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const mockValue = 16;
        const mockedGearMech = new GearMechanism() as jest.Mocked<GearMechanism>;  // `as jest.Mocked<GearMechanism>` 強制轉型，可有可無 
        mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);
        const clock = new DIExampleClock("Test Clock", mockedGearMech);

        // Act
        const resultTime = clock.getTime();

        // Assert
        expect(mockedGearMech.getPassTime).toBeCalledTimes(1);
        expect(resultTime).toEqual(mockValue);
    });

    // 當 Mock 的物件需要自訂義 Function 要回傳的值時 `mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);`
    // 測試當 clock 呼叫 getTime 行為與 GearMechanism 互動是正確的，並且取得的值也是相同的
    test("Should call Gear Mechanism Reset Method once when clock call reset method", () => {
        // Arrange
        const mockValue = -16;  // 注意，這個值是負的，所以 expect 應該會是 0
        const mockedGearMech = new GearMechanism() as jest.Mocked<GearMechanism>;  // `as jest.Mocked<GearMechanism>` 強制轉型，可有可無 
        mockedGearMech.getPassTime = jest.fn().mockReturnValue(mockValue);
        const clock = new DIExampleClock("Test Clock", mockedGearMech);

        // Act
        const resultTime = clock.getTime();

        // Assert
        expect(mockedGearMech.getPassTime).toBeCalledTimes(1);
        expect(resultTime).toEqual(0);
    });
});

