using MedicineAssistant.Application.ViewModel.Account;
using MedicineAssistant.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
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
