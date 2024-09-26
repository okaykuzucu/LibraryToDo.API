using AutoMapper;
using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.Api.Models.Requests.Book;
using LibraryToDo.Api.Models.Responses.Book;

namespace LibraryToDo.Api.Mappings
{
    public class BookProfile : Profile
    {
        public BookProfile() 
        {
            CreateMap<BookCreateRequestDTO,Book>().ReverseMap();
            CreateMap<BookUpdateRequestDTO,Book>().ReverseMap();
            CreateMap<BookRequestDTO,Book>().ReverseMap();
            CreateMap<BookFileCreateRequestDTO,Book>().ReverseMap();
            CreateMap<BookResponseDTO,Book>().ReverseMap();
        }
    }
}
