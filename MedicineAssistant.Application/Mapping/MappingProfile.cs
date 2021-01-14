using AutoMapper;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Doctors;
using MedicineAssistant.Application.ViewModel.Medicines;
using MedicineAssistant.Application.ViewModel.UserMedicines;
using MedicineAssistant.Application.ViewModel.Users;
using MedicineAssistant.Domain.Models;

namespace MedicineAssistant.Application.Mapping
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<CreateDoctorDto, Doctor>().ReverseMap();
			CreateMap<Doctor, GetDoctorDto>().ReverseMap();
			CreateMap<UpdateDoctorDto, Doctor>().ReverseMap();

			CreateMap<CreateMedicineDto, Medicine>().ReverseMap();
			CreateMap<Medicine, GetMedicineDto>().ReverseMap();
			CreateMap<UpdateMedicineDto, Medicine>().ReverseMap();

			CreateMap<UserMedicine, AddMedicineToUserDto>().ReverseMap();
			CreateMap<UserMedicine, GetMedicineDto>().ReverseMap();
			CreateMap<UserMedicine, UpdateUserMedicinesDto>().ReverseMap();
			CreateMap<UserMedicine, GetUserMedicinesDto>().ReverseMap();

			CreateMap<CreateUserDto, ApplicationUser>().ReverseMap();
			CreateMap<ApplicationUser, GetUserDto>().ReverseMap();
			CreateMap<UpdateUserDto, ApplicationUser>().ReverseMap();
			CreateMap<AccountDto, ApplicationUser>().ReverseMap();
		}
	}
}