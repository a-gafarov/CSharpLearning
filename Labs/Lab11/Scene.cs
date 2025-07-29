using System.Collections;

namespace Lab11
{
	internal class Scene : IEnumerable
	{
		//public Shape[] Shapes { get; set; } = shapes;
		private readonly List<Shape> shapes = [];
		public void Add(Shape shape) => shapes.Add(shape);
		public void Clear() => shapes.Clear();

		public IEnumerator GetEnumerator() => shapes.GetEnumerator();

		public void DrawScene()
		{
			foreach (Shape shape in this)
				shape.Draw();
		}

		public void ScaleScene(int factor)
		{
			foreach (Shape shape in this)
				if (shape is IScaleable scaleable)
					scaleable.Scale(factor);
		}
	}
}
