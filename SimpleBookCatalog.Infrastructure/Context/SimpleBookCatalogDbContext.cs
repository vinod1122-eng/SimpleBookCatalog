// Importing necessary namespaces
using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Domain.Entities;

// Declaring the SimpleBookCatalogDbContext class within the SimpleBookCatalog.Infrastructure.Context namespace
namespace SimpleBookCatalog.Infrastructure.Context
{
    // DbContext class for interacting with the database
    public class SimpleBookCatalogDbContext : DbContext
    {
        // Constructor to initialize the DbContext with options
        public SimpleBookCatalogDbContext(DbContextOptions<SimpleBookCatalogDbContext> options) : base(options)
        {
            // Empty constructor body
        }

        // DbSet representing the "Books" table in the database
        public DbSet<Book> Books { get; set; }
    }
}
