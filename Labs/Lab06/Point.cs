using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab06
{
	internal class Point(string color, int x, int y) : Shape(color)
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;

		public override void Draw()
		{
			Console.WriteLine($"Point. Color: {Color}, Coordinates: <{X},{Y}>");
		}
	}
}
