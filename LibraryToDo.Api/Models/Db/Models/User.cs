namespace LibraryToDo.Models.Db.Models
{
    using Dapper.Contrib.Extensions;
    using LibraryToDo.Models.Db.Enums;

    public class User
    {

        [ExplicitKey]
        public Guid Id { get; set; }= Guid.NewGuid();

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }


        public User() {
        
        }

    }

}

