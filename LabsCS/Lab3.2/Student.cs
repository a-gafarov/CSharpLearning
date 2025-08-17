using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab3._2
{
	public class Student : Person
	{
		[Column(TypeName = "char")]
		[StringLength(4)]
		public int? AcceptYear { get; set; }
	}
}
