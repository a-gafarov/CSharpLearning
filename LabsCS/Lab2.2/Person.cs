using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
	public class Person
	{
		public int Id { get; set; }
		public string? LastName { get; set; }
		public string? FirstName { get; set; }
		public string? MiddleName { get; set; }
		public int? Age { get; set; }
		public virtual List<Course> Courses { get; set; } = [];

	}
}
