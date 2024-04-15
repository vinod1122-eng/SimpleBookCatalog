// Importing necessary namespaces
using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;
using SimpleBookCatalog.Infrastructure.Context;

// Declaring the BookRepository class within the SimpleBookCatalog.Infrastructure.Repositories namespace
namespace SimpleBookCatalog.Infrastructure.Repositories
{
    // Implementation of the IBookRepository interface
    public class BookRepository : IBookRepository
    {
        // Private field to hold the database context
        private readonly SimpleBookCatalogDbContext context;

        // Constructor to initialize the repository with a database context
        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            // Creating a new instance of the database context using the factory
            context = factory.CreateDbContext();
        }

        // Method to add a new book asynchronously
        public async Task AddAsync(Book book)
        {
            // Adding the book to the context and saving changes to the database
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }

        // Method to delete a book by its id asynchronously
        public async Task DeleteByIdAsync(int id)
        {
            // Retrieving the book by its id
            var book = await GetByIdAsync(id);

            // If the book exists, remove it from the context and save changes to the database
            if (book is not null)
            {
                context.Books.Remove(book);
                await context.SaveChangesAsync();
            }
        }

        // Method to retrieve all books asynchronously
        public async Task<List<Book>> GetAllAsync()
        {
            // Retrieving all books from the context and returning them as a list
            var books = await context.Books.ToListAsync();
            return books;
        }

        // Method to retrieve a book by its id asynchronously
        public async Task<Book>? GetByIdAsync(int id)
        {
            // Retrieving the book by its id from the context and returning it
            var book = await context.Books.FirstOrDefaultAsync(e => e.Id == id);
            return book;
        }

        // Method to update a book asynchronously
        public async Task UpdateAsync(Book book)
        {
            // Marking the book entity as modified and saving changes to the database
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
