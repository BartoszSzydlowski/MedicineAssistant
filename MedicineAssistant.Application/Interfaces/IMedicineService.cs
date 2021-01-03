using MedicineAssistant.Application.ViewModel.Medicines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Interfaces
{
	public interface IMedicineService
	{
		Task<string> AddMedicineToUserAsync(string userId, int doctorId);
		Task<List<GetMedicineDto>> GetAllMedicinesAsync();
		Task<GetMedicineDto> GetMedicineByIdAsync(int id);
		Task<List<GetMedicineDto>> GetMedicineByNameAsync(string name);
		Task<List<GetMedicineDto>> GetMedicineByTimeSpanAsync(TimeSpan timeSpan);
		Task UpdateMedicineAsync(UpdateMedicineDto dto);
		Task DeleteMedicineAsync(int id);
		Task<int> CreateMedicineAsync(CreateMedicineDto dto);
	}
}