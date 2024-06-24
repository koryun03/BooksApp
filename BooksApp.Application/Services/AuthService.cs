using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Dto.User;
using BooksApp.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;

namespace BooksApp.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _jwtTokenGenerator;
        public AuthService(UserManager<User> userManager,
            ITokenService jwtTokenGenerator)
        {
            _userManager = userManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<string> Register(RegistrationRequestDto dto)
        {
            try
            {
                User currentUser = await _userManager.FindByEmailAsync(dto.Email);

                if (currentUser != null)
                {
                    return "emailAlreadyExists";
                }

                var utcNow = DateTime.UtcNow;

                currentUser = new User
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    UserName = dto.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                currentUser.PasswordHash = _userManager.PasswordHasher.HashPassword(currentUser, dto.Password);

                await _userManager.CreateAsync(currentUser);
                await _userManager.AddToRoleAsync(currentUser, UserRoles.User);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public async Task<LoginResponseDto> Login(LoginRequestDto dto)
        {
            var user = await _userManager.FindByNameAsync(dto.UserName);

            bool isValid = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = string.Empty };
            }

            //if user was found , Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateJwtToken(user, roles);

            UserDto userDto = new()
            {
                Email = user.Email,
                UserName = user.UserName,
                Name = user.Name,
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDto,
                Token = token
            };

            return loginResponseDto;
        }

        public async Task<bool> AssignRole(string email, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                await _userManager.AddToRoleAsync(user, roleName.ToUpper());
                return true;
            }
            return false;
        }

    }
}
