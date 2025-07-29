/*Лабораторная 12

1.Правильно перегрузить операцию сравнения 
для класса Circle
(== !=, реализовать Equals, GetHashCode)
*/

namespace Lab12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Circle c1 = new("red", 1, 2, 3);
			Circle c2 = new("red", 1, 2, 3);
			Circle c3 = new("red", 1, 2, 4);
			Console.WriteLine("c1:");
			c1.Draw();
			Console.WriteLine("\nc2:");
			c2.Draw();
			Console.WriteLine("\nc3:");
			c3.Draw();

			Console.WriteLine();

			Console.WriteLine($"c1 == c2 is {c1 == c2}");
			Console.WriteLine($"c2 == c3 is {c2 == c3}");
			Console.WriteLine($"c3 == c1 is {c3 == c1}");

			Console.WriteLine($"c1.Equals(c2) is {c1.Equals(c2)}");
			Console.WriteLine($"c2.Equals(c3) is {c2.Equals(c3)}");
			Console.WriteLine($"c3.Equals(c1) is {c3.Equals(c1)}");

		}
	}
}
