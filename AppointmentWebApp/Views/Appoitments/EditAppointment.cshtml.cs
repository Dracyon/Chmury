using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppoitmentWebApp.Core;
using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppointmentWebApp.Views.Appoitments
{
	public class EditAppointmentModel : PageModel
	{
		private readonly IAppointmentData appointmentData;

		[BindProperty]
		public Appointment Appointment { get; set; }
		public IEnumerable<SelectListItem> Doctors { get; set; }
		public IEnumerable<SelectListItem> Locations { get; set; }

		public EditAppointmentModel(IAppointmentData appointmentData)
		{
			this.appointmentData = appointmentData;
		}
		public ActionResult OnGet(int? appointmentId)
		{
			if (!this.User.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administator"))
			{
				TempData["Message"] = "You don't have required claims to view this page!";
				return RedirectToPage("./List");
			}
			Doctors = new SelectList(appointmentData.GetDoctors().Select(d => d.DoctorName));
			Locations = new SelectList(appointmentData.GetLocations().Select(l => l.LocationName));
			if (appointmentId.HasValue)
			{
				Appointment = appointmentData.GetById(appointmentId.Value);
			}
			else
			{
				Appointment = new Appointment();
				Appointment.AppointmentDate = DateTime.Now;
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
				Doctors = new SelectList(appointmentData.GetDoctors().Select(d => d.DoctorName));
				Locations = new SelectList(appointmentData.GetLocations().Select(l => l.LocationName));
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
