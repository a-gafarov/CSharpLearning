/*Лабораторная 1.6

- В проекте Integral распараллелить метод расчета интеграла используя Parallel и/или другие механизмы (Thread, Task, async).
- Замерить время выполнения однозадачного и многозадачного метода, проверить результат
- Добиться ускорения в многозадачном варианте на многоядерном процессоре (использовать Build Release)
*/

using System.Diagnostics;

const int STEPS = 500_000_000;
const int PARTS = 16;

//const int STEPS = 10;
//const int PARTS = 3;

double Single(Func<double, double> f, double a, double b, int steps = STEPS)
{
	double w = (b - a) / steps;
	double summa = 0d;
	for (int i = 0; i < steps; i++)
	{
		double x = a + i * w + w / 2;
		double h = f(x);
		summa += h * w;
	}
	return summa;
}


double Multi(Func<double, double> f, double a, double b, int steps = STEPS, int parts = PARTS)
{
	double w = (b - a) / steps;
	double summa = 0d;
	int partSteps = steps / parts;

	object lockObject = new();

	ParallelLoopResult plr = Parallel.For(0, parts, p =>
	{
		int from = p * partSteps;
		int to = (p == parts - 1) ? steps : (p + 1) * partSteps;

		double partSumma = 0d;

		for (int i = from; i < to; i++)
		{
			double x = a + i * w + w / 2;
			double h = f(x);
			partSumma += h * w;
		}

		lock (lockObject)
			summa += partSumma;
	});

	return summa;
}




Stopwatch t1 = new();
t1.Start();
double r1 = Single(Math.Sin, 0, Math.PI / 2);
t1.Stop();
Console.WriteLine($"Single result : {r1} Time: {t1.ElapsedMilliseconds}");

Stopwatch t2 = new();
t2.Start();
double r2 = Multi(Math.Sin, 0, Math.PI / 2);
t2.Stop();
Console.WriteLine($"Multi result : {r2} Time: {t2.ElapsedMilliseconds}");


