/*Лабораторная 13

1. Добавить в класс Circle событие, которое будет возникать
при изменении Radius: создать свой тип делегата (или использовать
Action<Circle sender, int, int>), добавить поле типа делегат event OnRadiusChanged,
сгенерировать это событие в set свойства Radius
2. В программе подписаться на событие OnRadiusChanged анонимным 
делегатом или лямбда выражением, которые перерисуют Circle метод Draw
*/

using System.Text;

namespace Lab13
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			Circle c = new("blue", 2, 2, 3);
			c.Draw();

			c.OnRadiusChanged += (sender, args) =>
			{
				Console.WriteLine($"Radius changed from {args.OldRadius} to {args.NewRadius}");
				c.Draw();
			};

			c.Scale(2);
		}
	}
}
