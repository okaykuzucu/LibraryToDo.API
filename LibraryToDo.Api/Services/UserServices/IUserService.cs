using LibraryToDo.GenericRepository;
using LibraryToDo.Models.Db.Models;

namespace LibraryToDo.Api.Services.UserServices
{
    public interface IUserService : IRepository<User>
    {
    }
}
