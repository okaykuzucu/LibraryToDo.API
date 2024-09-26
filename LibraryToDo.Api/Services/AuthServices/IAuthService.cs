namespace LibraryToDo.Services.AuthServices
{
    using LibraryToDo.Models.Requests.Auth;
    using LibraryToDo.Models.Responses.Auth;

    public interface IAuthService
	{
        Task<ResponseDTO> Authenticate(RequestDTO model);

    }
}

