using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.GenericRepository;
using LibraryToDo.Models.Db.Context;
using LibraryToDo.Models.Db.Models;

namespace LibraryToDo.Api.Services.UserServices
{
    public class UserService : Repository<User>, IUserService
    {

        private readonly LibraryToDoDbContext _libraryToDoDbContext1;
        public UserService(LibraryToDoDbContext libraryToDoDbContext) : base(libraryToDoDbContext)
        {
            _libraryToDoDbContext1 = libraryToDoDbContext;
        }
    }
}
