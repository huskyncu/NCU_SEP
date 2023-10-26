import { DisplayRangeSystem } from "./DisplayRangeSystem";  
import { TestBookInfo } from "../__test__/TestingData";  

describe("DisplayRangeSystem", () => {
    let system: DisplayRangeSystem;

    beforeEach(() => {
        system = new DisplayRangeSystem();
    });

    it("should set range correctly with number inputs", () => {
        system.setRange(2, 5);
        expect(system.getStartRange()).toBe(2);
        expect(system.getEndRange()).toBe(5);
    });

    it("should set range correctly with string inputs", () => {
        system.setRange("2", "5");
        expect(system.getStartRange()).toBe(2);
        expect(system.getEndRange()).toBe(5);
    });

    it("should throw an error for invalid string inputs", () => {
        expect(() => system.setRange("invalid", "5")).toThrowError("Invalid String Input");
    });

    it("should throw an error for float number inputs", () => {
        expect(() => system.setRange(2.5, 5)).toThrowError("Invalid Float Input");
    });

    it("should throw an error for negative number inputs", () => {
        expect(() => system.setRange(-2, 5)).toThrowError("Cannot be less than 0");
    });

    it("should throw an error if end range is less than start range", () => {
        expect(() => system.setRange(5, 2)).toThrowError("End Range cannot less than Start Range");
    });

    it("should process and display correct range of books", async () => {
        await system.process(TestBookInfo);
        const defaultDisplayed = system.getItems();
        expect(defaultDisplayed.length).toBe(8);

        system.setRange(2, 5);
        await system.process(TestBookInfo);
        const displayed = system.getItems();
        expect(displayed.length).toBe(4);
        expect(displayed[0].title).toBe("Game of Thrones I");
    });
});
