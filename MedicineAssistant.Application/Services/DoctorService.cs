using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Doctors;
using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Services
{
	public class DoctorService : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepo;
		private readonly IMapper _mapper;

		public DoctorService(IDoctorRepository doctorRepo, IMapper mapper)
		{
			_doctorRepo = doctorRepo;
			_mapper = mapper;
		}

		public async Task<int> CreateDoctorAsync(CreateDoctorDto dto, string userId)
		{
			return await _doctorRepo.CreateDoctorAsync(_mapper.Map<Doctor>(dto), userId);
		}

		public async Task DeleteDoctorAsync(int id)
		{
			await _doctorRepo.RemoveDoctorAsync(id);
		}

		public async Task<List<GetDoctorDto>> GetAllDoctorsAsync(string userId)
		{
			var item = await _doctorRepo.GetAllDoctors(userId)
				.ProjectTo<GetDoctorDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return item;
		}

		public async Task<GetDoctorDto> GetDoctorByIdAsync(int id)
		{
			var item = await _doctorRepo.GetDoctorByIdAsync(id);
			return _mapper.Map<GetDoctorDto>(item);
		}

		public async Task<List<GetDoctorDto>> GetDoctorsBySurnameAsync(string surname, string userId)
		{
			var item = await _doctorRepo.GetDoctorsBySurname(surname, userId)
				.ProjectTo<GetDoctorDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return item;
		}

		public async Task UpdateDoctorAsync(UpdateDoctorDto dto)
		{
			var item = _mapper.Map<Doctor>(dto);
			await _doctorRepo.EditDoctorAsync(item);
		}
	}
}