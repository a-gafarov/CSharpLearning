/* Лабораторная 4

1. Используя массив параметров командной строки (string[] args) метода Main
извлечь все параметры, преобразовав их в массив чисел.
2. Если параметр не число, вывести его с информацией об ошибке
3. Сложить все числа (параметры) и вывести результат на экран
4. Отсортировать массив чисел и вывести на экран
*/

using System.Linq;
using System.Text;

namespace Lab04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            List<int> okArgs = [];
            int sum = 0;

            foreach (var arg in args)
            {
                if (int.TryParse(arg, out int intArg))
                {
                    okArgs.Add(intArg);
                    sum += intArg;
                }
                else
                    Console.WriteLine($"Введено не число: {arg}");
            }

            Console.WriteLine($"Всего значений: {okArgs.Count}");
            Console.WriteLine($"Сумма значений: {sum}");

            if (okArgs.Count > 0)
            {
                okArgs.Sort();
                Console.WriteLine($"Введеные значения: {string.Join(" ", okArgs)}");
            }
        }
    }
}
