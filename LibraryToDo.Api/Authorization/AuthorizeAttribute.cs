using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using LibraryToDo.Models.Db.Enums;
using LibraryToDo.Constants;
using LibraryToDo.Api.Services.UserServices;

namespace LibraryToDo.Authorization
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private readonly IList<Role> _roles;

        public AuthorizeAttribute(params Role[] roles)
        {
            _roles = roles ?? Array.Empty<Role>();
        }

        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();
            if (allowAnonymous) return;

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
            {
                context.Result = new JsonResult(new
                {
                    Data = "",
                    StatusCode = 401,
                    Message = ProjectConstants.AUTH__UNAUTHORIZED_TOKEN_NOT_NULL,
                    Success = false
                });

                await Task.CompletedTask;
                return;
            }
            var _userClaims = context.HttpContext.User.Claims.ToList();
            if (!_userClaims.Any())
            {
                context.Result = new JsonResult(new
                {
                    Data = "",
                    StatusCode = 401,
                    Message = ProjectConstants.AUTH__UNAUTHORIZED_TOKEN_EXPIRED_1,
                    Success = false
                });

                await Task.CompletedTask;
                return;
            }

            var userId = _userClaims?.FirstOrDefault(x => x.Type.Equals("id", StringComparison.OrdinalIgnoreCase))?.Value;

            if (userId == null)
            {
                context.Result = new JsonResult(new
                {
                    Data = "",
                    StatusCode = 401,
                    Message = ProjectConstants.AUTH__UNAUTHORIZED_TOKEN_EXPIRED_2,
                    Success = false
                });

                await Task.CompletedTask;
                return;
            }

            //var newId = Guid.TryParse(userId, out Guid result);
            Guid guidUserId = Guid.Parse(userId);

            var userServiceInstance = context.HttpContext.RequestServices.GetService(typeof(IUserService)) as IUserService;
            var user = await Task.Run(() => userServiceInstance?.GetById(guidUserId));
            context.Result = new JsonResult(new
            {
                Data = "",
                StatusCode = 401,
                Message = ProjectConstants.AUTH__UNAUTHORIZED_TOKEN_EXPIRED,
                Success = false
            });

            await Task.CompletedTask;
            return;
        }
    }
}