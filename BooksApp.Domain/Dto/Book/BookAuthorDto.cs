using BooksApp.Domain.Dto.Author;
using System.Text.Json.Serialization;

namespace BooksApp.Domain.Dto.Book
{
    public class BookAuthorDto : BookDto
    {
        [JsonPropertyOrder(2)]
        public AuthorDto Author { get; set; }
    }
}
