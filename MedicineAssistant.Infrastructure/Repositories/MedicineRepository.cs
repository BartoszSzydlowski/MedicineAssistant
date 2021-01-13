using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAssistant.Infrastructure.Repositories
{
	public class MedicineRepository : IMedicineRepository
	{
		private readonly Context _context;

		public MedicineRepository(Context context)
		{
			_context = context;
		}

		public IQueryable<UserMedicine> GetUserMedicines(string userId)
		{
			return _context.UserMedicine.Where(p => p.UserId == userId);
		}

		public async Task<string> AddMedicineToUserAsync(string userId, UserMedicine medicine)
		{
			medicine.UserId = userId;
			medicine.EntryDate = DateTime.Now;
			await _context.AddAsync(medicine);
			await _context.SaveChangesAsync();
			return userId;
		}

		public async Task<int> CreateMedicineAsync(Medicine medicine)
		{
			await _context.AddAsync(medicine);
			await _context.SaveChangesAsync();
			return medicine.Id;
		}

		public async Task UpdateMedicineAsync(Medicine medicine)
		{
			_context.Update(medicine);
			await _context.SaveChangesAsync();
		}

		public IQueryable<Medicine> GetAllMedicines()
		{
			return _context.Medicines;
		}

		public async Task<Medicine> GetMedicineByIdAsync(int id)
		{
			return await _context.Medicines.FirstOrDefaultAsync(p => p.Id == id);
		}

		public IQueryable<Medicine> GetMedicineByName(string name)
		{
			return _context.Medicines.Where(p => p.Name == name);
		}

		public async Task RemoveMedicineAsync(int medicineId)
		{
			var item = await _context.Medicines.Where(p => p.Id == medicineId).SingleOrDefaultAsync();
			_context.Medicines.Remove(item);
			await _context.SaveChangesAsync();
		}

		public async Task RemoveMedicineFromUserAsync(int medicineId)
		{
			var item = await _context.UserMedicine.Where(p => p.MedicineId == medicineId).SingleOrDefaultAsync();
			_context.UserMedicine.Remove(item);
			await _context.SaveChangesAsync();
		}
	}
}