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
		private readonly IHtmlHelper htmlHelper;

		[BindProperty]
		public Appointment Appointment { get; set; }
		public IEnumerable<SelectListItem> Doctors { get; set; }
		public IEnumerable<SelectListItem> Locations { get; set; }

		public EditAppointmentModel(IAppointmentData appointmentData, IHtmlHelper htmlHelper)
		{
			this.appointmentData = appointmentData;
			this.htmlHelper = htmlHelper;
		}
		public ActionResult OnGet(int? appointmentId)
		{			
			Doctors = new SelectList(appointmentData.GetDoctors().Select(d => d.DoctorName));
			Locations = new SelectList(appointmentData.GetLocations().Select(l => l.LocationName));
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
