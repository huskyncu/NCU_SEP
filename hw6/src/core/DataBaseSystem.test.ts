// describe("Need implement", () => {
//     test("Todo", () => {
//         expect(1).toEqual(1);
//     });
// });
import { DataBaseSystem } from './DataBaseSystem';
import { BookDataBaseService } from "@externals/simple-db";
import { HashGenerator } from "../utils/HashGenerator";
import { TestBookInfo } from "../__test__/TestingData";

// Mock the external classes
jest.mock('@externals/simple-db');
jest.mock('../utils/HashGenerator');

describe('DataBaseSystem', () => {
    let dataBaseSystem: DataBaseSystem;
    let mockDBService: jest.Mocked<BookDataBaseService>;
    let mockHashGenerator: jest.Mocked<HashGenerator>;

    beforeEach(() => {
        // Create mock instances
        mockDBService = new BookDataBaseService() as jest.Mocked<BookDataBaseService>;
        mockHashGenerator = new HashGenerator() as jest.Mocked<HashGenerator>;

        dataBaseSystem = new DataBaseSystem(mockDBService, mockHashGenerator);
    });


    it("dataBaseSystem.getUpdateMessage() == Data Base Update", () => {
        expect(dataBaseSystem.getUpdateMessage()).toStrictEqual("Data Base Update");
      });

    it('should instantiate with default services if none are provided', () => {
        const defaultInstance = new DataBaseSystem();
        expect(defaultInstance).toBeTruthy();
        expect(defaultInstance.db).toBeInstanceOf(BookDataBaseService);
        expect(defaultInstance.hashGenerator).toBeInstanceOf(HashGenerator);
    });
    

    // ... [Your existing test setup and cases] ...

    it('should connect to the database on third attempt', async () => {
        mockDBService.setUp
            .mockRejectedValueOnce(new Error('Connection error 1'))
            .mockRejectedValueOnce(new Error('Connection error 2'))
            .mockResolvedValue("Connected successfully");

        mockDBService.getBooks.mockResolvedValue(TestBookInfo);

        await dataBaseSystem.connectDB();

        expect(mockDBService.setUp).toHaveBeenCalledTimes(3);
        expect(mockDBService.setUp).toHaveBeenCalledWith("http://localhost", 4000);
        expect(mockDBService.getBooks).toHaveBeenCalled();
    });

    it('should throw an error when HashGenerator fails to produce an ISBN', async () => {
        mockHashGenerator.simpleISBN.mockImplementationOnce(() => {
            throw new Error('HashGenerator error');
        });

        await expect(dataBaseSystem.addBook('Sample Book', 'Sample Author')).rejects.toThrow('Add book failed');
    });

    it('should throw specific error when adding a book with no title or author', async () => {
        await expect(dataBaseSystem.addBook('', 'Sample Author')).rejects.toThrow('Add book failed');
        await expect(dataBaseSystem.addBook('Sample Book', '')).rejects.toThrow('Add book failed');
    });

    it('should throw specific error when deleting a book with no ISBN', async () => {
        await expect(dataBaseSystem.deleteBook('')).rejects.toThrow('Delete book failed');
    });

    it('should throw error after retrying to connect to DB for max retry times', async () => {
        mockDBService.setUp.mockRejectedValue(new Error('Connection error'));
        
        await expect(dataBaseSystem.connectDB()).rejects.toThrow('Cannnot connect to DB');
    });

    
    it('should connect to the database successfully', async () => {
        mockDBService.setUp.mockResolvedValue("Connected successfully");
        mockDBService.getBooks.mockResolvedValue(TestBookInfo);

        await dataBaseSystem.connectDB();

        expect(mockDBService.setUp).toHaveBeenCalledWith("http://localhost", 4000);
        expect(mockDBService.getBooks).toHaveBeenCalled();
    });

    it('should throw an error if database connection fails', async () => {
        mockDBService.setUp.mockRejectedValue(new Error('DB Connection Error'));

        await expect(dataBaseSystem.connectDB()).rejects.toThrow('Cannnot connect to DB');
    });

    it('should add a book successfully', async () => {
        const mockISBN = "000-00-00000-00-0";
        mockHashGenerator.simpleISBN.mockReturnValue(mockISBN);

        await dataBaseSystem.addBook("Test Book", "Test Author");

        expect(mockHashGenerator.simpleISBN).toHaveBeenCalledWith("000-00-00000-00-0");
        expect(mockDBService.addBook).toHaveBeenCalledWith({
            ISBN: mockISBN,
            title: "Test Book",
            author: "Test Author",
        });
    });

    it('should throw error when adding a book with missing title or author', async () => {
        mockDBService.addBook.mockImplementationOnce((book) => {
            if (!book.title || !book.author) {
                throw new Error('Add book failed');
            }
            return Promise.resolve('Mocked ISBN');
        });
        await expect(dataBaseSystem.addBook('', 'Author')).rejects.toThrow('Add book failed');
        await expect(dataBaseSystem.addBook('Title', '')).rejects.toThrow('Add book failed');
    });

    it('should throw an error if ISBN is empty', async () => {
        await expect(dataBaseSystem.deleteBook("")).rejects.toThrow('Delete book failed');
    });


    it('should throw an error if deleting a book fails', async () => {
        mockDBService.deleteBook.mockRejectedValue(new Error('Delete Book Error'));

        await expect(dataBaseSystem.deleteBook("776-33-13328-46-3")).rejects.toThrow('Delete book failed');
    });

    it('should process and get books successfully', async () => {
        mockDBService.getBooks.mockResolvedValue(TestBookInfo);

        await dataBaseSystem.process([]);

        expect(mockDBService.getBooks).toHaveBeenCalled();
    });

    describe('DataBaseSystem - HashGenerator Integration', () => {

        beforeEach(() => {
            // Reset mocks before each test
            mockDBService.addBook.mockClear();
            mockHashGenerator.simpleISBN.mockClear();
        });
    
        it('should pass the correct ISBN pattern to HashGenerator', async () => {
            const mockISBN = "123-45-67890-12-3";
            mockHashGenerator.simpleISBN.mockReturnValue(mockISBN);
    
            await dataBaseSystem.addBook("Sample Book", "Sample Author");
    
            expect(mockHashGenerator.simpleISBN).toHaveBeenCalledWith("000-00-00000-00-0");
        });
    
        it('should throw an error when HashGenerator fails to generate ISBN', async () => {
            mockHashGenerator.simpleISBN.mockImplementationOnce(() => {
                throw new Error('Failed to generate ISBN');
            });
    
            await expect(dataBaseSystem.addBook("Sample Book", "Sample Author")).rejects.toThrow('Add book failed');
        });
    
    });
    
});
