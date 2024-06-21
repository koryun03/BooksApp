using AutoMapper;
using BooksApp.Application.Models;
using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel model)
        {
            var dto = _mapper.Map<RegistrationRequestDto>(model);
            var registerResponse = await _authService.Register(dto);
            if (!string.IsNullOrEmpty(registerResponse))
            {
                return BadRequest(registerResponse);
            }
            return Ok("Success");
        }

        [HttpPost("LogIn")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
        {
            var dto = _mapper.Map<LoginRequestDto>(model);
            var loginResponse = await _authService.Login(dto);
            if (loginResponse.User == null)
            {
                return BadRequest("Username or password is incorrect");
            }
            return Ok(loginResponse);
        }

        //need to change
        #region SectionRoles 

        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole(string email, string roleName)
        {
            var result = await _authService.AssignRole(email, roleName);
            if (!result)
            {
                return BadRequest("Error encountered");
            }
            return Ok("Success");

        }

        [Authorize]
        [HttpGet("TestAuthroize")]
        public async Task<IActionResult> TestAuthroize()
        {
            return Ok("you are authorized");
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("TestAdminRole")]
        public async Task<IActionResult> TestAdminRole()
        {
            return Ok("your role is Admin");
        }

        [Authorize(Roles = UserRoles.User)]
        [HttpGet("TestUserRole")]
        public async Task<IActionResult> TestUserRole()
        {
            return Ok("your role is User");
        }

        #endregion

    }
}
