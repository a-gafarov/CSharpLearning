/*Лабораторная 10

1. Использовать классы Point, Circle, Shape, Scene из пердыдущих проектов
2. Сделать метод сохранения сцены в формате JSON используя библиотеку Newtonsoft.JSON
3*. Сделать метод загрузки сцены из формата JSON
*/
namespace Lab10
{
	internal class Program
	{
		const string fileName = @"..\..\..\scene.json";
		static void Main(string[] args)
		{
			Console.WriteLine("Write phase");
			Scene scene = new([
				new Point("red", 1, 1),
				new Circle("blue", 2, 2, 3),
				new Point("white", 2, 1),
				new Point("yellow", 1, 3),
			]);
			scene.DrawScene();
			scene.SaveToFile(fileName);

			Console.WriteLine("\nRead phase");
			scene = new Scene([]);
			scene.RestoreFromFile(fileName);
			scene.DrawScene();

		}
	}
}
