namespace Lab06
{
	internal class Line(string color, int x1, int y1, int x2, int y2) : Shape(color)
	{
		public int X1 { get; set; } = x1;
		public int Y1 { get; set; } = y1;
		public int X2 { get; set; } = x2;
		public int Y2 { get; set; } = y2;

		public override void Draw()
		{
			Console.WriteLine($"Line. Color: {Color}, From <{X1},{Y1}> to <{X2},{Y2}>");
		}

	}
}
