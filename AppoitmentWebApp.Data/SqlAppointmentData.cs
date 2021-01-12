using AppointmentWebApp.Data;
using AppoitmentWebApp.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppoitmentWebApp.Data
{
	public class SqlAppointmentData : IAppointmentData
	{
		private readonly AppointmentDbContext db;

		public SqlAppointmentData(AppointmentDbContext db)
		{
			this.db = db;
		}
		public Appointment Add(Appointment newAppointment)
		{
			newAppointment.Doctor = GetSingleDoctor(newAppointment.Doctor.DoctorName);
			newAppointment.Location = GetSingleLocation(newAppointment.Location.LocationName);
			db.Add(newAppointment);
			return newAppointment;
		}

		public int Commit()
		{
			return db.SaveChanges();
		}

		public Appointment Delete(int id)
		{
			var appointment = GetById(id);
			if (appointment != null)
			{
				db.Appointments.Remove(appointment);
			}
			return appointment;
		}

		public IEnumerable<Appointment> GetAppointmentByName(string name)
		{
			var query = db.Appointments.Include(d => d.Doctor).Include(l => l.Location).
				Where(a => a.AppointmentName.StartsWith(name) || string.IsNullOrEmpty(name)).
				OrderBy(a => a.AppointmentName).
				Select(a => a);

			return query;
		}

		public IEnumerable<Appointment> GetAppointmentForUser(string userName)
		{
			var query = db.Appointments.Include(d => d.Doctor).Include(l => l.Location).
				Where(a => a.UserName == userName).
				OrderBy(a => a.AppointmentName).
				Select(a => a);

			return query;
		}

		public Appointment GetById(int id)
		{
			return db.Appointments.Include(d => d.Doctor).Include(l => l.Location).SingleOrDefault(a => a.AppointmentId == id);
		}

		public IEnumerable<Doctor> GetDoctors()
		{
			return db.Doctors.OrderBy(d => d.DoctorName).ToList();
		}

		public IEnumerable<Location> GetLocations()
		{
			return db.Locations.OrderBy(d => d.LocationName).ToList();
		}

		public IEnumerable<Appointment> GetOnlyOpenAppointments(string name)
		{
			var query = db.Appointments.Include(d => d.Doctor).Include(l => l.Location).
				Where(a => a.IsAvaiable == true || a.UserName == name).
				OrderBy(a => a.AppointmentName).
				Select(a => a);

			return query;
		}

		public Doctor GetSingleDoctor(string DoctorName)
		{
			return db.Doctors.SingleOrDefault(d => d.DoctorName == DoctorName);
		}

		public Location GetSingleLocation(string LocationName)
		{
			return db.Locations.SingleOrDefault(l => l.LocationName == LocationName);
		}

		public Appointment Update(Appointment updatedAppointment)
		{
			updatedAppointment.Doctor = GetSingleDoctor(updatedAppointment.Doctor.DoctorName);
			updatedAppointment.Location = GetSingleLocation(updatedAppointment.Location.LocationName);

			var entity = db.Appointments.Attach(updatedAppointment);
			entity.State = EntityState.Modified;
			return updatedAppointment;
		}
	}
}
