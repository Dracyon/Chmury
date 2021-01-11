using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppoitmentWebApp.Core
{
	public class Location
	{
		[Required]
		public int LocationId { get; set; }
		public string LocationName { get; set; }
		public string LocationAddresss { get; set; }
		public List<Appointment> Appointments { get; set; }
	}
}
