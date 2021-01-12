using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Services
{
	public class AccountService : IAccountService
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly UserManager<ApplicationUser> _userManager;

		public AccountService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public async Task<string> RegisterAsync(AccountDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user != null)
			{
				return "User exists";
			}

			ApplicationUser newUser = new ApplicationUser()
			{
				Email = model.Email,
				UserName = model.Email
			};

			var result = await _userManager.CreateAsync(newUser, model.Password);
			var roleResult = await _userManager.AddToRoleAsync(newUser, "User");

			if (!result.Succeeded || !roleResult.Succeeded)
			{
				return "Error registering";
			}

			return "Successfully registered";
		}

		public async Task<bool> AuthenticateUser(AccountDto model)
		{
			var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, true, lockoutOnFailure: false);
			return result.Succeeded;
		}

		public async Task<string> GenerateJsonWebToken(IConfiguration config, AccountDto model)
		{
			var user = await _userManager.FindByNameAsync(model.Email);
			var roles = await _userManager.GetRolesAsync(user);

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Email)
			};

			ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Token");
			claimsIdentity.AddClaims(roles.Select(role =>
				new Claim(ClaimTypes.Role, role)
			));

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(
				config["Jwt:Issuer"],
				config["Jwt:Issuer"],
				claimsIdentity.Claims,
				expires: DateTime.Now.AddMinutes(20),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
		}
	}
}