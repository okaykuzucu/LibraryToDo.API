using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.Api.Models.Requests.Book;
using LibraryToDo.GenericRepository;

namespace LibraryToDo.Api.Services.BookServices
{
    public interface IBookService : IRepository<Book>
    {
        Task<List<Book>> InserFile(BookFileCreateRequestDTO model);
    }
}
