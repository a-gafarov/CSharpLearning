namespace Lab05
{
	internal class Line
	{
		public int X1 { get; set; }
		public int Y1 { get; set; }
		public int X2 { get; set; }
		public int Y2 { get; set; }

		public Line(int x1 = 0, int y1 = 0, int x2 = 0, int y2 = 0)
		{
			this.X1 = x1;
			this.Y1 = y1;
			this.X2 = x2;
			this.Y2 = y2;
		}

		public void Draw()
		{
			Console.WriteLine($"Представьте линию от точки {X1}, {Y1} до точки {X2}, {Y2}");
		}

		public void MoveBy(int x, int y, bool moveStart)
		{
			if (moveStart) {
				this.X1 += x;
				this.Y1 += y;
			} else {
				this.X2 += x;
				this.Y2 += y;
			}
			var pointName = moveStart ? "начало" : "конец";
			pointName += " отрезка";
			Console.WriteLine($"Двигаем {pointName} на {x} по горизонтали и на {y} по Вертикали");
		}

	}
}
