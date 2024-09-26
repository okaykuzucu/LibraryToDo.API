using AutoMapper;
using LibraryToDo.Models.Db.Models;
using LibraryToDo.Models.Requests.User;
using LibraryToDo.Models.Responses.User;

namespace LibraryToDo.Api.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserCreateRequestDTO, User>().ReverseMap();
            CreateMap<User, UserCreateRequestDTO>().ReverseMap();
            CreateMap<UserUpdateRequestDTO, User>().ReverseMap();
            CreateMap<UserRequestDTO, User>().ReverseMap();
            CreateMap<UserResponseDTO, User>().ReverseMap();
        }
    }

    public class UserMappingAction : IMappingAction<User, UserResponseDTO>
    {
        public void Process(User source, UserResponseDTO destination, ResolutionContext context)
        {
            var s = source;
            var dest = destination;
            var cont = context;
        }
    }
}
