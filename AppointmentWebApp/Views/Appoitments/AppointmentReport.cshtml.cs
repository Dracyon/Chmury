using AppointmentWebApp.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace AppointmentWebApp.Views.Appoitments
{
	public class AppointmentReportModel : PageModel
	{
		public List<ReportData> Appointments { get; set; }

		public ActionResult OnGet()
		{
			if (!this.User.HasClaim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administator"))
			{
				TempData["Message"] = "You don't have required claims to view this page!";
				return RedirectToPage("./List");
			}
			try
			{
				HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://appointmentraportapi.azurewebsites.net/appointmentreport/"));
				WebReq.Method = "GET";
				HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

				string jsonString;
				using (Stream stream = WebResp.GetResponseStream())
				{
					StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
					jsonString = reader.ReadToEnd();
				}

				Appointments = JsonConvert.DeserializeObject<List<ReportData>>(jsonString);
				return Page();
			}
			catch (Exception ex)
			{
				return RedirectToPage("./Error");
			}
		}
	}
}
