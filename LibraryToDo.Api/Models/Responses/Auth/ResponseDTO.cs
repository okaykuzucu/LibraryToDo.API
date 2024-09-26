namespace LibraryToDo.Models.Responses.Auth
{
    using LibraryToDo.Models.Db.Enums;
    using LibraryToDo.Models.Db.Models;

    public class ResponseDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }


        public ResponseDTO()
        {

        }

        public ResponseDTO(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Surname = user.Surname;
            Email = user.Email;
            Role = user.Role;
            Password = user.Password;
			Token = token;

        }

        //public ResponseDTO(UserDocument userDocument, string token)
        //{
        //    Id = userDocument.User.Id;
        //    Email = userDocument.User.Email;
        //    Role = userDocument.User.Role;
        //    Token = token;
        //}
    }
}