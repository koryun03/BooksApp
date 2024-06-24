using BooksApp.Domain.Dto.Book;
using System.Text.Json.Serialization;

namespace BooksApp.Domain.Dto.PublishingHouse
{
    public class PublishingHouseBookDto : PublishingHouseDto
    {
        [JsonPropertyOrder(3)]
        public BookAuthorDto Book { get; set; }
    }
}
