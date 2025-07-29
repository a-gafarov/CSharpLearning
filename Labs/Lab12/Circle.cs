namespace Lab12
{
	internal class Circle(string color, int x, int y, int radius) : Shape(color)
	{
		public int X { get; set; } = x;
		public int Y { get; set; } = y;
		public int Radius { get; set; } = radius;

		public override void Draw()
		{
			Console.WriteLine($"Circle. Color: {Color}, Center: <{X},{Y}>, Radius: {Radius}");
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
		//public static bool operator == (Circle c1, Circle c2) =>
		//	c1.X == c2.X && c1.Y == c2.Y && c1.Radius == c2.Radius && c1.Color == c2.Color;
		//public static bool operator != (Circle c1, Circle c2) => !(c1 == c2);

		public override bool Equals(object? obj)
		{
			if (obj != null && obj.GetType() == typeof(Circle))
			{
				Circle c = (Circle)obj;
				return this.X == c.X && this.Y == c.Y && this.Radius == c.Radius && this.Color == c.Color;
			}
			return false;
		}
		public static bool operator ==(Circle c1, Circle c2) => Object.Equals(c1, c2);
		public static bool operator !=(Circle c1, Circle c2) => !(c1 == c2);
		public override int GetHashCode() => HashCode.Combine(this.X, this.Y, this.Radius, this.Color);
	}
}
