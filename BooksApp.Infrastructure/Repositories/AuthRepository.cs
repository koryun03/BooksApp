using BooksApp.Domain.Dto;
using BooksApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksApp.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationContext _context;
        public AuthRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<UserDto> GetUserFirstByUserName(string userName)
        {
            try
            {
                var user = await _context.Users.AsNoTracking().FirstAsync(p => p.UserName == userName);
                await _context.SaveChangesAsync();
                return new UserDto
                {
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
