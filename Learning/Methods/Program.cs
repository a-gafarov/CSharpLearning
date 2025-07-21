using System.Numerics;
using ArrayMinMax = (int Min, int Max, double Average);

namespace Methods
{
    /*readonly record struct MinMax(int Min, int Max)
    {
      
    }*/
    struct VeryLarge
    {
        public long Val1;
        public long Val2;
        public void SetV2(int k)
        {
            Console.WriteLine("SetV2 Invoke");
            this.Val2 = k;
        }
    }
    internal class Program
    {
        // overloading - перегрузка
       /*public static void SayHello()
        {
            Console.WriteLine("Привет!");
        }*/

        public static void SayHello(string name = "Незнакомец" , int age = 18)
        {
            Console.WriteLine($"Привет {name} - {age}!");
        }

        //static double Average(int a, int b)
        //{
        //    double avg = (a + b) / 2d;
        //    return avg;
        //}
        //static double Average(int a, int b)
        //{
        //    return (a + b) / 2d;
        //}
        static double Average(int a, int b) => (a + b) / 2d; // lambda
        static double Average(int a, int b, int c) => (a + b + c) / 3d;
        static double Average(params int[] m)
        {
            long sum = 0L;
            foreach (int k in m) 
                sum += k;
            return (double)sum / m.Length;
        }

        //static MinMax MinMax(int[] m)
        //static ArrayMinMax MinMax(int[] m)
        static (int Min, int Max, double Average) MinMax(int[] m)
        {
            int min = m[0];
            int max = m[0];
            long sum = 0L;
            foreach(int k in m)
            {
                if (k > max) max = k;
                if (k < min) min = k;
                sum += k;
            }
            return (min, max, (double)sum / m.Length); 
        }

        static ref int Min(int[] m)
        {
            ref int min = ref m[0];
            for (int i = 0; i < m.Length; i++)
                if (m[i] < min) min = ref m[i];

            return ref min;
        }

        static void Test1(int a)
        {
            a++;
            Console.WriteLine($"Test 1 a = {a}"); // 11
        }
        static void Test2(ref int a)
        {
            a++;
            Console.WriteLine($"Test 2 a = {a}"); // 11
        }
                
        static void Test3(out int a)
        {
            a = 10;
            Console.WriteLine($"Test 3 a = {a}"); // 10
        }
        static void Test4(/*ref readonly*/ in VeryLarge vl)
        {
            //vl.Val1 = 10;
            //vl.Val2 = 20;
            vl.SetV2(20);
            Console.WriteLine($"Test 4 {vl.Val1} {vl.Val2}"); // 10 20
        }

        const int q = 15; //int.Parse(Console.ReadLine());
        static void Main(string[] args)
        {
            {
                VeryLarge vl;
                vl.Val1 = 100;
                vl.Val2 = 200;
                Test4(in vl);
                Console.WriteLine($"Main 4 {vl.Val1} {vl.Val2}"); // 10 20
            }

            {
                int a = 10;
                Test1(a); // by value
                Console.WriteLine($"Main 1 a = {a}"); // 10
            }
            {
                int a = 10;
                Test2(ref a); // by reference
                Console.WriteLine($"Main 2 a = {a}"); // 11
            }
            {
                int a;
                Test3(out a); // by reference (not initialized var)
                Console.WriteLine($"Main 3 a = {a}"); // 10
            }
            // non-static method call - object method (instance method)
            //Program p = new Program();
            //p.SayHello();

            // static method - function
            Program.SayHello();
            SayHello(age:28);
            SayHello("Сергей");
            SayHello("Андрей", 37);
            SayHello(age : 21, name: "Анна");

            double x = Average(10, 11);
            Console.WriteLine(x);

            Console.WriteLine(Average(10, 11));
            Console.WriteLine(Average(10, 11, 12));
            Console.WriteLine(Average( new int[] { 10, 11, 12, 13 } ));
            Console.WriteLine(Average( 10, 11, 12, 13, 14 ));

            int[] m = { 101, 56, 17, 23 };
            
            var r = MinMax(m); // (int Min, int Max)
            Console.WriteLine(r);
            Console.WriteLine($"Min : {r.Min} Max : {r.Max} Average: {r.Average}");
            Console.WriteLine(r);

            ref int min = ref Min(m);

            foreach (int k in m) Console.Write($"{k} ");
            Console.WriteLine();
            Console.WriteLine(min);
            
            min = 0; // m[2] = 0;
            Console.WriteLine(min);

            foreach (int k in m) Console.Write($"{k} ");
            Console.WriteLine();

            Console.WriteLine(q);
            
        }
    }
}
