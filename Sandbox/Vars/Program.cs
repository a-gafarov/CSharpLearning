#define VER

namespace Vars
{
    using Newtonsoft.Json;
    using SN = System.Numerics;


    internal class Program
    {
        public static void SayHello(string _hello)
        {
            string hello = _hello;
            if (hello == null)
            {
                hello = _hello;
            }
            Console.WriteLine(hello);
        }

        static void Main(string[] args)
        {
#if VER
//
#else
#error VER is not defined!!!
#endif

#if DEBUG
            Console.WriteLine("Debug mode");
#endif

            int counter;
            string camesCaseVariable = "Привет" +
                "как дела?";
            string codeExample = @"function JS() {
                let a = 1;
            }";
            char ch = 'Ё';

            #region Hello
            string userName = "Akhmet";
            int userAge = 35;
            string result = $"Hello, {userName.ToUpper()} - {userAge}";
            #endregion

            Vars.Program.SayHello(result);

            SN.Complex complex = new();

            Vars.MyClass myClass = new();

            JsonReader reader;

            int x = 100, y;
            var ii = 1;
            var ss = "qwe";
            const int K = 1;
            int @int = 5;
            double e = default(double);
            double e2 = default;

            int i1 = 1;
            long l1 = i1;
            int i2 = (int)l1;
            i2.

        }
    }
}
