using AutoMapper;
using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MedicineAssistant.Application
{
	public static class StartupExtension
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());

			services.AddTransient<IDoctorService, DoctorService>();
			services.AddTransient<IMedicineService, MedicineService>();
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IAccountService, AccountService>();

			return services;
		}
	}
}