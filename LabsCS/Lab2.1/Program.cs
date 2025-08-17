using Microsoft.Extensions.Configuration;
using System.Text;

namespace Lab2._1
{
	internal class Program
	{
		internal static IConfiguration config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;


			using (AppContext db = new())
			{
				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();

				List<Course> courses =
				[
					new Course() { Title = "Основы C#", Duration = 40, Description = "Базовый курс по C#" },
					new Course() { Title = "Базы данных в C#", Duration = 20, Description = "Работа с БД в C#" },
					new Course() { Title = "C# - паралелизация", Duration = 30 },
				];
				db.Courses.AddRange(courses);

				Console.WriteLine("Before SaveChanges:");
				PrintCourse(courses);

				db.SaveChanges();

				Console.WriteLine("\nAfter SaveChanges:");
				PrintCourse(courses);
			}

			using (AppContext db = new())
			{
				var courses = from course in db.Courses
							  where course.Duration < 40
							  select course;

				Console.WriteLine("\nCourses with Duration < 40:");
				PrintCourse(courses);
			}

			using (AppContext db = new())
			{
				Course? c1 = db.Courses.FirstOrDefault();
				if (c1 != null)
				{
					c1.Duration += 5;
					db.SaveChanges();
				}

				Console.WriteLine("\nAfter update:");
				PrintCourse(ReadAllCourses());
			}

			//_ = Console.ReadLine();
		}

		static List<Course> ReadAllCourses()
		{
			using AppContext db = new();
			return [.. from course in db.Courses select course];
		}

		static void PrintCourse(Course course)
		{
			Console.WriteLine($"{course.Id}: {course.Title} ({course.Description}) - {course.Duration} часов");
		}

		static void PrintCourse(IEnumerable<Course> courses)
		{
			foreach (var course in courses)
				PrintCourse(course);
		}

	}
}
