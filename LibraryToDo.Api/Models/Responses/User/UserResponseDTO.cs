namespace LibraryToDo.Models.Responses.User
{
    using LibraryToDo.Models.Db.Enums;
    

    public class UserResponseDTO
	{
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}

