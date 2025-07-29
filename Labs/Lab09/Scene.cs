using System.Collections;

namespace Lab09
{
	internal class Scene(Shape[] shapes) : IEnumerable
	{
		public Shape[] Shapes { get; set; } = shapes;

		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < Shapes.Length; i++)
			{
				Console.WriteLine($"GetEnumerator - {i}");
				yield return Shapes[i];
			}
		}

		public void DrawScene()
		{
			foreach (Shape shape in this)
				shape.Draw();

			//var iter = GetEnumerator();
			//while (iter.MoveNext())
			//	iter.Current.Draw();
		}

		public void ScaleScene(int factor)
		{
			foreach (Shape shape in Shapes)
				if (shape is IScaleable scaleable)
					scaleable.Scale(factor);
		}
	}
}
