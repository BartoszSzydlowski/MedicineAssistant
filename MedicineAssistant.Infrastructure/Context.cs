using MedicineAssistant.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MedicineAssistant.Infrastructure
{
	public class Context : IdentityDbContext<ApplicationUser>
	{
		public DbSet<Doctor> Doctors { get; set; }
		public DbSet<UserMedicine> UserMedicine { get; set; }
		public DbSet<Medicine> Medicines { get; set; }

		public Context(DbContextOptions<Context> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<UserMedicine>().HasKey(key => new { key.UserId, key.MedicineId });
			builder.Entity<UserMedicine>().HasOne(x => x.Medicine).WithMany(x => x.UserMedicines).HasForeignKey(x => x.MedicineId);
			builder.Entity<UserMedicine>().HasOne(x => x.ApplicationUser).WithMany(x => x.UserMedicines).HasForeignKey(x => x.UserId);

			builder.Entity<ApplicationUser>().HasMany(x => x.Doctors).WithOne(x => x.User).OnDelete(DeleteBehavior.Cascade);
			//builder.Entity<ApplicationUser>().HasMany(x => x.Doctors).WithOne(x => x.User);
			builder.Entity<Doctor>().HasOne(x => x.User).WithMany(x => x.Doctors).OnDelete(DeleteBehavior.Cascade);
			//builder.Entity<Doctor>().HasOne(x => x.User).WithMany(x => x.Doctors);

			builder.Seed();
		}
	}
}