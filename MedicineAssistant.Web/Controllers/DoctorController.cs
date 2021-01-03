using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Application.ViewModel.Doctors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService _doctorService;

		public DoctorController(IDoctorService service)
		{
			_doctorService = service;
		}

		[HttpGet("Find/Doctor")]
		public async Task<IActionResult> Get()
		{
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var doctors = await _doctorService.GetAllDoctorsAsync(userId);
			return new JsonResult(doctors);
		}

		[HttpGet("Find/Doctor/Id/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			return new JsonResult(doctor);
		}

		[HttpGet("Find/Doctor/Name/{name}")]
		public async Task<IActionResult> Get(string name, string userId)
		{
			var doctor = await _doctorService.GetDoctorsBySurnameAsync(name, userId);
			return new JsonResult(doctor);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateDoctorDto doctorModel)
		{
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var doctor = await _doctorService.CreateDoctorAsync(doctorModel, userId);
			return new JsonResult(doctor);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateDoctorDto dto)
		{
			await _doctorService.UpdateDoctorAsync(dto);
			return new JsonResult(dto.Id);
		}

		[HttpDelete("Delete/Doctor/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _doctorService.DeleteDoctorAsync(id);
			return Ok();
		}


	}
}
