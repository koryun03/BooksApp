namespace BooksApp.Domain.Dto.Book
{
    public class BookInsertDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int AuthorId { get; set; }
    }
}
