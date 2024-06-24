using AutoMapper;
using BooksApp.Application.Models.Author;
using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Dto.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Web.Controllers
{
    public class AuthorController : ApiControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;
        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AuthorInsertModel model)
        {
            var dto = _mapper.Map<AuthorInsertDto>(model);
            var id = await _authorService.AddAsync(dto);
            return Ok(id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] AuthorModel model)
        {
            var dto = _mapper.Map<AuthorDto>(model);
            await _authorService.UpdateAsync(dto);
            return Ok(dto.Id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _authorService.DeleteAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _authorService.GetAllAsync();
            return Ok(result);
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _authorService.GetByIdAsync(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAuthorsBooksById(int id)
        {
            var result = await _authorService.GetAuthorsBooksById(id);
            return Ok(result);
        }
    }
}
