using System;

namespace LibraryToDo.Models.Request
{
    /// <summary>
    /// Login DTO
    /// </summary>
	public class AuthRequestDTO
	{

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///Password
        /// </summary>
        public string Password { get; set; }
    }
}

