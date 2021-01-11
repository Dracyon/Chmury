using AppoitmentWebApp.Core;
using System.Collections.Generic;
using System.Text;


namespace AppoitmentWebApp.Data
{
	public interface IAppointmentData
	{
		IEnumerable<Appointment> GetAppointmentByName(string name);
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
