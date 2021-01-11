using AppoitmentWebApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AppoitmentWebApp.Data
{
	public class InMemoryAppointmentData : IAppointmentData
	{
		List<Appointment> appointments;
		public InMemoryAppointmentData()
		{
			appointments = new List<Appointment>()
			{
				new Appointment{ AppointmentId = 1, AppointmentName = "First Appoinment", AppointmentDate = DateTime.Now, Doctor = new Doctor {DoctorId = 1, DoctorName = "MrNice", DoctorType = DoctorTypes.Magician, Appointments = new List<Appointment>() }, IsAvaiable = true, Location = new Location{LocationId = 1, LocationName = "Warszawa", LocationAddresss = "Better 32/31", Appointments = new List<Appointment>() }, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 2, AppointmentName = "Regular Apointment", AppointmentDate = DateTime.Now.AddDays(-1), Doctor = new Doctor {DoctorId = 2, DoctorName = "MrNotNice", DoctorType = DoctorTypes.Dentis, Appointments = new List<Appointment>() }, IsAvaiable = true, Location = new Location{LocationId = 2, LocationName = "Wroclaw", LocationAddresss = "Wrose 32/31", Appointments = new List<Appointment>() }, UserName = "Wojciech"},
				new Appointment{ AppointmentId = 3, AppointmentName = "EasyMemorable", AppointmentDate = DateTime.Now.AddDays(1), Doctor = new Doctor {DoctorId = 3, DoctorName = "MrSuperNice", DoctorType = DoctorTypes.Special, Appointments = new List<Appointment>() }, IsAvaiable = false, Location = new Location{LocationId = 3, LocationName = "Lodz", LocationAddresss = "Better 334/311", Appointments = new List<Appointment>() }, UserName = "Wojciech"}
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

		public Appointment Delete(int id)
		{
			var appointment = appointments.FirstOrDefault(a => a.AppointmentId == id);
			if (appointment != null)
			{
				appointments.Remove(appointment);
			}
			return appointment;
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
				appointment.Doctor = updatedAppointment.Doctor;
				appointment.Location = updatedAppointment.Location;
				appointment.IsAvaiable = updatedAppointment.IsAvaiable;
			}
			return appointment;
		}
	}
}
