using BooksApp.Application.Models.Author;

namespace BooksApp.Application.Models.Book
{
    public class BookAuthorModel : BookModel
    {
        public AuthorModel Author { get; set; }

    }
}
