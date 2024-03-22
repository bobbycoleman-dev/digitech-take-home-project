using System;
using Microsoft.EntityFrameworkCore;

namespace DigitechTakeHomeProject.Models
{
	public class SqlContext: DbContext
	{
		public SqlContext(DbContextOptions options) : base(options) {}

		public DbSet<Patient> Patients { get; set; }
	}
}

