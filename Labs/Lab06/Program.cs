/*Лабораторная 6

Описать графическую сцену, состояющую из разнотипных графических фигур 
(в виде массив)
1. Создать абстрактный класс Shape. Сделать там свойство string Color,
абстрактная Draw(), конструктор.
2. Сделать классы Point, Line, Circle наследниками Shape, реализовав в них
метод Draw и правильно вызвать конструктор родителя.
3. В программе создать массив графических фигур Shape[], добавив в него 
разнотипный фигуры.
4. Сделать метод DrawScene(Shape[]), который в цикле перебирает графические
фигуры и для каждой фигуры вызовет полиморфный метод Draw();
*/

namespace Lab06
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");

			Shape[] shapes = {
				new Point("red", 1, 1),
				new Line("green", -1, 0, 1, 0),
				new Circle("blue", 2, 2, 3),
			};

			DrawScene(shapes);
		}

		public static void DrawScene(Shape[] shapes)
		{
			foreach (Shape shape in shapes)
				shape.Draw();
		}
	}
}
