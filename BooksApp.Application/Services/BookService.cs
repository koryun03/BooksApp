using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain;
using BooksApp.Domain.Dto.Book;

namespace BooksApp.Application.Services
{
    public class BookService : IBookService
    {
        public readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(BookInsertDto dto)
        {
            return await _unitOfWork.BookRepository.AddAsync(dto);
        }

        public async Task<int> AddBookAndAuthorAsync(BookAndAuthorInsertDto dto)
        {
            return await _unitOfWork.BookRepository.AddBookAndAuthorAsync(dto);
        }

        public async Task UpdateAsync(BookDto dto)
        {
            await _unitOfWork.BookRepository.UpdateAsync(dto);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.BookRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BookAuthorDto>> GetAllBooksAsync()
        {
            return await _unitOfWork.BookRepository.GetAllBooksAsync();
        }

        public async Task<BookAuthorDto> GetBookByIdAsync(int id)
        {
            return await _unitOfWork.BookRepository.GetBookByIdAsync(id);
        }

    }
}
