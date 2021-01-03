using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicineAssistant.Domain.Models
{
	public class Doctor
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }
	}
}