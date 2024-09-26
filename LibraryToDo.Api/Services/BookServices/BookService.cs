using Dapper.Contrib.Extensions;
using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.Api.Models.Requests.Book;
using LibraryToDo.GenericRepository;
using LibraryToDo.Models.Db.Context;
using System.Data;

namespace LibraryToDo.Api.Services.BookServices
{
    public class BookService : Repository<Book>, IBookService
    {
        private readonly IDbConnection ctx;
        private readonly LibraryToDoDbContext _libraryToDoDbContext;
        public BookService(LibraryToDoDbContext libraryToDoDbContext) : base(libraryToDoDbContext)
        {
            _libraryToDoDbContext = libraryToDoDbContext;
            ctx = _libraryToDoDbContext.CreateConnection();
        }


        public async Task<List<Book>> InserFile(BookFileCreateRequestDTO model)
        {
            var books = new List<Book>();

            foreach (var bookDto in model.bookCreateRequestDTOs)
            {
                var book = new Book
                {
                    Author = bookDto.Author,
                    Title = bookDto.Title,
                    Publisher = bookDto.Publisher,
                    Price = bookDto.Price,
                    Image = bookDto.Image
                };

                
                await ctx.InsertAsync(book);
                books.Add(book); 
            }

            return books;
        }
    }
}
