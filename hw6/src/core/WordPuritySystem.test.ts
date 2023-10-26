// describe("Need implement", () => {
//     test("Todo", () => {
//         expect(1).toEqual(1);
//     });
// });
import { WordPuritySystem } from './WordPuritySystem';
import { TestBookInfo } from "../__test__/TestingData"; 

describe('WordPuritySystem', () => {
    let wordPuritySystem: WordPuritySystem;
    let mockPurityService: any;

    beforeEach(() => {
        mockPurityService = {
            purity: jest.fn((input: string) => {
                return input.replace(/Copperfield|Wonderland/gi, '**********');
            }),
            addWord: jest.fn()
        };

        wordPuritySystem = new WordPuritySystem(mockPurityService);
    });
    it("WordPuritySystem.getUpdateMessage() == Dom Purity Update", () => {
        expect(wordPuritySystem.getUpdateMessage()).toStrictEqual("Dom Purity Update");
      });
    it('should add sensitive words to WordPurityService', () => {
        expect(mockPurityService.addWord).toHaveBeenCalledWith(["Copperfield", "Wonderland"]);
    });

    it('should disable purity feature when setDisablePurity is called with true', () => {
        wordPuritySystem.setDisablePurity(true);
        expect(wordPuritySystem.isDisablePurity()).toBe(true);
    });

    it('should enable purity feature when setDisablePurity is called with false', () => {
        wordPuritySystem.setDisablePurity(false);
        expect(wordPuritySystem.isDisablePurity()).toBe(false);
    });

    it('should purify book titles when process is called and purity feature is enabled', async () => {
        const testItems = [...TestBookInfo];
        await wordPuritySystem.process(testItems);
        expect(wordPuritySystem.getItems()[6].title).toBe('Alice Adventures in **********');
        expect(mockPurityService.purity).toHaveBeenCalled();
    });

    it('should not purify book titles when process is called and purity feature is disabled', async () => {
        wordPuritySystem.setDisablePurity(true);
        const testItems = [...TestBookInfo];
        await wordPuritySystem.process(testItems);
        expect(testItems[6].title).toBe('Alice Adventures in Wonderland');
    });
});
