namespace Operators
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = -10;
            if (n > 0)
            {
                Console.WriteLine("n больше нуля");
                Console.WriteLine("n > 0");
            }
            else 
                if (n > -100)
                    Console.WriteLine("n больше -100, не больше нуля");
                else
                    Console.WriteLine("n НЕ больше нуля");

            int a = 0;
            /*string s;
            if (a == 0)
                s = "ноль";
            else
                s = "не ноль";*/

            string s = (a == 0) ? "ноль" : "не ноль";

            Console.WriteLine(s);

            string name = null;// "Sergey";

            Console.WriteLine(name?.ToUpper());

            //name = (name != null) ? name : "<имя не указано>";
            //if (name == null) name = "<имя не указано>";

            //name = name ?? "<имя не указано>";
            name ??= "<имя не указано>";

            Console.WriteLine(name.ToUpper());

            //Console.WriteLine(((name != null) ? name : "<имя не указано>").ToUpper());
            //Console.WriteLine(( name ?? "<имя не указано>" ).ToUpper());

            a = 5;
            switch (a)
            {
                case -1:
                case 1:
                    Console.WriteLine("один");
                    break; // return
                case 1+1:
                    Console.WriteLine("два");
                    break;
                case 3:
                    Console.WriteLine("три");
                    break;
                default:
                    Console.WriteLine("много");
                    break;
            }

            /*string r;
            switch (a)
            {
                case -1:
                case 1:
                    r = "один";
                    break; // return
                case 2:
                    r = "два";
                    break;
                case 3:
                    r = "три";
                    break;
                default:
                    r = "много";
                    break;
            }*/
            string r = a switch // switch expression
            {
                -1 or 1 => "один",
                2 => "два",
                3 => "три",
                _ => "много"
            };

            Console.WriteLine(r);

            a = 4;
            string c;
            /*switch (a)
            {
                case 1: c = "чашка"; break;
                case 2:
                case 3:
                case 4: c = "чашки"; break;
                default: c = "чашек"; break;

            }*/

            /*switch (a)
            {
                case 1: c = "чашка"; break;
                case int when a >=2 && a <=4: c = "чашки"; break;
                default: c = "чашек"; break;

            }*/

            c = a switch
            {
                1 => c = "чашка",
                >= 2 and <= 4 => "чашки",
                _ => "чашек"
            };

            Console.WriteLine($"{a} {c}");

            //System.Object
            object o = "String";
            o = 5; // boxing
            int k = (int)o; // unboxing

            switch (o) // pattern matching
            {
                // int i = (int)o if o is int
                case int i when i >=0 && i <= 100: Console.WriteLine("o contains int within [0, 100]"); break;
                case int: Console.WriteLine("o contains int"); break;
                case string: Console.WriteLine("o contains string"); break;
                case double: Console.WriteLine("o contains double"); break;
                default: Console.WriteLine("???? o"); break;
            }

            r = o switch// pattern matching in switch expression
            {

                int i when i >= 0 && i <= 100 => "o contains int within [0, 100]",
                int _ => "o contains int",
                string => "o contains string",
                double => "o contains double",
                _ => "???? o"
            };

            Console.WriteLine(r);


        }
    }
}
