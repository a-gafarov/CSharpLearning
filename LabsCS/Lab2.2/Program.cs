/*Лабораторная 2.2

- В существующей базе данных с сущностью Course добавить сущности Teacher и Student
- Установить связи многий-ко-многим между Course и Teacher, и между Course и Student
- Заполнить начальными значениями
- Извлечь информацию о взаимодействии преподаватель и студентов друг с другом (через курсы).
Использовать для этого различные механизмы загрузки (eager, explicit, lazy)
- Включить журналирование и изучить генерируемые SQL запросы при разных механизмах загрузки
*/

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace Lab2._2
{
	internal class Program
	{
		internal static IConfiguration config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		static void Main()
		{
			Console.OutputEncoding = Encoding.UTF8;

			using (AppContext db = new())
			{
				db.Database.EnsureDeleted();
				db.Database.EnsureCreated();

				Course courseCore = new() { Title = "Основы C#", Duration = 40, Description = "Базовый курс по C#" };
				Course courseDB = new() { Title = "Базы данных в C#", Duration = 20, Description = "Работа с БД в C#" };
				Course courseParallel = new() { Title = "C# - паралелизация", Duration = 30 };

				db.Courses.AddRange([
					courseCore,
					courseDB,
					courseParallel,
				]);

				List<Student> students =
				[
					new Student() { LastName = "Иванов", FirstName = "Иван", MiddleName = "Ученикович",
						AcceptYear = 2024, Courses = [courseCore] },
					new Student() { LastName = "Петров", FirstName = "Петр", MiddleName = "Ученикович",
						AcceptYear = 2023, Courses = [courseCore, courseDB] },
					new Student() { LastName = "Васечкин", FirstName = "Василий", MiddleName = "Ученикович",
						AcceptYear = 2022, Courses = [courseDB, courseParallel] },
				];
				db.Students.AddRange(students);

				List<Teacher> teachers = [
					new Teacher() { LastName = "Андреев", FirstName = "Андрей", MiddleName = "Учителевич",
						Experience = "Учит основам C#", Courses = [courseCore] },
					new Teacher() { LastName = "Сергеев", FirstName = "Сергей", MiddleName = "Учителевич",
						Experience = "Доп.курсы по C#: параллельные вычисления и базы данных", Courses = [courseDB, courseParallel] },
				];
				db.Teachers.AddRange(teachers);

				db.SaveChanges();
			}

			static void printTeacherStudent(Dictionary<int, (Teacher MainData, Dictionary<int, Student> Students)> _teacherStudentDict)
			{
				Console.WriteLine();
				foreach (var teacherStudent in _teacherStudentDict)
				{
					var teacher = teacherStudent.Value.MainData;
					Console.WriteLine($"Учитель: {GetPersonName(teacher)}");
					Console.WriteLine($"{teacher.Experience}");
					foreach (var student in teacherStudent.Value.Students)
						Console.WriteLine($"\t{GetPersonName(student.Value)}");
				}

			}
			;
			var teacherStudentDict = new Dictionary<int, (Teacher MainData, Dictionary<int, Student> Students)>();


			Console.WriteLine($"\nEager loading\n");
			using (AppContext db = new())
			{
				teacherStudentDict.Clear();

				var courses = db.Courses
					.Include(c => c.Students)
					.Include(c => c.Teachers)
					.ToList();

				foreach (var course in courses)
					foreach (var teacher in course.Teachers)
					{
						teacherStudentDict.TryAdd(teacher.Id, (teacher, []));
						foreach (var student in course.Students)
							teacherStudentDict[teacher.Id].Students.TryAdd(student.Id, student);
					}

				printTeacherStudent(teacherStudentDict);
			}

			Console.WriteLine($"\nExplicit loading\n");
			using (AppContext db = new())
			{
				teacherStudentDict.Clear();

				var courses = db.Courses.ToList();
				foreach (var course in courses)
				{
					db.Entry(course).Collection(c => c.Teachers).Load();
					db.Entry(course).Collection(c => c.Students).Load();

					foreach (var teacher in course.Teachers)
					{

						teacherStudentDict.TryAdd(teacher.Id, (teacher, []));
						foreach (var student in course.Students)
							teacherStudentDict[teacher.Id].Students.TryAdd(student.Id, student);
					}
				}

				printTeacherStudent(teacherStudentDict);
			}

			Console.WriteLine($"\nLazy loading\n");
			using (AppContext db = new())
			{
				teacherStudentDict.Clear();

				var courses = db.Courses.ToList();
				foreach (var course in courses)
					foreach (var teacher in course.Teachers)
					{
						teacherStudentDict.TryAdd(teacher.Id, (teacher, []));
						foreach (var student in course.Students)
							teacherStudentDict[teacher.Id].Students.TryAdd(student.Id, student);
					}

				printTeacherStudent(teacherStudentDict);
			}

			//_ = Console.ReadLine();
		}

		static string GetPersonName(Person person) => $"{person.LastName} {person.FirstName} {person.MiddleName}";

	}
}
