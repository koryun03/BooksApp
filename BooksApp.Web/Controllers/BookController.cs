using AutoMapper;
using BooksApp.Application.Models.Book;
using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain.Common.Constants;
using BooksApp.Domain.Dto.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BooksApp.Web.Controllers
{
    public class BookController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;
        public BookController(IMapper mapper, IBookService bookService)
        {
            _mapper = mapper;
            _bookService = bookService;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> Post(BookInsertModel model)
        {
            var dto = _mapper.Map<BookInsertDto>(model);
            var id = await _bookService.AddAsync(dto);
            return Ok(id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> PostBookAndAuthor(BookAndAuthorInsertModel model)
        {
            var dto = _mapper.Map<BookAndAuthorInsertDto>(model);
            var id = await _bookService.AddBookAndAuthorAsync(dto);
            return Ok(id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut]
        public async Task<IActionResult> Update(BookModel model)
        {
            var dto = _mapper.Map<BookDto>(model);
            await _bookService.UpdateAsync(dto);
            return Ok(dto.Id);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [AllowAnonymous]
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);
            return Ok(book);
        }

    }
}
