using MedicineAssistant.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineAssistant.Infrastructure
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder builder)
		{
			var userRoleId = Guid.NewGuid().ToString();
			var adminRoleId = Guid.NewGuid().ToString();
			var defaultUserId = Guid.NewGuid().ToString();

			var hasher = new PasswordHasher<ApplicationUser>();

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "Admin",
					Id = adminRoleId
				}
			);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "User",
					Id = userRoleId
				}
			);

			builder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Email = "bbartek311@gmail.com",
					PasswordHash = hasher.HashPassword(null, "test"),
					UserName = "bbartek311@gmail.com",
					NormalizedEmail = "bbartek311@gmail.com",
					NormalizedUserName = "bbartek311@gmail.com",
					Id = defaultUserId
				}
			);

			builder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string>
				{
					RoleId = adminRoleId,
					UserId = defaultUserId
				}
			);

			//builder.Entity<IdentityUserRole<string>>().HasData(
			//	new IdentityUserRole<string>
			//	{
			//		RoleId = defaultUserId,
			//		UserId = userId
			//	}
			//);
		}
	}
}
