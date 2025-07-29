/*Лабораторная 8

1. Написать метод factorial(int n) 
n! = 1 * 2 * 3 ...n
3! = 1*2*3 = 6
4! = 1*2*3 = 24
0! = 1
2. Выяснить для какого максимального int можно вычислить эту функцию
(включив режим checked b поймав OverflowException)
3*. Реализовать метод factorial(int n) используя BigInteger
*/

using System.Numerics;

namespace Lab08
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Simple Int");
			int i = 0;
			try
			{
				while (true) Console.WriteLine($"Factorial {++i,2} = {Factorial(i)}");
			}
			catch (OverflowException)
			{
				Console.WriteLine($"Factorial overflowed at {i}");
			}

			Console.WriteLine("\nBigInteger");
			BigInteger bi = 0;
			for(;bi < 70;)
				Console.WriteLine($"Factorial {++bi,2} = {Factorial(bi)}");
		}

		static int Factorial(int n) => checked(n > 1 ? n * Factorial(n - 1) : 1);
		static BigInteger Factorial(BigInteger n) => checked(n > 1 ? n * Factorial(n - 1) : 1);
	}
}
