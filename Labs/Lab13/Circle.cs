namespace Lab13
{
	public delegate void MyEvents(object sender, MyEventArgs args);

	public class MyEventArgs : EventArgs
	{
		public int OldRadius { get; set; }
		public int NewRadius { get; set; }
	}

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
				var args = new MyEventArgs();
				args.NewRadius = value;
				args.OldRadius = radius;

				radius = value;
				
				OnRadiusChanged?.Invoke(this, args);
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
			Console.WriteLine($"Меняем радиус в {factor} раза");
			Radius = (int)Math.Round(Radius * factor);
		}

	}
}
