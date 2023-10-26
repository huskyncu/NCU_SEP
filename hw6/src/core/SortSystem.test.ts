// describe("Need implement", () => {
//     test("Todo", () => {
//         expect(1).toEqual(1);
//     });
// });
import { TestBookInfo } from "../__test__/TestingData"; 
import { SortSystem } from "./SortSystem";
import { BookInfo } from "@externals/simple-db";
describe("SortSystem", () => {

    let sortSystem: SortSystem;

    beforeEach(() => {
        sortSystem = new SortSystem();
    });
    it("SortSystem.getUpdateMessage() == Sort Update", () => {
        expect(sortSystem.getUpdateMessage()).toStrictEqual("Sort Update");
      });
    it("should have default sort type as ASC", () => {
        expect(sortSystem.getSortType()).toBe("ASC");
    });

    it("should set sort type correctly", () => {
        sortSystem.setSortType("DESC");
        expect(sortSystem.getSortType()).toBe("DESC");

        sortSystem.setSortType("ASC");
        expect(sortSystem.getSortType()).toBe("ASC");
    });

    it("should throw error for invalid sort type", () => {
        expect(() => sortSystem.setSortType("INVALID")).toThrow("It must be ASC or DESC");
    });

    it("should sort books in ascending order by title", async () => {
        await sortSystem.process(TestBookInfo);
        const sortedItems = sortSystem.getItems();
        // expect the first book in the sorted list to have the title "Alice Adventures in Wonderland"
        expect(sortedItems[0].title).toBe("Alice Adventures in Wonderland");
    });
    
    it("should sort books in descending order by title", async () => {
        sortSystem.setSortType("DESC");
        await sortSystem.process(TestBookInfo);
        const sortedItems = sortSystem.getItems();
        // expect the first book in the sorted list to have the title "To Kill a Mockingbird"
        expect(sortedItems[0].title).toBe("To Kill a Mockingbird");
    });
    
    it("should handle empty book list correctly", async () => {
        await sortSystem.process([]);
        const sortedItems = sortSystem.getItems();
        expect(sortedItems.length).toBe(0);
    });

        
});

