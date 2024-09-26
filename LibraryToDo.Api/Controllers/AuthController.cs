using LibraryToDo.Authorization;
using LibraryToDo.Constants;
using LibraryToDo.Models.Requests.Auth;
using LibraryToDo.Models.Response;
using LibraryToDo.Models.Responses;
using LibraryToDo.Services.AuthServices;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LibraryToDo.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IAuthService authService)
        {
            _logger = logger;
            _authService = authService;
        }

        [SwaggerOperation(Summary = MetodDescription.LOGIN)]
        [ProducesResponseType(typeof(ApiResponse<List<string>>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<AuthResponseDTO>), (int)HttpStatusCode.OK)]
        [HttpPost, Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] RequestDTO request)
        {
            var user = await _authService.Authenticate(request);
           
            return
                Ok(new ApiResponse<bool>
                {
                    Data = user,
                    Message = ProjectConstants.LOGIN__SUCCESS,
                    StatusCode = 200,
                    Success = true
                });

        }
    }
}
