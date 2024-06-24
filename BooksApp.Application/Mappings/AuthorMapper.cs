using AutoMapper;
using BooksApp.Application.Models.Author;
using BooksApp.Domain.Dto.Author;

namespace BooksApp.Application.Mappings
{
    public class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<AuthorInsertDto, AuthorInsertModel>().ReverseMap();
            CreateMap<AuthorDto, AuthorModel>().ReverseMap();
            CreateMap<AuthorsBooksDto, AuthorsBooksModel>().ReverseMap();
        }

    }
}
