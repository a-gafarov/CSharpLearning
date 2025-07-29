namespace Lab06
{
	internal class Circle(string color, int x, int y, int radius) : Shape(color)
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;
		public int Radius { get; set; } = radius;

		public override void Draw()
		{
			Console.WriteLine($"Circle. Color: { Color }, Center: <{X},{Y}>, Radius: {Radius}");
		}

	}
}
