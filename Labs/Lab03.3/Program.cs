/* Лабораторная 3.3

1. Создать метод, который решает квадратное уравнение
a*x^2 + b*x + c = 0
который возвращает четыре значения (в виде кортежа)
X1, X2, HasRoots, IsSingleRoot
2. Написать программу, которая тестирует этот метод.
d = b*b - 4*a*c
d < 0 нет корней
d == 0 x = -b / (2*a)
d > 0 x1 = (-b + Math.Sqrt(d))/(2*a) x2 = (-b - Math.Sqrt(d))/(2*a)
*/

using System.Text;

namespace Lab03._3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			double[,] inputs = {
				{ 1, 2, 3 },
				{ 0, 2, 3 },
				{ 4, 4, 1 },
				{ 1, 3, 1 },
			};

			for (int i = 0; i < inputs.GetLength(0); i++)
			{
				Console.WriteLine($"Уравнение: { inputs[i,0] }*x^2 + { inputs[i,1] }*x + { inputs[i,2] }");
				var (X1, X2, HasRoots, IsSingleRoot) = Solve(inputs[i,0], inputs[i,1], inputs[i,2]);
				if (!HasRoots)			Console.WriteLine("Нет корней");
				else if (IsSingleRoot)	Console.WriteLine($"Один корень: { X1 }");
				else					Console.WriteLine($"Два корня: {X1} и {X2}");
				Console.WriteLine();
			}
		}

		public static (double X1, double X2, bool HasRoots, bool IsSingleRoot) Solve(double a, double b, double c)
		{
			(double X1, double X2, bool HasRoots, bool IsSingleRoot) Result = (0d, 0d, false, false);

			//zero case
			if (a == 0d && b == 0d) return (0d, 0d, false, false);
			if (a == 0d) return (-c / b, 0d, true, true);

			double discr = b * b - 4 * a * c;

			//first case
			if (discr < 0d) return Result;

			Result.HasRoots = true;
			
			//second case
			if (discr == 0d) {
				Result.X1 = -b / (2 * a);
				Result.IsSingleRoot = true;
				return Result;
			}

			//third case
			double discrSqrt = Math.Sqrt(discr);
			Result.X1 = (-b + discrSqrt) / (2 * a);
			Result.X2 = (-b - discrSqrt) / (2 * a);
			return Result;
		}

	}
}
