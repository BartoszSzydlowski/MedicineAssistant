using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Web.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountController : ControllerBase
	{
		private readonly IConfiguration _config;
		private readonly IAccountService _accountService;

		public AccountController(IConfiguration config, IAccountService accountService)
		{
			_config = config;
			_accountService = accountService;
		}

		[AllowAnonymous]
		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] AccountDto user)
		{
			IActionResult response = Unauthorized();
			var success = await _accountService.AuthenticateUser(user);

			if (success)
			{
				var tokenString = await _accountService.GenerateJsonWebToken(_config, user);
				response = Ok(new { token = tokenString });
				JwtTokenInfo.Token = tokenString;
			}
			return response;
		}

		[AllowAnonymous]
		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] AccountDto user)
		{
			var newUser = await _accountService.RegisterAsync(user);
			return Ok(newUser);
		}
	}
}