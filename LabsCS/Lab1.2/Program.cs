/* Лабораторная 1.2

- Создать два потока, каждый из которых выводит числа от 1 до 100.
Второй поток должен быть так синхронизирован с первым, чтобы он
начинал вывод своих чисел только после завершения вывода первым
- Запустить потоки на параллельное выполнение
- Убедится что числа второго потока выводятся только после первого
- Провести эксперимент: поменять порядок запуска потоков,
поставив между запусками задержку в 1с
*/

namespace Lab1._2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Thread trA = new(Print100Joined) { Name = "A" };
			Thread trB = new(Print100Joined) { Name = "B" };

			//trA.Start();
			//trB.Start(trA);

			trB.Start(trA);
			Thread.Sleep(1000);
			trA.Start();
		}

		static void Print100()
		{
			for (int i = 0; i < 100; i++)
				Console.WriteLine("Thread {0}: {1,3}", Thread.CurrentThread.Name, i);
		}

		static void Print100Joined(object? obj)
		{
			if (obj is Thread tr)
			{
				/*try
				{
					tr.Join();
				}
				catch (System.Threading.ThreadStateException ex)
				{
					Console.WriteLine($"Ooops: {ex}");
				}*/
				while (tr.ThreadState == ThreadState.Unstarted)
				{
					Thread.Yield();
				}
				tr.Join();
			}

			Print100();
		}
	}
}
