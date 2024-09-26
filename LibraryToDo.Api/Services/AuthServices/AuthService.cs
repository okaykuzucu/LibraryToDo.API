using Dapper;
using Microsoft.Extensions.Options;

namespace LibraryToDo.Services.AuthServices
{
    using LibraryToDo.Authorization;
    using LibraryToDo.Constants;
    using LibraryToDo.Helpers;
    using LibraryToDo.Models.Db.Models;
    using LibraryToDo.Models.Db.Context;
    using LibraryToDo.Models.Requests.Auth;
    using LibraryToDo.Models.Responses.Auth;

    public class AuthService : IAuthService
    {
        private IJwtUtils _jwtUtils;
        private readonly AppSettings _appSettings;
        private readonly LibraryToDoDbContext _libraryToDoDbContext;

        public AuthService(
            IJwtUtils jwtUtils,
            IOptions<AppSettings> appSettings,
            LibraryToDoDbContext libraryToDoDbContext)
        {
            _libraryToDoDbContext = libraryToDoDbContext;
            _jwtUtils = jwtUtils;
            _appSettings = appSettings.Value;
        }

        public async Task<ResponseDTO> Authenticate(RequestDTO model)
        {
            var user = new User();

            using (var connection = _libraryToDoDbContext.CreateConnection())
            {
                //var pass = DataSecurityRfcExtention.Encrypt(model.Password);
                var pass = model.Password;
                user = await connection.QueryFirstOrDefaultAsync<User>("Select * From Users Where Email=@Email And Password=@Password",
                    new { Email = model.Email, Password = pass });

                if (user is null)
                    throw new AppException($"{ProjectConstants.LOGIN__ERROR_USER_NOT_FOUND},{ProjectConstants.ERROR_CODE_1}");

                var jwtToken = await Task.Run(() => _jwtUtils.GenerateJwtToken(user));

                return
                    new ResponseDTO(user, jwtToken);
            }
        }
    }
}

