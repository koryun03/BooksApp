using BooksApp.Domain.Dto.Author;

namespace BooksApp.Domain.RepositoryInterfaces
{
    public interface IAuthorRepository
    {
        Task<int> AddAsync(AuthorInsertDto dto);
        Task UpdateAsync(AuthorDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorsBooksDto> GetAuthorsBooksById(int id);
    }
}
