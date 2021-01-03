using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using MedicineAssistant.Infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineAssistant.Infrastructure
{
	public static class StartupExtension
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddIdentityCore<ApplicationUser>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<Context>();

			services.AddIdentity<ApplicationUser, IdentityRole>()
				.AddEntityFrameworkStores<Context>();

			services.AddTransient<IDoctorRepository, DoctorRepository>();
			services.AddTransient<IMedicineRepository, MedicineRepository>();
			services.AddTransient<IUserRepository, UserRepository>();

			return services;
		}
	}
}