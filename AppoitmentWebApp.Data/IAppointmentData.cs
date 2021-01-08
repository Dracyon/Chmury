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
		Appointment Update(Appointment updatedAppointment);
		Appointment Add(Appointment newAppointment);
		int Commit();


	}

	public class InMemoryAppointmentData : IAppointmentData
	{
		List<Appointment> appointments;
		public InMemoryAppointmentData()
		{
			appointments = new List<Appointment>()
			{
				new Appointment{ AppointmentId = 1, AppointmentName = "First Appoinment", AppointmentDate = DateTime.Now, DoctorId = 0, IsAvaiable = true, LocationId = 0, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 2, AppointmentName = "Regular Apointment", AppointmentDate = DateTime.Now.AddDays(-1), DoctorId = 0, IsAvaiable = true, LocationId = 0, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 3, AppointmentName = "EasyMemorable", AppointmentDate = DateTime.Now.AddDays(1), DoctorId = 0, IsAvaiable = false, LocationId = 0, UserName = "Wojciech"}
	 			};
		}

		public Appointment Add(Appointment newAppointment)
		{
			appointments.Add(newAppointment);
			newAppointment.AppointmentId = appointments.Max(a => a.AppointmentId) + 1;
			return newAppointment;
		}

		public int Commit()
		{
			return 0;
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

		public Appointment Update(Appointment updatedAppointment)
		{
			var appointment = appointments.SingleOrDefault(a => a.AppointmentId == updatedAppointment.AppointmentId);
			if (appointment != null)
			{
				appointment.AppointmentName = updatedAppointment.AppointmentName;
				appointment.DoctorId = updatedAppointment.DoctorId;
				appointment.LocationId = updatedAppointment.LocationId;
				appointment.IsAvaiable = updatedAppointment.IsAvaiable;
			}
			return appointment;
		}
	}
}
