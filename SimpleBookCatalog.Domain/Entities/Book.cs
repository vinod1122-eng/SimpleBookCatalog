// Importing necessary namespaces
using SimpleBookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

// Declaring the Book class within the SimpleBookCatalog.Domain.Entities namespace
namespace SimpleBookCatalog.Domain.Entities
{
    // Entity class representing a book
    public class Book
    {
        // Property representing the unique identifier of the book
        public int Id { get; set; }

        // Property representing the title of the book
        [Required(ErrorMessage = "Please provide a title")]     // Required attribute to ensure a title is provided
        [StringLength(100)]                                     // Maximum length of 100 characters for the title
        public string? Title { get; set; }

        // Property representing the author's name
        [Required(ErrorMessage = "Please provide an author's name")]  // Required attribute to ensure an author's name is provided
        [StringLength(100)]                                         // Maximum length of 100 characters for the author's name
        public string? Author { get; set; }

        // Property representing the publication date of the book
        public DateTime? PublicationDate { get; set; }

        // Property representing the category of the book
        [EnumDataType(typeof(Category), ErrorMessage = "Please select a category")]  // Validates that the category is a valid enum value
        public Category Category { get; set; }
    }
}
