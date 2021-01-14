using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace MedicineAssistant.Web.Token
{
	public static class JwtTokenInfo
	{
		//public static string GetUserIdFromToken(HttpContext httpContext)
		//{
		//	var token = httpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
		//	var handler = new JwtSecurityTokenHandler();
		//	var jsonToken = handler.ReadToken(token);
		//	var tokenS = handler.ReadToken(token) as JwtSecurityToken;
		//	var userId = tokenS.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
		//	return userId;
		//}

		public static string Token { get; set; }

		public static string GetUserIdFromToken()
		{
			var handler = new JwtSecurityTokenHandler();
			var jsonToken = handler.ReadToken(Token);
			var decodedToken = handler.ReadToken(Token) as JwtSecurityToken;
			var userId = decodedToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
			return userId;
		}
	}
}