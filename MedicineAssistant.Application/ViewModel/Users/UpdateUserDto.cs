using AutoMapper;
using MedicineAssistant.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static MedicineAssistant.Application.Mapping.IMapFrom;

namespace MedicineAssistant.Application.ViewModel.Users
{
	public class UpdateUserDto
	{
		public string Email { get; set; }
		public string Password { get;set; }
	}
}
