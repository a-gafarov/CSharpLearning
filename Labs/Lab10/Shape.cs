namespace Lab10
{
	internal abstract class Shape(string color = "transparent")
	{
		public string Color { get; set; } = color;

		public abstract void Draw ();
	}
}
