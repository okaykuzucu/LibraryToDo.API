namespace LibraryToDo.Models.Requests.User
{
    using LibraryToDo.Models.Db.Enums;

    public class UserCreateRequestDTO
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}
