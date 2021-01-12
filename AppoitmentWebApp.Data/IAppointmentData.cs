using AppoitmentWebApp.Core;
using System.Collections.Generic;


namespace AppoitmentWebApp.Data
{
	public interface IAppointmentData
	{
		IEnumerable<Appointment> GetAppointmentByName(string name);
		IEnumerable<Appointment> GetAppointmentForUser(string userName);
		Appointment GetById(int id);
		Appointment Update(Appointment updatedAppointment);
		Appointment Add(Appointment newAppointment);
		Appointment Delete(int id);
		IEnumerable<Doctor> GetDoctors();
		Doctor GetSingleDoctor(string DoctorName);
		IEnumerable<Location> GetLocations();
		Location GetSingleLocation(string LocationName);
		int Commit();
	}
}
