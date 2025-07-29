namespace Lab05
{
	internal class Point
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int x = 0, int y = 0)
		{
			this.X = x;
			this.Y = y;
		}

		public void Draw()
		{
			Console.WriteLine($"Представьте точку с координатами {X}, {Y}");
		}

		public void MoveBy(int x, int y)
		{
			this.X += x;
			this.Y += y;
			Console.WriteLine($"Двигаем точку на {x} по горизонтали и на {y} по Вертикали");
		}
	}
}
