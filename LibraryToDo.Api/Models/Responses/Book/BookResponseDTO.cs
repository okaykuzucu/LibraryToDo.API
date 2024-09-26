namespace LibraryToDo.Api.Models.Responses.Book
{
    public class BookResponseDTO
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string Price { get; set; }
        public byte[] Image { get; set; }
    }
}
