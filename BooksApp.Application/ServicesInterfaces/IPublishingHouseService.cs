using BooksApp.Domain.Dto.PublishingHouse;

namespace BooksApp.Application.ServicesInterfaces
{
    public interface IPublishingHouseService
    {
        Task<int> AddAsync(PublishingHouseInsertDto dto);
        Task UpdateAsync(PublishingHouseDto dto);
        Task DeleteAsync(int id);
        Task<PublishingHouseBookDto> GetByIdAsync(int id);
        Task<IEnumerable<PublishingHouseBookDto>> GetAllAsync();
    }
}
