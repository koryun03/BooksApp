using AutoMapper;
using BooksApp.Application.Models.PublishingHouse;
using BooksApp.Domain.Dto.PublishingHouse;

namespace BooksApp.Application.Mappings
{
    public class PublishingHouseMapper : Profile
    {
        public PublishingHouseMapper()
        {
            CreateMap<PublishingHouseInsertDto, PublishingHouseInsertModel>().ReverseMap();
            CreateMap<PublishingHouseDto, PublishingHouseModel>().ReverseMap();
            CreateMap<PublishingHouseBookDto, PublishingHouseBookModel>().ReverseMap();
        }

    }
}
