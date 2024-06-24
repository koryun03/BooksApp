using BooksApp.Application.Models.Author;

namespace BooksApp.Application.Models.Book
{
    public class BookAndAuthorInsertModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public AuthorInsertModel Author { get; set; }
    }
}
