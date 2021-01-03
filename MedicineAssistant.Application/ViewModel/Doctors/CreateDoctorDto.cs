using AutoMapper;
using MedicineAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Doctors
{
	public class CreateDoctorDto
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string PhoneNumber { get; set; }
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }

		public void Mapping(Profile profile)
		{
			profile.CreateMap<CreateDoctorDto, Doctor>();
		}
	}
}
