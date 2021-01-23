using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Doctors;
using MedicineAssistant.Web.Token;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class DoctorController : ControllerBase
	{
		private readonly IDoctorService _doctorService;
		//private readonly IHttpContextAccessor _httpContextAccessor;

		public DoctorController(IDoctorService service
			//, IHttpContextAccessor httpContextAccessor
			)
		{
			_doctorService = service;
			//_httpContextAccessor = httpContextAccessor;
		}

		[HttpGet("Find")]
		public async Task<IActionResult> Get()
		{
			//var userId = JwtTokenInfo.GetUserIdFromToken(_httpContextAccessor.HttpContext);
			var userId = JwtTokenInfo.GetUserIdFromToken();
			var doctors = await _doctorService.GetAllDoctorsAsync(userId);
			return new JsonResult(doctors);
		}

		[HttpGet("Find/Id/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var doctor = await _doctorService.GetDoctorByIdAsync(id);
			return new JsonResult(doctor);
		}

		[HttpGet("Find/Name/{name}")]
		public async Task<IActionResult> Get(string name, string userId)
		{
			var doctor = await _doctorService.GetDoctorsBySurnameAsync(name, userId);
			return new JsonResult(doctor);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateDoctorDto doctorModel)
		{
			//var userId = JwtTokenInfo.GetUserIdFromToken(_httpContextAccessor.HttpContext);
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

		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _doctorService.DeleteDoctorAsync(id);
			return Ok();
		}
	}
}