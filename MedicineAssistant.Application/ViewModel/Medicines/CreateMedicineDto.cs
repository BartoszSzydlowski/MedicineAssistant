using AutoMapper;
using MedicineAssistant.Domain.Models;
using System;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Medicines
{
	public class CreateMedicineDto : IMapFrom<Medicine>
	{
		public string Name { get; set; }
		public string Dose { get; set; }
		public DateTime UseDate { get; set; }
		public string Frequency { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateMedicineDto, Medicine>();
		}
	}
}