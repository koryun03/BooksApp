using BooksApp.Domain.Dto.Book;

namespace BooksApp.Application.ServicesInterfaces
{
    public interface IBookService
    {
        Task<int> AddAsync(BookInsertDto dto);
        Task<int> AddBookAndAuthorAsync(BookAndAuthorInsertDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
        Task<BookAuthorDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookAuthorDto>> GetAllBooksAsync();
    }
}
