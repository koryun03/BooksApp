namespace BooksApp.Domain.Entities
{
    public class PublishingHouse
    {
        public int Id { get; set; }
        public string PublishingHouseName { get; set; }
        public int Count { get; set; }
        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}
