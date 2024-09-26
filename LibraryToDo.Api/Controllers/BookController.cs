using AutoMapper;
using LibraryToDo.Api.Models.Db.Models;
using LibraryToDo.Api.Models.Requests.Book;
using LibraryToDo.Api.Models.Responses.Book;
using LibraryToDo.Api.Services.BookServices;
using LibraryToDo.Authorization;
using LibraryToDo.Helpers;
using LibraryToDo.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace LibraryToDo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService, IMapper mapper)
        {
            _bookService=bookService;
            _mapper=mapper;
        }

        [SwaggerOperation("Book create.")]
        [ProducesResponseType(typeof(ApiResponse<List<AppException>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<BookResponseDTO>), (int)HttpStatusCode.OK)]
        [HttpPost("Create")]
        [Authorize]
        public async Task<IActionResult> InsertBook([FromBody] BookCreateRequestDTO model)
        {
            var entity = await _bookService.Insert(_mapper.Map<Book>(model));
            var response = _mapper.Map<BookResponseDTO>(entity);

            return Ok(new ApiResponse<BookResponseDTO>
            {
                Data = response,
                Message = "Success",
                StatusCode = 200,
                Success = true
            });
        }

        [SwaggerOperation("Book create for files.")]
        [ProducesResponseType(typeof(ApiResponse<List<AppException>>), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<BookResponseDTO>>), (int)HttpStatusCode.OK)]
        [HttpPost("CreateBookFiles")]
        [Authorize]
        public async Task<IActionResult> InserFiletBook([FromBody] BookFileCreateRequestDTO model)
        {
            var bookFileResponses = new List<BookResponseDTO>();
            var insertedBooks = await _bookService.InserFile(model);

            foreach (var book in insertedBooks)
            {
                var response = _mapper.Map<BookResponseDTO>(book);
                bookFileResponses.Add(response);
            }

            return Ok(new ApiResponse<List<BookResponseDTO>>
            {
                Data = bookFileResponses,
                Message = "Success",
                StatusCode = 200,
                Success = true
            });
        }


        [SwaggerOperation("Book Delete")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<bool>), (int)HttpStatusCode.OK)]
        [HttpDelete, Route("Delete")]
        [Authorize]
        public async Task<IActionResult> DeleteUser([FromBody] BookRequestDTO requestDTO)
        {
            var _bool = await _bookService.Delete(requestDTO.Id);
            return
                Ok(new ApiResponse<bool>
                {
                    Data = _bool,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("Book update.")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<BookResponseDTO>), (int)HttpStatusCode.OK)]
        [HttpPut("Update")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromBody] BookUpdateRequestDTO model)
        {
            var _t = _mapper.Map<Book>(model);
            var entity = await _bookService.Update(_t);
            var response = _mapper.Map<BookResponseDTO>(entity);

            return
                Ok(new ApiResponse<BookResponseDTO>
                {
                    Data = response,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("Book get by id")]
        [ProducesResponseType(typeof(ApiResponse<Book>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<Book>), (int)HttpStatusCode.OK)]
        [HttpGet("GetById/{Id}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] Guid Id)
        {
            var entity = await _bookService.GetById(Id);
            var response = _mapper.Map<BookResponseDTO>(entity);

            return
                Ok(new ApiResponse<BookResponseDTO>
                {
                    Data = response,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }

        [SwaggerOperation("Book get all")]
        [ProducesResponseType(typeof(ApiResponse<AppException>), (int)System.Net.HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<List<BookResponseDTO>>), (int)HttpStatusCode.OK)]
        [HttpGet("GetAll")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var _tList = await _bookService.GetAll();
            var responseList = _mapper.Map<List<BookResponseDTO>>(_tList);

            return
                Ok(new ApiResponse<List<BookResponseDTO>>
                {
                    Data = responseList,
                    Message = "Success",
                    StatusCode = 200,
                    Success = true
                });
        }
    }
}
