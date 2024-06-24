using BooksApp.Application.ServicesInterfaces;
using BooksApp.Domain;
using BooksApp.Domain.Dto.PublishingHouse;

namespace BooksApp.Application.Services
{
    public class PublishingHouseService : IPublishingHouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublishingHouseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddAsync(PublishingHouseInsertDto dto)
        {
            return await _unitOfWork.PublishingHouseRepository.AddAsync(dto);
        }

        public async Task UpdateAsync(PublishingHouseDto dto)
        {
            await _unitOfWork.PublishingHouseRepository.UpdateAsync(dto);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.PublishingHouseRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<PublishingHouseBookDto>> GetAllAsync()
        {
            return await _unitOfWork.PublishingHouseRepository.GetAllAsync();
        }

        public async Task<PublishingHouseBookDto> GetByIdAsync(int id)
        {
            return await _unitOfWork.PublishingHouseRepository.GetByIdAsync(id);
        }

    }
}
