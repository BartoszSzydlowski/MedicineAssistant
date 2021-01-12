using MedicineAssistant.Application.ViewModel.Account;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace MedicineAssistant.Application.Interfaces
{
	public interface IAccountService
	{
		Task<string> RegisterAsync(AccountDto model);

		Task<bool> AuthenticateUser(AccountDto user);

		Task<string> GenerateJsonWebToken(IConfiguration config, AccountDto user);
	}
}