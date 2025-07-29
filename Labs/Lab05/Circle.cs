namespace Lab05
{
    internal class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        private int radius;
        public int Radius {
            get => radius;
            set
            {
                if (value > 0) radius = value;
                else radius = 0;
            }
        }

        public Circle (int x = 0, int y = 0, int radius = 0)
        {
            this.X = x;
            this.Y = y;
            this.Radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Представьте круг радиуса {Radius} с центром в точке {X}, {Y}");
        }

		public void MoveBy(int x, int y)
		{
			this.X += x;
			this.Y += y;
			Console.WriteLine($"Двигаем центр на {x} по горизонтали и на {y} по Вертикали");
		}

		public void Scale(double factor)
		{
			this.Radius = (int)Math.Round(this.Radius * factor);
			Console.WriteLine($"Меняем радиус в {factor} раза");

		}

	}
}
