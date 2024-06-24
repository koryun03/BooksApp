using BooksApp.Application.Models.Book;

namespace BooksApp.Application.Models.PublishingHouse
{
    public class PublishingHouseBookModel : PublishingHouseModel
    {
        public BookModel Book { get; set; }
    }
}
