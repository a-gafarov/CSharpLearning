#define VER

using System.Numerics;
using Newtonsoft.Json;
using SCS = System.Collections.Specialized;

namespace Vars
{
    // VALUE TYPE
    //struct Coords
    //{
    //    public int x;
    //    public int y;

    //    public Coords(int x, int y)
    //    {
    //        this.x = x;
    //        this.y = y;
    //    }

    //    /*public override string ToString()
    //    {
    //        return $"({x}, {y})";
    //    }*/

    //    public override string ToString() => $"({x}, {y})";
    //}

    record struct Coords(int x, int y)
    {
        public int x = x;
        public int y = y;
    }

    //readonly record struct Coords(int x, int y)
    //{
    //    public readonly int x = x;
    //    public readonly int y = y;
    //}

    ref struct Point(int x, int y) // ref - структура может размещаться только в стеке
    {
        public int x = x;
        public int y = y;
    }
    struct ColorPoint
    {
        public Coords Coords;
        public string Color;

        public ColorPoint(int x, int y, string color)
        {
            Coords.x = x;
            Coords.y = y;
            Color = color;

        }

        public void MoveBy(int dx, int dy)
        {
            Coords.x += dx;
            Coords.y += dy; 
        }

        public override string ToString() => $"{Coords} Color : {Color}";

    }
    class MyNamespace
    {

    }

    //enum Colors { Red, Green, Blue}
    //             0      1    2

    enum Colors:byte { Red = 0, Green = 100, Blue = 200}

    internal class Program
    {
        public static void SayHello() 
        {
            Console.WriteLine("Hello!");
        }
        
        static void Main(string[] args)
        {
            {
                JsonReader reader;

                Program p1;
                Vars.Program p2;
                string ss1;
                String ss2;
                System.String ss3;
                System.Numerics.Complex c;
                Complex c1;
                SCS.NameValueCollection nvc;
                global::MyNamespace.MyClass mc1;


#if VER
                // ...
#else
#error VER is not defined
#endif

#if DEBUG
                Console.WriteLine("Отладочный режим");
#endif


                // camel notation
                //System.String
                string perfferedUserColor;
                int counter;
                int _a, b1;
                string привет = "Привет";
                string scripts = @"function js(){

            }";
                Console.WriteLine(scripts);
                string path = @"c:\cs-0414\Vars";
                Console.WriteLine(path);

                char ch = 'a';
                int Int; // bad practice
                         //int Counter;
                SayHello();

                #region Hello
                string userName = "Sergey";
                int age = 47;
                // Hello, Sergey - 47!
                //string result = "Hello, " + userName + " - " + age + "!";
                string result = $"Hello, {userName.ToUpper()} - {age}!";
                Console.WriteLine(result);
                #endregion

                int i = 40;

                Console.WriteLine(i);

                // float point
                double d = 2.5;
                double d2 = 2d;
                double d3 = 2e8;

                float f = 2.5f;

                // fixed point
                decimal dec = 2.5M;

                bool ab1 = true;
                bool ab2 = false;

                string s1 = null;

                Program p = null;

                //Int32
                //String

                unsafe
                {
                    int l = 123;
                    int* pl = &l;
                }

                //System.Int32
                //Int32
                // int
                //UInt32
                //uint
                //Int64
                //long
                //Int128
                //System.Double
                //double

                int x = 100 + i;
                short q, w;

                var h = "hello"; // string h = "hello";
                var k = 20; // int k = 20

                //k = k + 1;
                //k += 1;
                // suffix (postfix)
                k = 20;
                int t = k++; // k--;
                             // k == 21
                             // t == 20

                k = 20;
                // prefix
                t = ++k; // --k;
                         // k == 21
                         // t == 21

                const int K = 10 + 10;
                const int M = 10 + K;
                int @int = 5;
                double e = default; // default(double)

                int i1 = 20;
                long l1 = i1; // implicit conv
                int i2 = (int)l1; // explicit conv - operator cast, overflow



                char ch2 = '\u002F'; // UTF-16
                ch2 = 'A';
                Console.WriteLine(x);
                Console.WriteLine(@int);

            }
            {
                int q = 10; // 4 byte
                Console.WriteLine(sizeof(int));
                // nullable type - value
                int? qn = null; // (int Value, bool HasValue = false)
                if (qn != null)
                //if (qn.HasValue)
                    Console.WriteLine(qn.Value);
                else
                    Console.WriteLine("No value");

                int q2 = qn ?? 0;

                string userName = null; //"Sergey";
                Console.WriteLine((userName ?? "no value").ToUpper());

                //if (qn == null) qn = 17;
                qn ??= 17;
                Console.WriteLine(qn);

                //BigInteger bi1 = 2024;
                //BigInteger bi2 = BigInteger.Pow(bi1, 2024);
                //Console.WriteLine(bi2);


            }
            {
                Colors color = Colors.Green;

                Console.WriteLine(color);
                Console.WriteLine(((int)color));

            }
            {
                Coords c1 = new(10, 20); // ctor call
                //Coords c1 = new Coords(10, 20);
                //c1.x = 10;
                //c1.y = 20;


                Console.WriteLine(c1.x);
                Console.WriteLine(c1.y);
                Console.WriteLine(c1);
                Coords c2 = c1;// value type - copy value
                c1.x++;
                Console.WriteLine(c1);
                Console.WriteLine(c2);

                ColorPoint cp = new(23, 45, "green");
                Console.WriteLine(cp);
                cp.MoveBy(17, 15);
                Console.WriteLine(cp);

                Point point = new(11, 22);
                Console.WriteLine($"Point: {point.x}, {point.y}");
            }
            {
                Console.Write("Введите ваше имя: ");
                string name = Console.ReadLine();
                Console.Write("Введите ваш возраст: ");
                int age = int.Parse(Console.ReadLine());
                Console.WriteLine($"{name} - {age}");

            }




        }
    }
}

