namespace LibraryToDo.Api.Models.Requests.Book
{
    public class BookUpdateRequestDTO
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
    }
}
