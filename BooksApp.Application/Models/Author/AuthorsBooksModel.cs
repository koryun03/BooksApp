using BooksApp.Application.Models.Book;

namespace BooksApp.Application.Models.Author
{
    public class AuthorsBooksModel : AuthorModel
    {
        public List<BookResponseModel> Books { get; set; }
    }
}
