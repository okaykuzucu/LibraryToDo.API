
namespace LibraryToDo.Api.Models.Db.Models
{
    using Dapper.Contrib.Extensions;
    public class Book
    {
        [ExplicitKey]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
    }
}
