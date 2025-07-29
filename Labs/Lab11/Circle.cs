namespace Lab11
{
	internal class Circle(string color, int x, int y, int radius) : Shape(color), IScaleable
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;
		public int Radius { get; set; } = radius;

		public override void Draw()
		{
			Console.WriteLine($"Circle. Color: { Color }, Center: <{X},{Y}>, Radius: {Radius}");
		}

		public void MoveBy(int x, int y)
		{
			X += x;
			Y += y;
			Console.WriteLine($"Двигаем центр на {x} по горизонтали и на {y} по Вертикали");
		}

		public void Scale(double factor)
		{
			Radius = (int)Math.Round(Radius * factor);
			Console.WriteLine($"Меняем радиус в {factor} раза");
		}

	}
}
