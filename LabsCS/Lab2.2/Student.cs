using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2._2
{
	public class Student : Person
	{
		[Column(TypeName = "char")]
		[StringLength(4)]
		public int AcceptYear { get; set; }
	}
}
