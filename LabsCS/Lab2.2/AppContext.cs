using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
	internal class AppContext : DbContext 
	{
		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }		

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			string? connectionString = Program.config.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.LogTo(s => Debug.WriteLine(s));
			optionsBuilder.UseLazyLoadingProxies(true);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Course>().HasMany(c => c.Teachers).WithMany(t => t.Courses);
			modelBuilder.Entity<Course>().HasMany(c => c.Students).WithMany(s => s.Courses);
		}
	}
}
