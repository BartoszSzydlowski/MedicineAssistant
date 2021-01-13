using AutoMapper;
using MedicineAssistant.Domain.Models;
using System;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Medicines
{
	public class GetMedicineDto : IMapFrom<Medicine>
	{
		public string Name { get; set; }
		public string Dose { get; set; }
		public DateTime EntryDate { get; set; }
		public DateTime UseDate { get; set; }
		public string Frequency { get; set; }
		public string UserId { get; set; }
		public int MedicineId { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<GetMedicineDto, Medicine>();
		}
	}
}