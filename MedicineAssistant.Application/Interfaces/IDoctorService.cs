using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Doctors;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Interfaces
{
	public interface IDoctorService
	{
		Task<List<GetDoctorDto>> GetAllDoctorsAsync(string userId);
		Task<GetDoctorDto> GetDoctorByIdAsync(int id);
		Task<List<GetDoctorDto>> GetDoctorsBySurnameAsync(string surname, string userId);
		Task UpdateDoctorAsync(UpdateDoctorDto dto);
		Task DeleteDoctorAsync(int id);
		Task<int> CreateDoctorAsync(CreateDoctorDto dto, string userId);
	}
}