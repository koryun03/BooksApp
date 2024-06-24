using BooksApp.Domain.Dto.Author;

namespace BooksApp.Domain.Dto.Book
{
    public class BookAndAuthorInsertDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public AuthorInsertDto Author { get; set; }
    }
}
