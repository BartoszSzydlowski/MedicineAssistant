using MedicineAssistant.Application.Interfaces;
using MedicineAssistant.Application.ViewModel.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicineAssistant.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class UserController : ControllerBase
	{
		private readonly IUserService _service;

		public UserController(IUserService service)
		{
			_service = service;
		}

		[HttpGet("Find")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Get()
		{
			var medicines = await _service.GetAllUsersAsync();
			return new JsonResult(medicines);
		}

		[HttpGet("Find/Id/{id}")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> Get(string id)
		{
			var medicine = await _service.GetUserByIdAsync(id);
			return new JsonResult(medicine);
		}

		[HttpPost("CreateAdmin")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> CreateAdminUser(CreateUserDto dto)
		{
			var medicine = await _service.CreateAdminUserAsync(dto);
			return new JsonResult(medicine);
		}

		[HttpPost("CreateUser")]
		[Authorize(Policy = "AdminRole")]
		public async Task<IActionResult> CreateNormalUser(CreateUserDto dto)
		{
			var medicine = await _service.CreateNormalUserAsync(dto);
			return new JsonResult(medicine);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateUserDto dto)
		{
			await _service.EditUserAsync(dto);
			return new JsonResult(dto);
		}

		[HttpDelete("Delete/{id}")]
		public async Task<IActionResult> Delete(string id)
		{
			await _service.DeleteUserAsync(id);
			return Ok();
		}
	}
}