namespace Lab13
{
	public delegate void MyEvents(object sender, EventArgs args);
	internal class Circle(string color, int x, int y, int radius) : Shape(color)
	{
		public event MyEvents? OnRadiusChanged;
		public int X { get; set; } = x;
		
		public int Y { get; set; } = y;

		private int radius = radius;
		public int Radius { 
			get
			{
				return radius;
			}
			set
			{
				var args = new EventArgs();
				
				OnRadiusChanged?.Invoke(this, args);

				radius = value;
			}
		}

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

	}
}
