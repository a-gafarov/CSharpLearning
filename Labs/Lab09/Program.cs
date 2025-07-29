/*Лабораторная 9

1. Используем классы Point, Circle, Shape, IScaleable
2. Создать класс Scene, в который перенести массив Shape[],
методы DrawScene, Scale
3. Реализовать в классе Scene интерфейс IEnumerable,
использую в методе GetEnumerator yield return для возврата
множества графических объектов.
*/

using System.Text;

namespace Lab09
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			Scene scene = new([
				new Point("red", 1, 1),
				new Circle("blue", 2, 2, 3),
				new Point("white", 2, 1),
				new Point("yellow", 1, 3),
			]);

			scene.DrawScene();
			Console.WriteLine();
			scene.ScaleScene(2);
			Console.WriteLine();
			scene.DrawScene();
		}
	}
}
