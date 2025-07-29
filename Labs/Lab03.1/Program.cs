/* Лабораторная 3.1

1. Пользователь вводит число ворон на ветке (0..9)
2. Программа должна вывести сообщение 
"На ветке 5 ворон", правильно определив падеж слова 
"ворона"
3. Дополнить программу, чтобы она работала для любого 
числа >= 0
*/

using System.Text;

namespace Lab03._1
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Console.OutputEncoding = Encoding.UTF8;

            Console.WriteLine("Для выхода нажмите ESC");

            const string numberPlease = "Введите целое число";
            Console.WriteLine(numberPlease);

            while (true)
            {
                string? input = ReadLineWithCancel();
                if (input == null) break;

                if (Int32.TryParse(input, out int inputInt))
                    Console.WriteLine($"\nНа ветке {inputInt} {Declense(inputInt, ["ворона", "вороны", "ворон"])}");
                else
                    Console.WriteLine($" Ошибка! {numberPlease}");
            }
        }

        /// <summary>
        ///		Declense russian words
        /// </summary>
        /// <param name="number">Number of smth</param>
        /// <param name="forms">All forms of word ordered as [1 smth, 2 smth, 5 smth]</param>
        /// <returns></returns>
        public static string Declense(int number, string[] forms) => (Math.Abs(number) % 100, Math.Abs(number) % 10) switch
        {
            ( > 10 and < 20, _) => forms[2],
            (_, > 1 and < 5) => forms[1],
            (_, 1) => forms[0],
            (_, _) => forms[2],
        };

        public static string Declense_old(int number, string[] forms)
        {
            int rem100 = Math.Abs(number) % 100;
            int rem10 = rem100 % 10;

            if (rem100 > 10 && rem100 < 20) return forms[2];
            if (rem10 > 1 && rem10 < 5) return forms[1];
            if (rem10 == 1) return forms[0];
            return forms[2];
        }

        //copied from https://stackoverflow.com/questions/31996519/listen-on-esc-while-reading-console-line
        private static string? ReadLineWithCancel()
        {
            string? result = null;

            StringBuilder buffer = new();

            //The key is read passing true for the intercept argument to prevent
            //any characters from displaying when the Escape key is pressed.
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter && info.Key != ConsoleKey.Escape)
            {
                Console.Write(info.KeyChar);
                buffer.Append(info.KeyChar);
                info = Console.ReadKey(true);
            }

            if (info.Key == ConsoleKey.Enter)
            {
                result = buffer.ToString();
            }

            return result;
        }

    }
}
