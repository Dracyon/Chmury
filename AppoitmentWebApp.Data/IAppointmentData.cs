using AppoitmentWebApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace AppoitmentWebApp.Data
{
	public interface IAppointmentData
	{
		IEnumerable<Appointment> GetAppointmentByName(string name);
		Appointment GetById(int id);


	}

	public class InMemoryAppointmentData : IAppointmentData
	{
		List<Appointment> appointments;
		public InMemoryAppointmentData()
		{
			appointments = new List<Appointment>()
			{
				new Appointment{ AppointmentId = 0, AppointmentName = "First Appoinment", AppointmentDate = DateTime.Now, DoctorId = 0, IsAvaiable = true, LocationId = 0, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 1, AppointmentName = "Regular Apointment", AppointmentDate = DateTime.Now.AddDays(-1), DoctorId = 0, IsAvaiable = true, LocationId = 0, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 2, AppointmentName = "EasyMemorable", AppointmentDate = DateTime.Now.AddDays(1), DoctorId = 0, IsAvaiable = false, LocationId = 0, UserName = "Wojciech"}
	 			};
		}
		public IEnumerable<Appointment> GetAppointmentByName(string name = null)
		{
			return
				string.IsNullOrEmpty(name) ? appointments.
				OrderBy(a => a.AppointmentName) :

				appointments.
				Where(a => a.AppointmentName.StartsWith(name)).
				OrderBy(a => a.AppointmentId);								
		}

		public Appointment GetById(int id)
		{
			return appointments.SingleOrDefault(a => a.AppointmentId == id);
		}
	}
}
