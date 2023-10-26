import { TestBookInfo } from "../__test__/TestingData"; 
import { FilterSystem } from "./FilterSystem";

describe('FilterSystem', () => {
    let filterSystem: FilterSystem;

    beforeEach(() => {
        filterSystem = new FilterSystem();
    });

    it("SortSystem.getUpdateMessage() == Filter Update", () => {
        expect(filterSystem.getUpdateMessage()).toStrictEqual("Filter Update");
      });

    describe('Default State', () => {
        test('should have empty filterWord by default', () => {
            expect(filterSystem.getFilterWord()).toEqual('');
        });

        test('should not ignore case by default', () => {
            expect(filterSystem.isIgnoreCase()).toBe(false);
        });
    });

    describe('Setting and Getting Filter Word', () => {
        test('should set and get filterWord correctly', () => {
            filterSystem.setFilterWord('Game');
            expect(filterSystem.getFilterWord()).toEqual('Game');
        });
    });

    describe('Setting and Getting Ignore Case', () => {
        test('should set and get ignoreCase correctly', () => {
            filterSystem.setIgnoreCase(true);
            expect(filterSystem.isIgnoreCase()).toBe(true);
        });
    });

    describe('Processing Items', () => {
        test('should filter items based on the filter word without ignoring case', async () => {
            filterSystem.setFilterWord('Game');
            await filterSystem.process( TestBookInfo );
            expect(filterSystem.getItems()).toEqual([
                { "ISBN": "255-03-71788-05-4", "title": "Game of Thrones I", "author": "Ray Bradbury" },
                { "ISBN": "148-71-77362-42-3", "title": "Game of Thrones II", "author": "J. R. R. Tolkien" }
            ]);
        });

        test('should filter items based on the filter word with ignoring case', async () => {
            filterSystem.setFilterWord('game');
            filterSystem.setIgnoreCase(true);
            await filterSystem.process( TestBookInfo );
            expect(filterSystem.getItems()).toEqual([
                { "ISBN": "255-03-71788-05-4", "title": "Game of Thrones I", "author": "Ray Bradbury" },
                { "ISBN": "148-71-77362-42-3", "title": "Game of Thrones II", "author": "J. R. R. Tolkien" }
            ]);
        });
    });
});
