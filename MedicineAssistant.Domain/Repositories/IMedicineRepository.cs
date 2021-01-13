using MedicineAssistant.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAssistant.Domain.Repositories
{
	public interface IMedicineRepository
	{
		Task<string> AddMedicineToUserAsync(string userId, UserMedicine medicine);

		IQueryable<Medicine> GetAllMedicines();

		Task<Medicine> GetMedicineByIdAsync(int id);

		IQueryable<Medicine> GetMedicineByName(string name);

		IQueryable<UserMedicine> GetUserMedicines(string userId);

		Task UpdateMedicineAsync(Medicine medicine);

		Task RemoveMedicineAsync(int medicineId);

		Task<int> CreateMedicineAsync(Medicine medicine);
	}
}