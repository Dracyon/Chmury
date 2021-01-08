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
	public class EditAppointmentModel : PageModel
	{
		private readonly IAppointmentData appointmentData;

		[BindProperty]
		public Appointment Appointment { get; set; }

		public EditAppointmentModel(IAppointmentData appointmentData)
		{
			this.appointmentData = appointmentData;
		}
		public ActionResult OnGet(int? appointmentId)
		{
			if (appointmentId.HasValue)
			{
				Appointment = appointmentData.GetById(appointmentId.Value);
			}
			else
			{
				Appointment = new Appointment();
				//default values
			}
			if (Appointment == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			if (Appointment.AppointmentId > 0)
			{
				appointmentData.Update(Appointment);
			}
			else
			{
				appointmentData.Add(Appointment);
			}
			appointmentData.Commit();
			TempData["Message"] = "Appointment Saved!";
			return RedirectToPage("./Detail", new { appointmentId = Appointment.AppointmentId });
		}
	}
}
