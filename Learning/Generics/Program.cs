namespace Generics
{
    class ReadonlyStorage<T> //<T,T1>
        where T : IComparable<T>
    {
        public T Data {  get; init; }
        public ReadonlyStorage(T data) => Data = data;

        public bool IsGreater(T data) => Data.CompareTo(data) > 0;

    }
    internal class Program
    {
        static void Swap<T>(ref T a, ref T b)
            where T : struct
        {
            T c = a;
            a = b;
            b = c;
        }
        static void Main(string[] args)
        {
            double a = 2.5, b = 10.5;
            Console.WriteLine($"a = {a} b = {b}");
            //Swap<double>(ref a, ref b);
            Swap(ref a, ref b);
            Console.WriteLine($"a = {a} b = {b}");

            ReadonlyStorage<int> r1 = new ReadonlyStorage<int>( 1);
            ReadonlyStorage<double> r2 = new ReadonlyStorage<double>(1.5);
            
            //ReadonlyStorage<string> r3 = new ReadonlyStorage<string>("abc");
            var r3 = new ReadonlyStorage<string>("abc");

            //var r4 = new ReadonlyStorage<Program>(new Program());

            Console.WriteLine(r1.Data * 2);
            Console.WriteLine(r2.Data);
            Console.WriteLine(r3.Data);

            Console.WriteLine(r2.IsGreater(0.5));
        }
    }
}
