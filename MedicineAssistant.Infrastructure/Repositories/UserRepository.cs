using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Infrastructure.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly Context _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserRepository(Context context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<bool> CheckPasswordAsync(ApplicationUser user, string password)
		{
			return await _userManager.CheckPasswordAsync(user, password);
		}

		public async Task<string> CreateNormalUserAsync(ApplicationUser user, string password)
		{
			if(user != null)
			{
				await _userManager.CreateAsync(user, password);
				await _userManager.AddToRoleAsync(user, "User");
				await _context.SaveChangesAsync();
				return user.Id;
			}
			return null;
		}

		public async Task<string> CreateAdminUserAsync(ApplicationUser user, string password)
		{
			if (user != null)
			{
				await _userManager.CreateAsync(user, password);
				await _userManager.AddToRoleAsync(user, "Admin");
				await _context.SaveChangesAsync();
				return user.Id;
			}
			return null;
		}

		//public async Task<string> CreateNormalUserAsync(ApplicationUser user)
		//{
		//	if (user != null)
		//	{
		//		await _userManager.CreateAsync(user);
		//		await _userManager.AddToRoleAsync(user, "User");
		//		await _context.SaveChangesAsync();
		//		return user.Id;
		//	}
		//	return null;
		//}

		//public async Task<string> CreateAdminUserAsync(ApplicationUser user)
		//{
		//	if (user != null)
		//	{
		//		await _userManager.CreateAsync(user);
		//		await _userManager.AddToRoleAsync(user, "Admin");
		//		await _context.SaveChangesAsync();
		//		return user.Id;
		//	}
		//	return null;
		//}

		public async Task DeleteUserAsync(string id)
		{
			var user = await _userManager.FindByIdAsync(id);
			if(user != null)
			{
				_context.Remove(user);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<string> EditUserAsync(ApplicationUser user)
		{
			_context.Update(user);
			await _context.SaveChangesAsync();
			return user.Id;
		}

		public IQueryable<ApplicationUser> GetAllUsers()
		{
			return _context.Users;
		}

		public async Task<ApplicationUser> GetUserByEmailAsync(string email)
		{
			return await _userManager.FindByEmailAsync(email);
		}

		public async Task<ApplicationUser> GetUserByIdAsync(string id)
		{
			return await _userManager.FindByIdAsync(id);
		}
	}
}