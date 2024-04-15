// Declaring the namespace for enums related to book categories
namespace SimpleBookCatalog.Domain.Enums
{
    // Enum representing different categories of books
    public enum Category
    {
        // Enum members representing different categories, each with an associated integer value
        // Note: Enum members with explicit values start counting from the specified value
        Science = 1,    // Science category with value 1
        Technology,     // Technology category with value 2 (implicitly incremented by 1)
        Fitness,        // Fitness category with value 3 (implicitly incremented by 1)
        Travel          // Travel category with value 4 (implicitly incremented by 1)
    }
}
