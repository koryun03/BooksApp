using AutoMapper;
using BooksApp.Application.Models;
using BooksApp.Domain.Dto;

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
