using MedicineAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineAssistant.Domain.Repositories
{
	public interface IDoctorRepository
	{
		Task<int> CreateDoctorAsync(Doctor doctor, string userId);
		IQueryable<Doctor> GetAllDoctors(string userId);
		Task<Doctor> GetDoctorByIdAsync(int id);
		IQueryable<Doctor> GetDoctorsBySurname(string surname, string userId);
		Task<int> EditDoctorAsync(Doctor doctor);
		Task RemoveDoctorAsync(int doctorId);
	}
}