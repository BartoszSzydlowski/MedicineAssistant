using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Medicines;
using MedicineAssistant.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	public class MedicineController : ControllerBase
	{
		private readonly IMedicineService _service;

		public MedicineController(IMedicineService service)
		{
			_service = service;
		}

		[HttpGet("Find/Medicine")]
		public async Task<IActionResult> Get()
		{
			var medicines = await _service.GetAllMedicinesAsync();
			return new JsonResult(medicines);
		}

		[HttpGet("Find/Medicine/Id/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var medicine = await _service.GetMedicineByIdAsync(id);
			return new JsonResult(medicine);
		}

		[HttpGet("Find/Medicine/Name/{name}")]
		public async Task<IActionResult> Get(string name)
		{
			var medicines = await _service.GetMedicineByNameAsync(name);
			return new JsonResult(medicines);
		}

		//[HttpGet("Find/Mecicine/TimeSpan/{timeSpan}")]
		//public async Task<IActionResult> Get(TimeSpan timeSpan)
		//{
		//	var medicines = await _service.GetMedicineByTimeSpanAsync(timeSpan);
		//	return new JsonResult(medicines);
		//}

		[HttpPost("Create")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Create(CreateMedicineDto dto)
		{
			var medicine = await _service.CreateMedicineAsync(dto);
			return new JsonResult(medicine);
		}

		[HttpPost("Add")]
		public async Task<IActionResult> AddToUser(int medicineId)
		{
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var medicine = await _service.AddMedicineToUserAsync(userId, medicineId);
			return new JsonResult(medicine);
		}

		[HttpPut]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Update(UpdateMedicineDto dto)
		{
			await _service.UpdateMedicineAsync(dto);
			return new JsonResult(dto.Id);
		}

		[HttpDelete("Delete/Mecicine/{id}")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteMedicineAsync(id);
			return Ok();
		}
	}
}