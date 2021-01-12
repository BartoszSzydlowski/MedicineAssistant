using System;

namespace MedicineAssistant.Domain.Models
{
	public class UserMedicine
	{
		public string UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public int MedicineId { get; set; }
		public Medicine Medicine { get; set; }
		public DateTime EntryDate { get; set; }
		public DateTime UseDate { get; set; }
		public string Dose { get; set; }
		public string Frequency { get; set; }
	}
}