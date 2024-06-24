namespace BooksApp.Application.Models.Book
{
    public class BookInsertModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}
