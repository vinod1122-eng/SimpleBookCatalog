// Importing the Book entity from the SimpleBookCatalog.Domain.Entities namespace
using SimpleBookCatalog.Domain.Entities;

// Declaring the interface within the SimpleBookCatalog.Application.Interfaces namespace
namespace SimpleBookCatalog.Application.Interfaces
{
    // Interface for the book repository
    public interface IBookRepository
    {
        // Method to add a new book asynchronously
        Task AddAsync(Book book);

        // Method to retrieve all books asynchronously
        Task<List<Book>> GetAllAsync();

        // Method to retrieve a book by its id asynchronously
        Task<Book>? GetByIdAsync(int id);

        // Method to update a book asynchronously
        Task UpdateAsync(Book book);

        // Method to delete a book by its id asynchronously
        Task DeleteByIdAsync(int id);
    }
}
