using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace MedicineAssistant.Web
{
	public static class JwtTokenInfo
	{
		public static string Token { get; set; }

		public static string GetUserIdFromToken()
		{
			var handler = new JwtSecurityTokenHandler();
			var jsonToken = handler.ReadToken(Token);
			var tokenS = handler.ReadToken(Token) as JwtSecurityToken;
			var userId = tokenS.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub).Value;
			return userId;
		}
	}
}