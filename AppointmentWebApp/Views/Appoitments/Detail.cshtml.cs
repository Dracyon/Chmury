using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppoitmentWebApp.Core;
using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AppointmentWebApp.Views.Appoitments
{
	public class DetailModel : PageModel
	{
		private readonly IAppointmentData appointmentData;

		public Appointment Appointment { get; set; }

		public DetailModel(IAppointmentData appointmentData)
		{
			this.appointmentData = appointmentData;
		}
		public IActionResult OnGet(int appointmentId)
		{
			Appointment = appointmentData.GetById(appointmentId);
			if(Appointment == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}
	}
}
