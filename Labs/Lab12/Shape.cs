namespace Lab12
{
	internal abstract class Shape(string color = "transparent")
	{
		public string Color { get; set; } = color;

		public abstract void Draw ();
	}
}
