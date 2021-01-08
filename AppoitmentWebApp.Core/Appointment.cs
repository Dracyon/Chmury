using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoitmentWebApp.Core
{
	//IvalidateObject

	public class Appointment
	{
		[Required]
		public int AppointmentId { get; set; }
		[Required,StringLength(80)]
		public string AppointmentName { get; set; }
		public DateTime AppointmentDate { get; set; }
		public int DoctorId { get; set; }
		public string UserName { get; set; }
		public int LocationId { get; set; }
		public bool IsAvaiable { get; set; }
	}
}
