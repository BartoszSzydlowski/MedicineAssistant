using MedicineAssistant.Application.ViewModel.Medicines;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Interfaces
{
	public interface IMedicineService
	{
		Task<string> AddMedicineToUserAsync(string userId, AddMedicineToUserDto model);

		Task<List<GetMedicineDto>> GetAllMedicinesAsync();

		Task<GetMedicineDto> GetMedicineByIdAsync(int id);

		Task<List<GetMedicineDto>> GetMedicineByNameAsync(string name);

		Task<List<GetMedicineDto>> GetUserMedicines(string userId);

		Task UpdateMedicineAsync(UpdateMedicineDto dto);

		Task DeleteMedicineAsync(int id);

		Task<int> CreateMedicineAsync(CreateMedicineDto dto);
	}
}