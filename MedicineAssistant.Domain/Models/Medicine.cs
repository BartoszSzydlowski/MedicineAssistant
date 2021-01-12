using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicineAssistant.Domain.Models
{
	public class Medicine
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }
		public List<UserMedicine> UserMedicines { get; set; }
	}
}