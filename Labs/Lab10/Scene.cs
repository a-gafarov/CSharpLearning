using Newtonsoft.Json;
using System.Collections;
using System.Reflection;

namespace Lab10
{
	internal class Scene(Shape[] shapes) : IEnumerable
	{
		public Shape[] Shapes { get; set; } = shapes;

		public IEnumerator GetEnumerator()
		{
			for (int i = 0; i < Shapes.Length; i++)
				yield return Shapes[i];
		}

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

		internal void SaveToFile(string fileName)
		{	
			StreamWriter? streamWriter = null;
			try
			{
				streamWriter = new(fileName);
				foreach (Shape shape in this)
				{
					streamWriter.WriteLine($"{shape.GetType().Name}|{JsonConvert.SerializeObject(shape)}");
				}
			}
			finally
			{
				streamWriter?.Close();
			}
		}

		internal void RestoreFromFile(string fileName)
		{
			StreamReader? streamReader = null;
			Assembly assembly = Assembly.GetExecutingAssembly();			
			string? line;

			Shapes = []; //clean shapes

			try
			{
				streamReader = new(fileName);
				var shapeList = new List<Shape>();
				while ((line = streamReader.ReadLine()) != null)
				{
					Console.WriteLine(line);
					string[] lineParts = line.Split("|", 2);

					if (assembly.GetType($"Lab10.{lineParts[0]}") is Type type)
						if (JsonConvert.DeserializeObject(lineParts[1], type) is Shape newShape)
							shapeList.Add(newShape); //add new shape
				}
				
				Shapes = [.. shapeList];

			}
			finally
			{
				streamReader?.Dispose();
			}
		}
	}
}
