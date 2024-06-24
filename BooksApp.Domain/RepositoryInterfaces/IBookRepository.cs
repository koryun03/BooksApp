using BooksApp.Domain.Dto.Book;

namespace BooksApp.Domain.RepositoryInterfaces
{
    public interface IBookRepository
    {
        Task<int> AddAsync(BookInsertDto dto);
        Task<int> AddBookAndAuthorAsync(BookAndAuthorInsertDto dto);
        Task UpdateAsync(BookDto dto);
        Task DeleteAsync(int id);
        Task<BookAuthorDto> GetBookByIdAsync(int id);
        Task<IEnumerable<BookAuthorDto>> GetAllBooksAsync();
    }
}
