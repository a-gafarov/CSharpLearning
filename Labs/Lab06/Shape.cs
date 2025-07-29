using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab06
{
	internal abstract class Shape(string color = "transparent")
	{
		public string Color { get; set; } = color;

		public abstract void Draw ();
	}
}
