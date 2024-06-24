using AutoMapper;
using BooksApp.Application.Models.Book;
using BooksApp.Domain.Dto.Book;

namespace BooksApp.Application.Mappings
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookInsertDto, BookInsertModel>().ReverseMap();
            CreateMap<BookDto, BookModel>().ReverseMap();
            CreateMap<BookAuthorDto, BookAuthorModel>().ReverseMap();
            CreateMap<BookResponseDto, BookResponseModel>().ReverseMap();
            CreateMap<BookAndAuthorInsertDto, BookAndAuthorInsertModel>().ReverseMap();
        }
    }
}
