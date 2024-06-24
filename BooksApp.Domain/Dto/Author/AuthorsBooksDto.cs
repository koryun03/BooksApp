using BooksApp.Domain.Dto.Book;
using System.Text.Json.Serialization;

namespace BooksApp.Domain.Dto.Author
{
    public class AuthorsBooksDto : AuthorDto
    {
        [JsonPropertyOrder(1)]
        public List<BookResponseDto> Books { get; set; }
    }
}
