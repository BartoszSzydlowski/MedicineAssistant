using AutoMapper;
using MedicineAssistant.Domain.Models;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Medicines
{
	public class CreateMedicineDto : IMapFrom<Medicine>
	{
		public string Name { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateMedicineDto, Medicine>();
		}
	}
}