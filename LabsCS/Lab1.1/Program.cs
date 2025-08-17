/* Лабораторная 1.1

- Создать два потока, каждый из которых принимает
на вход 2 параметра: начальное и конечное число (диапазон).
- Каждый из потоков должен вывести числа в указанном диапазоне.
- Запустить потоки на параллельное выполнение
- Использовать любой из вариантов передачи параметров
*/

namespace Lab1._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Thread tr1 = new(PrintRange) { Name = "A" };
			Thread tr2 = new(PrintRange) { Name = "B" };

			//var myThread = new MyThread() { From = 1, To = 12 };
			//Thread tr3 = new(myThread.Delegate) { Name = "C" };
			Thread tr3 = new((new MyThread() { From = 201, To = 299 }).PrintRange) { Name = "C" };

			tr1.Start(new Range(1, 99));
			tr2.Start(new Range(101, 199));
			tr3.Start();
		}

		record class Range(int From, int To);

		static void PrintRange(object? input)
		{
			if (input is Range range)
				for (int i = range.From; i < range.To; i++)
					Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
		}
	}

	public class MyThread {
		public int From { get; init; }
		public int To { get; init; }
		public void PrintRange()
		{
			for (int i = From; i < To; i++)
				Console.WriteLine($"{Thread.CurrentThread.Name}: {i}");
		}
	}


}
