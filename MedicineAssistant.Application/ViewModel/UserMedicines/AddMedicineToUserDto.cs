using System;

namespace MedicineAssistant.Application.ViewModel.UserMedicines
{
	public class AddMedicineToUserDto
	{
		public int MedicineId { get; set; }
		public string Dose { get; set; }
		public string Frequency { get; set; }
		public DateTime UseDate { get; set; }
	}
}