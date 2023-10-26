import { SpyOnExample } from "./SpyOnExample";

// 最基本方法
describe("Clock class (Non-Dependency Injection)", () => {

    beforeEach(() => {
        // 因為 Date.now() 是一個 global 的 function 所以需要做 reset
        jest.resetAllMocks();
    })

    // 測試當 getThisYearTimePassed 時，Date.now() 真的有被呼叫
    test("Should call date now once", () => {
        // Arrange
        // `const spyDateNowFn = jest.spyOn(Date, 'now')` 這樣意思是可以偷看這個 function 的行為與回傳
        const spyDateNowFn = jest.spyOn(Date, 'now');
        const example = new SpyOnExample();

        // Act
        example.getThisYearTimePassed();

        // Assert
        // 驗證 date now 有被呼叫 1 次
        expect(spyDateNowFn).toBeCalledTimes(1); // 驗證 GearMechanism 的 reset method 有被呼叫 1 次
    });

      // 測試當 clock 呼叫 reset method 時，GearMechanism 的 reset method 真的有被呼叫
      test("Should output 1 hour", () => {
        // Arrange
        // Date.parse("2023-01-01 00:00:00") = 1672502400000;
        // 而加上 mockReturnValue 則可以模擬它 return 出的值
        const spyDateNowFn = jest.spyOn(Date, 'now').mockReturnValue(1672502400000 + (60 * 60 * 1000));
        const example = new SpyOnExample();

        // Act
        const result = example.getThisYearTimePassed();

        // Assert
        expect(result).toEqual({
            hour: 1,
            day:  0,
            week: 0
        });  
        // 驗證 date now 有被呼叫 1 次
        expect(spyDateNowFn).toBeCalledTimes(1);
    });

    // 測試當 clock 呼叫 reset method 時，GearMechanism 的 reset method 真的有被呼叫
    test("Should output 1 hour", () => {
        // Arrange
        // Date.parse("2023-01-01 00:00:00") = 1672502400000;
        // 而加上 mockReturnValueOnce 是只 mock return value 一次
        const spyDateNowFn = jest.spyOn(Date, 'now')
                                    .mockReturnValueOnce(1672502400000 + (60 * 60 * 1000))
                                    .mockReturnValueOnce(1672502400000 + (24 * 60 * 60 * 1000))
                                    .mockReturnValueOnce(1672502400000 + (7 * 24 * 60 * 60 * 1000))
        const example = new SpyOnExample();

        // Act
        const oneHour = example.getThisYearTimePassed();
        const oneDay = example.getThisYearTimePassed();
        const oneWeek = example.getThisYearTimePassed();

        // Assert
        expect(oneHour).toEqual({
            hour: 1,
            day:  0,
            week: 0
        });  
        expect(oneDay).toEqual({
            hour: 24,
            day:  1,
            week: 0
        }); 
        expect(oneWeek).toEqual({
            hour: 24 * 7,
            day:  7,
            week: 1
        }); 
        // 驗證 date now 有被呼叫 3 次
        expect(spyDateNowFn).toBeCalledTimes(3);
    });
});

