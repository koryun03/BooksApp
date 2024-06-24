using AutoMapper;
using BooksApp.Application.Models.User;
using BooksApp.Domain.Dto.User;

namespace BooksApp.Application.Mappings
{
    public class AuthMapper : Profile
    {
        public AuthMapper()
        {
            CreateMap<RegistrationRequestDto, RegistrationRequestModel>().ReverseMap();
            CreateMap<LoginRequestDto, LoginRequestModel>().ReverseMap();
        }

    }
}
