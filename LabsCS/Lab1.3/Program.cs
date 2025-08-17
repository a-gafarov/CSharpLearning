/*Лабораторная 1.3

- Создать два потока, которые будут работать параллельно, обрабатывая одно значение типа double
- Первый поток вычисляет значения косинуса, выводит результат и сохраняет его в ту же переменную
- Второй поток вычисляет значения арккосинуса, выводит результат и сохраняет его в ту же переменную
- Потоки нужно синхронизировать таким образом, чтобы они работали в противофазе.
*/

using System.Runtime.CompilerServices;

namespace Lab1._3
{
	internal class Program
	{
		private static readonly int maxLoop = 10;
		private static double calcValue = 1.0 / 3;

		static void Main(string[] args)
		{
			ByMonitor();

			Thread.Sleep(1000);
			Console.WriteLine();

			ByAutoReset();
		}

		static double Calc(bool _isCos, double _calcValue) => _isCos ? Math.Cos(_calcValue) : Math.Acos(_calcValue);

		static void ByMonitor()
		{
			object sync = new();

			ThreadStart delegateFactory(bool isCos) => () =>
			{
				lock (sync)
					for (int i = 0; i < maxLoop; i++)
					{
						calcValue = Calc(isCos, calcValue);
						Console.WriteLine("ByMonitor {0} {1,4} :{2}", isCos ? "Cos  " : "ArCos", i, calcValue);

						Monitor.Pulse(sync);
						if (i != maxLoop - 1)
							Monitor.Wait(sync);
					}

			};

			Thread trCos = new(delegateFactory(true));
			Thread trArCos = new(delegateFactory(false));

			trCos.Start();
			trArCos.Start();
		}

		static void ByAutoReset()
		{
			AutoResetEvent eventCos = new(true);
			AutoResetEvent eventArCos = new(false);

			ThreadStart delegateFactory(bool isCos) => () =>
			{
				AutoResetEvent eventMy = isCos ? eventCos : eventArCos;
				AutoResetEvent eventOther = isCos ? eventArCos : eventCos;

				for (int i = 0; i < maxLoop; i++)
				{
					eventMy.WaitOne();
					calcValue = Calc(isCos, calcValue);

					Console.WriteLine("ByAutoReset {0} {1,4} :{2}", isCos ? "Cos  " : "ArCos", i, calcValue);

					eventMy.Reset();
					eventOther.Set();
				}
			};

			Thread trCos = new(delegateFactory(true));
			Thread trArCos = new(delegateFactory(false));

			trCos.Start();
			trArCos.Start();
		}
	}
}