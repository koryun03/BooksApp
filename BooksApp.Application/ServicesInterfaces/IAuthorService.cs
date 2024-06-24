using BooksApp.Domain.Dto.Author;

namespace BooksApp.Application.ServicesInterfaces
{
    public interface IAuthorService
    {
        Task<int> AddAsync(AuthorInsertDto dto);
        Task UpdateAsync(AuthorDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<AuthorDto>> GetAllAsync();
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorsBooksDto> GetAuthorsBooksById(int id);

    }
}
