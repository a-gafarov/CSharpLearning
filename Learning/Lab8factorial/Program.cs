using System.Numerics;

namespace Lab8factorial
{
    internal class Program
    {
        static BigInteger FactorialNoLimit(int n)
        {
            checked
            {
                BigInteger r = 1;
                for (int k = 1; k <= n; k++)
                    r *= k;
                return r;
            }

        }
        static int Factorial(int n)
        {

            int r = 1;
            for (int k = 1; k <= n; k++)
                r = checked( r * k ); 
            return r;

        }
        static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 100; i++)
                    Console.WriteLine($"{i}! = {Factorial(i)}");
            }
            catch (OverflowException ex)
            { 
                Console.WriteLine("^^ это последнее вычислимое значение факториала для int");
            }

            for (int i = 0; i < 100; i++)
                Console.WriteLine($"{i}! = {FactorialNoLimit(i)}");

        }
    }
}
