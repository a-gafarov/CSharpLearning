using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Lab3._2
{
	public class AppContext : DbContext
	{
		public DbSet<Course> Courses { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }

		public AppContext() : base()
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			string? connectionString = Program.config.GetConnectionString("DefaultConnection");
			optionsBuilder.UseSqlServer(connectionString);
			optionsBuilder.LogTo(s => Debug.WriteLine(s));
			//optionsBuilder.UseLazyLoadingProxies(true);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Course>()
				.HasMany(c => c.Teachers)
				.WithMany(t => t.Courses)
				.UsingEntity(j => j.ToTable("CourseTeacher"));

			modelBuilder.Entity<Course>()
				.HasMany(c => c.Students)
				.WithMany(s => s.Courses)
				.UsingEntity(j => j.ToTable("CourseStudent"));


			modelBuilder.Entity<Course>().HasData(
				new()
				{
					Id = 1,
					Title = "Основы C#",
					Duration = 40,
					Description = "Базовый курс по C#"
				},
				new()
				{
					Id = 2,
					Title = "Базы данных в C#",
					Duration = 20,
					Description = "Работа с БД в C#"
				},
				new()
				{
					Id = 3,
					Title = "C# - паралелизация",
					Duration = 30,
					Description = "Паралелизация в C#"
				});

			modelBuilder.Entity<Student>().HasData(
				new()
				{
					Id = 1,
					LastName = "Иванов",
					FirstName = "Иван",
					MiddleName = "Ученикович",
					AcceptYear = 2024,
				},
				new()
				{
					Id = 2,
					LastName = "Петров",
					FirstName = "Петр",
					MiddleName = "Ученикович",
					AcceptYear = 2023,
				},
				new()
				{
					Id = 3,
					LastName = "Васечкин",
					FirstName = "Василий",
					MiddleName = "Ученикович",
					AcceptYear = 2022,
				}
			);

			modelBuilder.Entity<Teacher>().HasData(
				new()
				{
					Id = 1,
					LastName = "Андреев",
					FirstName = "Андрей",
					MiddleName = "Учителевич",
					Experience = "Учит основам C#",
				},
				new()
				{
					Id = 2,
					LastName = "Сергеев",
					FirstName = "Сергей",
					MiddleName = "Учителевич",
					Experience = "Доп.курсы по C#: параллельные вычисления и базы данных",
				}
			);

			modelBuilder.Entity("CourseStudent").HasData(
				new { CoursesId = 1, StudentsId = 1 },
				new { CoursesId = 1, StudentsId = 2 },
				new { CoursesId = 2, StudentsId = 2 },
				new { CoursesId = 2, StudentsId = 3 },
				new { CoursesId = 3, StudentsId = 3 }
			);

			modelBuilder.Entity("CourseTeacher").HasData(
				new { CoursesId = 1, TeachersId = 1 },
				new { CoursesId = 2, TeachersId = 2 },
				new { CoursesId = 3, TeachersId = 2 }
			);

		}
	}
}
