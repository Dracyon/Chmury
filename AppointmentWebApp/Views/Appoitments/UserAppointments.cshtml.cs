using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AppoitmentWebApp.Core;
using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentWebApp.Views.Appoitments
{
	public class UserAppointmentsModel : PageModel
	{

		public IEnumerable<Appointment> Appointments { get; set; }
		public string Message { get; set; }

		private readonly IAppointmentData appointmentData;

		public UserAppointmentsModel(IAppointmentData appointmentData)
		{
			this.appointmentData = appointmentData;
		}
		public void OnGet()
		{
			Appointments = appointmentData.GetAppointmentForUser(this.User.Identity.Name);

			var check4 = this.User.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administator");
			
			if (!Appointments.Any())
			{
				Message = "You don't have any appointments";
			}
		}
	}
}
