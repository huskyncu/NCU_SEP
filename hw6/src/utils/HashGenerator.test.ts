// describe("Need implement", () => {
//     test("Todo", () => {
//         expect(1).toEqual(1);
//     });
// });
import { HashGenerator } from "./HashGenerator";
import { TestBookInfo } from "../__test__/TestingData"; 
describe("HashGenerator", () => {
    let hashGenerator: HashGenerator;

    beforeEach(() => {
        hashGenerator = new HashGenerator();
    });

    afterEach(() => {
        jest.restoreAllMocks();  
    });

    it("should generate random uppercase characters", () => {
        jest.spyOn(Math, 'random').mockReturnValueOnce(0).mockReturnValueOnce(0.0384615385);  // A, B
        const result = hashGenerator.g(2);
        expect(result).toBe("AB");
    });

    it("should throw an error for character numbers less than 0", () => {
        expect(() => hashGenerator.g(-1)).toThrowError("Hash number can't less than 0");
    });

    // it("should convert pattern to ISBN format", () => {
    //     jest.spyOn(Math, 'random').mockReturnValueOnce(0).mockReturnValueOnce(0.1).mockReturnValueOnce(0.2);  // 0, 1, 2
    //     const result = hashGenerator.simpleISBN("00-00");
    //     expect(result).toBe("01-23");
    // });

    it("should keep '-' characters unchanged in ISBN format", () => {
        jest.spyOn(Math, 'random').mockReturnValueOnce(0).mockReturnValueOnce(0.1).mockReturnValueOnce(0.2);  // 0, 1, 2
        const result = hashGenerator.simpleISBN("--00-");
        expect(result).toBe("--01-");
    });

    it("should generate valid ISBN format for longer patterns", () => {
        jest.spyOn(Math, 'random').mockReturnValue(0); 
        const result = hashGenerator.simpleISBN("000-0-00--");
        expect(result).toBe("000-0-00--");
    });
});
