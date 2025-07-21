// add <CETCompat>false</CETCompat> to csproj file for .net 9


namespace HelloWorld2
{
    /// <summary>
    /// Main program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        /// <param name="args">Command line parameters</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!"); // строчный комментарий

            {
                Console.Write("Привет, ");
                Console.WriteLine("ужасный мир!");
            }

            /*
              Блочный комментарий
              // строчный комментарий
              
             */
        }
    }
}
