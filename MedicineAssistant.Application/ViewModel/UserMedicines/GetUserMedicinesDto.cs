using System;
using System.Collections.Generic;
using System.Text;

namespace MedicineAssistant.Application.ViewModel.UserMedicines
{
	public class GetUserMedicinesDto
	{
		public string Dose { get; set; }
		public DateTime EntryDate { get; set; }
		public DateTime UseDate { get; set; }
		public string Frequency { get; set; }
		public string UserId { get; set; }
		public int MedicineId { get; set; }
	}
}
