using System;
using LibraryToDo.Models.Db.Enums;

namespace LibraryToDo.Models.Requests.User
{
	public class UserUpdateRequestDTO
	{
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }

    }
}

