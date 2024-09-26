using System;
using System.Security.Claims;
using LibraryToDo.Helpers;

namespace LibraryToDo.Helpers
{
	public static   class UserClaimsExtention
	{
		public static  UserClaimsExtentionResult GetUserClaims(HttpContext httpContext) {
            var _result = new UserClaimsExtentionResult();
            _result.ClaimsIdentity = (ClaimsIdentity)httpContext.User.Identity;
            var userClaims = httpContext.User.Claims.ToList();
            _result.Claims = userClaims;
            _result.UserId = userClaims?.FirstOrDefault(x => x.Type.Equals("id", StringComparison.OrdinalIgnoreCase))?.Value;

            return
                _result;
        }
	}
}


public  class UserClaimsExtentionResult {

    public  ClaimsIdentity?   ClaimsIdentity { get; set; }
    public  List<Claim>  Claims { get; set; }
    public  string UserId { get; set; }
}
