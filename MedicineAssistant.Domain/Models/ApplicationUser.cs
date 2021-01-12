using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace MedicineAssistant.Domain.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public List<UserMedicine> UserMedicines { get; set; }
		public List<Doctor> Doctors { get; set; }
	}
}