using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain;
using BooksApp.Domain.Dto.Author;

namespace BooksApp.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(AuthorInsertDto dto)
        {
            return await _unitOfWork.AuthorRepository.AddAsync(dto);
        }
        public async Task UpdateAsync(AuthorDto dto)
        {
            await _unitOfWork.AuthorRepository.UpdateAsync(dto);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.AuthorRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AuthorDto>> GetAllAsync()
        {
            return await _unitOfWork.AuthorRepository.GetAllAsync();
        }

        public async Task<AuthorDto> GetByIdAsync(int id)
        {
            return await _unitOfWork.AuthorRepository.GetByIdAsync(id);
        }

        public async Task<AuthorsBooksDto> GetAuthorsBooksById(int id)
        {
            return await _unitOfWork.AuthorRepository.GetAuthorsBooksById(id);
        }

    }
}
