/* Лабораторная 3.2

1. Вывести числа Фибоначчи < 1000
1 1 2 3 5 8 13 21 ... 
*/

using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab03._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Числа Фибоначчи");

            //Console.WriteLine();
            //for (int current = 1, previous = 0; current < 1000; )
            //{
            //    Console.Write($"{current} ");
            //    current += previous;
            //    previous = current - previous;
            //}

            List<int> numbers = new() {1, 1};
            
            int i;
            while ((i = numbers[^1] + numbers[^2]) < 1000) {
                numbers.Add(i);
            }

            Console.Write($"{ string.Join(" ", numbers) } ");
        }
    }
}
