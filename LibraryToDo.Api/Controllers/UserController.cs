using AutoMapper;
using LibraryToDo.Api.Services.UserServices;
using LibraryToDo.Helpers;
using LibraryToDo.Models.Db.Models;
using LibraryToDo.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using Dapper;
using LibraryToDo.Models.Requests.User;
using LibraryToDo.Authorization;
using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.Models.Responses.User;

namespace LibraryToDo.Api.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation("User create.")]
        [ProducesResponseType(typeof(ApiResponse<List<AppException>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<UserResponseDTO>), (int)HttpStatusCode.OK)]
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> InsertUser([FromBody] LibraryToDo.Models.Requests.User.UserCreateRequestDTO model)
        {
            var entity = await _userService.Insert(_mapper.Map<User>(model));
            var response = _mapper.Map<LibraryToDo.Models.Responses.User.UserResponseDTO>(entity);

            return Ok(new ApiResponse<LibraryToDo.Models.Responses.User.UserResponseDTO>
            {
                Data = response,
                Message = "Success",
                StatusCode = 200,
                Success = true
            });
        }

        [SwaggerOperation("User Delete")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [HttpDelete, Route("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromBody] UserRequestDTO requestDTO)
        {
            var _bool = await _userService.Delete(requestDTO.Id);
            return
                Ok(new ApiResponse<bool>
                {
                    Data = _bool,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("User update.")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<UserResponseDTO>), (int)HttpStatusCode.OK)]
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateRequestDTO model)
        {
            var _t = _mapper.Map<User>(model);
            var entity = await _userService.Update(_t);
            var response = _mapper.Map<UserResponseDTO>(entity);

            return
                Ok(new ApiResponse<UserResponseDTO>
                {
                    Data = response,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("User get by id")]
        [ProducesResponseType(typeof(ApiResponse<User>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<User>), (int)HttpStatusCode.OK)]
        [HttpGet("GetById/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var entity = await _userService.GetById(Id);
            var response = _mapper.Map<UserResponseDTO>(entity);

            return
                Ok(new ApiResponse<UserResponseDTO>
                {
                    Data = response,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("User get all")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<UserResponseDTO>>), (int)HttpStatusCode.OK)]
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var _tList = await _userService.GetAll();
            var responseList = _mapper.Map<List<UserResponseDTO>>(_tList);

            return
                Ok(new ApiResponse<List<UserResponseDTO>>
                {
                    Data = responseList,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }
    }
}
