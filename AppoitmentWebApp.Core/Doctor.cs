using System;
using System.Collections.Generic;
using System.Text;

namespace AppoitmentWebApp.Core
{
	public class Doctor
	{
		public int DoctorId { get; set; }
		public string DoctorName { get; set; }
		public DoctorTypes DoctorType { get; set; }
	}
}
