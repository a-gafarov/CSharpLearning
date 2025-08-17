using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4._1Library
{
	public class Student : Person
	{
		[Column(TypeName = "char")]
		[StringLength(4)]
		public int? AcceptYear { get; set; }
	}
}
