using BooksApp.Domain.Dto.Book;
using System.Text.Json.Serialization;

namespace BooksApp.Domain.Dto.PublishingHouse
{
    public class PublishingHouseBookDto : PublishingHouseDto
    {
        [JsonPropertyOrder(3)]
        //    public BookDto Book { get; set; }
        public BookAuthorDto Book { get; set; }
    }
}
