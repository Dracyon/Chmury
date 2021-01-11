using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoitmentWebApp.Core
{
	public class Doctor
	{
		[Required]
		public int DoctorId { get; set; }
		public string DoctorName { get; set; }
		public DoctorTypes DoctorType { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
