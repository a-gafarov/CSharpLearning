namespace Lab07
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
