using BooksApp.Domain.Entities.Users;

namespace BooksApp.Application.ServicesInterfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User applicationUser, IEnumerable<string> roles);
    }
}
