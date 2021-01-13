using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Medicines;
using MedicineAssistant.Application.ViewModel.UserMedicines;
using MedicineAssistant.Web.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class MedicineController : ControllerBase
	{
		private readonly IMedicineService _service;
		//private readonly IHttpContextAccessor _httpContextAccessor;

		public MedicineController(IMedicineService service
			//, IHttpContextAccessor httpContextAccessor
			)
		{
			_service = service;
			//_httpContextAccessor = httpContextAccessor;
		}

		[HttpGet("Find")]
		public async Task<IActionResult> Get()
		{
			var medicines = await _service.GetAllMedicinesAsync();
			return new JsonResult(medicines);
		}

		[HttpGet("GetUserMedicines")]
		public async Task<IActionResult> GetUserMedicines()
		{
			//var userId = JwtTokenInfo.GetUserIdFromToken(_httpContextAccessor.HttpContext);
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var medicine = await _service.GetUserMedicinesAsync(userId);
			return new JsonResult(medicine);
		}

		[HttpGet("Find/Id/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var medicine = await _service.GetMedicineByIdAsync(id);
			return new JsonResult(medicine);
		}

		[HttpGet("Find/Name/{name}")]
		public async Task<IActionResult> Get(string name)
		{
			var medicines = await _service.GetMedicineByNameAsync(name);
			return new JsonResult(medicines);
		}

		[HttpPost("Create")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Create(CreateMedicineDto dto)
		{
			var medicine = await _service.CreateMedicineAsync(dto);
			return new JsonResult(medicine);
		}

		[HttpPost("Add")]
		public async Task<IActionResult> AddToUser(AddMedicineToUserDto model)
		{
			//var userId = JwtTokenInfo.GetUserIdFromToken(_httpContextAccessor.HttpContext);
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var newMedicine = await _service.AddMedicineToUserAsync(userId, model);
			return new JsonResult(newMedicine);
		}

		[HttpPut]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Update(UpdateMedicineDto dto)
		{
			await _service.UpdateMedicineAsync(dto);
			return new JsonResult(dto.Id);
		}

		[HttpDelete("DeleteFromUser/{id}")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> RemoveFromUser(int id)
		{
			await _service.DeleteMedicineFromUserAsync(id);
			return Ok();
		}

		[HttpDelete("Delete/{id}")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteMedicineAsync(id);
			return Ok();
		}
	}
}