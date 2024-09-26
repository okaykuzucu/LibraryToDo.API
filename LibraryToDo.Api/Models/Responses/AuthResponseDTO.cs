using System;
using System.Data;
using LibraryToDo.Models.Db.Enums;
//using LibraryToDo.Models.Db.ElasticModels;
using LibraryToDo.Models.Db.Models;

namespace  LibraryToDo.Models.Response
{
    /// <summary>
    /// AuthResponse
    /// </summary>
    public class AuthResponseDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// CompanyId
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Address
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role
        /// </summary>
        public Db.Enums.Role Role { get; set; }

        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }

        public AuthResponseDTO()
        {

        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="user">UserDTO</param>
        /// <param name="token">Token</param>
        public AuthResponseDTO(User user, string token)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Token = token;

        }

        //public AuthResponseDTO(UserDocument userDocument, string token)
        //{
        //    Id = userDocument.User.Id;
        //    Email = userDocument.User.Email;
        //    Password = userDocument.User.Password;
        //    Role = userDocument.User.Role;
        //    Token = token;

        //}
    }
}

