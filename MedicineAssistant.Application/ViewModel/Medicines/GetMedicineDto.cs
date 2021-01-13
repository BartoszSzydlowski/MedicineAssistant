using AutoMapper;
using MedicineAssistant.Domain.Models;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Medicines
{
	public class GetMedicineDto : IMapFrom<Medicine>
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<GetMedicineDto, Medicine>();
		}
	}
}