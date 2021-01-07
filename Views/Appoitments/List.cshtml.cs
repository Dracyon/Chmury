using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppoitmentWebApp.Data;
using AppoitmentWebApp.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace AppointmentWebApp.Views.Appoitments
{
    public class ListModel : PageModel
    {
		private readonly IConfiguration config;
		private readonly IAppointmentData appointmentData;

		public string Message { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }

		public ListModel(IConfiguration config, IAppointmentData appointmentData)
		{
            this.config = config;
            this.appointmentData = appointmentData;
		}

        public void OnGet()
        {
            Message = config["Message"];
            Appointments = appointmentData.GetAll();
        }
    }
}
