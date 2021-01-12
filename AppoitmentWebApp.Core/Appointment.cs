using System;
using System.ComponentModel.DataAnnotations;

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
		public Doctor Doctor { get; set; }
		public string UserName { get; set; }
		public Location Location { get; set; }
		public bool IsAvaiable { get; set; }
	}
}
