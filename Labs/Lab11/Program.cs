/*Лабораторная 11

1. Переделать класс Scene из предыдущих примеров на хранения набора
графических фигур в виде коллекции (List<Shape>).
2. Добавить методы Add(Shape shape) и Clear() классу Scene
*/

using System.Text;

namespace Lab11
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			//Scene scene = new([
			//	new Point("red", 1, 1),
			//	new Circle("blue", 2, 2, 3),
			//	new Point("white", 2, 1),
			//	new Point("yellow", 1, 3),
			//]);

			Scene scene = new();
			scene.Add(new Point("red", 1, 1));
			scene.Add(new Circle("blue", 2, 2, 3));
			scene.Add(new Point("white", 2, 1));
			scene.Add(new Point("yellow", 1, 3));

			Console.WriteLine("After adds:");
			scene.DrawScene();
			
			scene.Clear();
			Console.WriteLine("\nAfter clear:");
			scene.DrawScene();
		}
	}
}
