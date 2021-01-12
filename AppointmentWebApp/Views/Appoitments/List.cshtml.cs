using AppoitmentWebApp.Core;
using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AppointmentWebApp.Views.Appoitments
{
	public class ListModel : PageModel
	{
		private readonly IConfiguration config;
		private readonly IAppointmentData appointmentData;

		[TempData]
		public string TempMessage { get; set; }
		public string Message { get; set; }
		public IEnumerable<Appointment> Appointments { get; set; }

		[BindProperty(SupportsGet =true)]
		public string SearchTerm { get; set; }

		public ListModel(IConfiguration config, IAppointmentData appointmentData)
		{
			this.config = config;
			this.appointmentData = appointmentData;
		}

		public void OnGet()
		{
			Message = config["Message"];
			if (this.User.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administator"))
			{
				Appointments = appointmentData.GetAppointmentByName(SearchTerm);
			}
			else
			{
				Appointments = appointmentData.GetOnlyOpenAppointments(this.User.Identity.Name);
			}
			
		}
	}
}
