using AppoitmentWebApp.Core;
using AppoitmentWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentWebApp.Views.Appoitments
{
	public class MarkAppointmnetModel : PageModel
	{
		private readonly IAppointmentData appointmentData;
		[BindProperty]
		public Appointment Appointment { get; set; }
		public IEnumerable<SelectListItem> Doctors { get; set; }
		public IEnumerable<SelectListItem> Locations { get; set; }
		public MarkAppointmnetModel(IAppointmentData appointmentData)
		{
			this.appointmentData = appointmentData;
		}


		public ActionResult OnGet(int? appointmentId)
		{
			Doctors = new SelectList(appointmentData.GetDoctors().Select(d => d.DoctorName));
			Locations = new SelectList(appointmentData.GetLocations().Select(l => l.LocationName));
			if (appointmentId.HasValue)
			{
				Appointment = appointmentData.GetById(appointmentId.Value);
			}
			if (Appointment == null)
			{
				return RedirectToPage("./NotFound");
			}
			return Page();
		}

		public IActionResult OnPost()
		{
			if (Appointment.AppointmentId > 0)
			{
				var appointmentStatus = Appointment.IsAvaiable;
				Appointment = appointmentData.GetById(Appointment.AppointmentId);
				Appointment.IsAvaiable = appointmentStatus;
				Appointment.UserName = this.User.Identity.Name;
				appointmentData.Update(Appointment);
				appointmentData.Commit();
			}


			TempData["TempMessage"] = "Appointment Status Changed!";
			return RedirectToPage("./List");
		}
	}
}
