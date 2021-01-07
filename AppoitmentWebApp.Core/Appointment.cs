using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentWebApp.Core
{

	public class Appointment
	{
		public int AppointmentId { get; set; }
		public string AppointmentName { get; set; }
		public DateTime AppointmentDate { get; set; }
		public int DoctorId { get; set; }
		public string UserName { get; set; }
		public int LocationId { get; set; }
		public bool IsAvaiable { get; set; }
	}
}
