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
			Appointments = appointmentData.GetAppointmentByName(SearchTerm);
		}
	}
}
