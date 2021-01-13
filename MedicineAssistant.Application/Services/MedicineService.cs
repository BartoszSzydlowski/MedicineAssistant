using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Medicines;
using MedicineAssistant.Application.ViewModel.UserMedicines;
using MedicineAssistant.Domain.Models;
using MedicineAssistant.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Services
{
	public class MedicineService : IMedicineService
	{
		private readonly IMedicineRepository _medicineRepo;
		private readonly IMapper _mapper;

		public MedicineService(IMedicineRepository medicineRepo, IMapper mapper)
		{
			_medicineRepo = medicineRepo;
			_mapper = mapper;
		}

		//public async Task<List<GetMedicineDto>> GetUserMedicines(string userId)
		//{
		//	var item = await _medicineRepo.GetUserMedicines(userId)
		//		.ProjectTo<GetMedicineDto>(_mapper.ConfigurationProvider)
		//		.ToListAsync();
		//	return item;
		//}

		public async Task<List<GetUserMedicinesDto>> GetUserMedicinesAsync(string userId)
		{
			var item = await _medicineRepo.GetUserMedicines(userId)
				.ProjectTo<GetUserMedicinesDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return item;
		}

		public async Task<string> AddMedicineToUserAsync(string userId, AddMedicineToUserDto model)
		{
			var mapped = _mapper.Map<UserMedicine>(model);
			await _medicineRepo.AddMedicineToUserAsync(userId, mapped);
			return userId;
		}

		public async Task<int> CreateMedicineAsync(CreateMedicineDto dto)
		{
			return await _medicineRepo.CreateMedicineAsync(_mapper.Map<Medicine>(dto));
		}

		public async Task DeleteMedicineAsync(int id)
		{
			await _medicineRepo.RemoveMedicineAsync(id);
		}

		public async Task<List<GetMedicineDto>> GetAllMedicinesAsync()
		{
			var item = await _medicineRepo.GetAllMedicines()
				.ProjectTo<GetMedicineDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return item;
		}

		public async Task<GetMedicineDto> GetMedicineByIdAsync(int id)
		{
			var item = await _medicineRepo.GetMedicineByIdAsync(id);
			return _mapper.Map<GetMedicineDto>(item);
		}

		public async Task<List<GetMedicineDto>> GetMedicineByNameAsync(string name)
		{
			var item = await _medicineRepo.GetMedicineByName(name)
				.ProjectTo<GetMedicineDto>(_mapper.ConfigurationProvider)
				.ToListAsync();
			return item;
		}

		public async Task UpdateMedicineAsync(UpdateMedicineDto dto)
		{
			var item = _mapper.Map<Medicine>(dto);
			await _medicineRepo.UpdateMedicineAsync(item);
		}
	}
}