/* Лабораторная 5

1. Создать несколько классов для описания графических фигур:
Point, Line, Circle
2. В этих классах сделать необходимы свойства и конструкторы
Point: int X,Y
Line : int X1,Y1, X2,Y2
Circle int X,Y Radius
3. Реализовать в каждом классе метод Draw() (вывести в консоль 
информацию об объекте)
4. Реализовать метод MoveBy() для всех классов. Метод Scale(double) 
для класса Circle.
5. В классе Circle с помощью инкапсуляции сделать так чтобы
Radius всегда был > 0
6. Проверить работу классов, создав в программе объекты этих классов.
*/

using System.Text;

namespace Lab05
{
    internal class Program
    {
        static void Main(string[] args)
        {
			Console.OutputEncoding = Encoding.UTF8;

			Point point = new(1,2);
            point.Draw();
			point.MoveBy(1, -1);
			point.Draw();

			Console.WriteLine();

			Line line = new(2, 3, 4, 5);
			line.Draw();
			line.MoveBy(-2, -3, true);
			line.MoveBy(1, 0, false);
			line.Draw();

			Console.WriteLine();

			Circle circle = new Circle(0, 0, 1);
			circle.Draw();
			circle.MoveBy(1, 1);
			circle.Scale(2);
			circle.Draw();
		}
	}


}
