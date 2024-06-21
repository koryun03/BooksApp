using BooksApp.Domain.Dto;

namespace BooksApp.Domain.RepositoryInterfaces
{
    public interface IAuthRepository
    {
        Task<UserDto> GetUserFirstByUserName(string userName);

    }
}
