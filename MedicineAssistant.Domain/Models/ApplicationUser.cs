using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

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