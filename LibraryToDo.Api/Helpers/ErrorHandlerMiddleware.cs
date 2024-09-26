using System.Net;
using System.Text.Json;

namespace LibraryToDo.Helpers
{

    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case AppException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                var errorMsgWithCode=error.Message.Split(',');
                string errorCode = string.Empty;
                string errorMessage = string.Empty;
                if(errorMsgWithCode.Length>1)
                {
                    errorCode= errorMsgWithCode[0]; 
                    errorMessage= errorMsgWithCode[1]; 
                }
                else
                {
                    errorMessage=errorMsgWithCode[0];
                }
                 

                var result = JsonSerializer.Serialize(new { Data = "", Message = errorMessage,StatustCode = response.StatusCode, Success = false, ErrorCode = errorCode });
                await response.WriteAsync(result);
            }
        }
    }
}