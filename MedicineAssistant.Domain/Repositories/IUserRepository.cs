using MedicineAssistant.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineAssistant.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<string> CreateNormalUserAsync(ApplicationUser user, string password);

		Task<string> CreateAdminUserAsync(ApplicationUser user, string password);

		IQueryable<ApplicationUser> GetAllUsers();

		Task<ApplicationUser> GetUserByIdAsync(string id);

		Task<ApplicationUser> GetUserByEmailAsync(string email);

		Task<string> EditUserAsync(ApplicationUser user);

		Task DeleteUserAsync(string id);

		Task<bool> CheckPasswordAsync(ApplicationUser user, string password);
	}
}