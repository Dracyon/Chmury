using AppointmentWebApp.Data;
using AppoitmentWebApp.Core;
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
			var query = db.Appointments.
				Where(a => a.AppointmentName.StartsWith(name) || string.IsNullOrEmpty(name)).
				OrderBy(a => a.AppointmentName).
				Select(a => a);
			return query;
		}

		public Appointment GetById(int id)
		{
			return db.Appointments.Find(id);
		}

		public Appointment Update(Appointment updatedAppointment)
		{
			var entity = db.Appointments.Attach(updatedAppointment);
			entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			return updatedAppointment;
		}
	}
}
