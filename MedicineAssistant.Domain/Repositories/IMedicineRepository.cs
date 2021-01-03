using MedicineAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Domain.Repositories
{
	public interface IMedicineRepository
	{
		Task<string> AddMedicineToUserAsync(string userId, int medicineId);
		IQueryable<Medicine> GetAllMedicines();
		Task<Medicine> GetMedicineByIdAsync(int id);
		IQueryable<Medicine> GetMedicineByTimeSpan(TimeSpan timeSpan);
		IQueryable<Medicine> GetMedicineByName(string name);
		Task UpdateMedicineAsync(Medicine medicine);
		Task RemoveMedicineAsync(int medicineId);
		Task<int> CreateMedicineAsync(Medicine medicine);
	}
}