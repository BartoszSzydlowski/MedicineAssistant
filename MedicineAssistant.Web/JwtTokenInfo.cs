using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
