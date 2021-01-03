using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Infrastructure.Repositories
{
	public class DoctorRepository : IDoctorRepository
	{
		private readonly Context _context;
		private readonly UserManager<ApplicationUser> _userManager;

		public DoctorRepository(Context context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		public async Task<int> CreateDoctorAsync(Doctor doctor, string userId)
		{
			var user = await _userManager.FindByIdAsync(userId);
			doctor.UserId = user.Id;
			await _context.AddAsync(doctor);
			await _context.SaveChangesAsync();
			return doctor.Id;
		}

		public async Task<int> EditDoctorAsync(Doctor doctor)
		{
			_context.Update(doctor);
			await _context.SaveChangesAsync();
			return doctor.Id;
		}

		public IQueryable<Doctor> GetAllDoctors(string userId)
		{
			return _context.Doctors.Where(p => p.UserId == userId);
		}

		public async Task<Doctor> GetDoctorByIdAsync(int id)
		{
			return await _context.Doctors.FirstOrDefaultAsync(p => p.Id == id);
		}

		public IQueryable<Doctor> GetDoctorsBySurname(string surname, string userId)
		{
			return _context.Doctors.Where(p => p.Surname == surname && p.UserId == userId);
		}

		public async Task RemoveDoctorAsync(int doctorId)
		{
			var item = await _context.Doctors.Where(p => p.Id == doctorId).SingleOrDefaultAsync();
			_context.Doctors.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}
