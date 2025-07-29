namespace Lab11
{
	internal class Point(string color, int x, int y) : Shape(color)
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;

		public override void Draw()
		{
			Console.WriteLine($"Point. Color: {Color}, Coordinates: <{X},{Y}>");
		}

		public void MoveBy(int x, int y)
		{
			X += x;
			Y += y;
			Console.WriteLine($"Двигаем точку на {x} по горизонтали и на {y} по Вертикали");
		}
	}
}
