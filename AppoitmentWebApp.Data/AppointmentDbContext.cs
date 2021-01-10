using AppoitmentWebApp.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentWebApp.Data
{
	public class AppointmentDbContext : DbContext
	{
		public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) 
			: base(options)
		{

		}
		public DbSet<Appointment> Appointments { get; set; }
	}
}
