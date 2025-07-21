namespace Lab33SquareRoot
{
    internal class Program
    {
        public static (double X1, double X2, bool HasRoots, bool IsSingleRoot) 
            SolveSquareEquation (double a, double b, double c)
        {
            if (a == 0d) return (0d, 0d, false, false);
            double d = b * b - 4 * a * c;
            if (d < 0d) return (0d, 0d, false, false);
            if (d == 0d)
            {
                double x = -b / (2 * a);
                return (x, x, true, true);
            }
            // d > 0
            double ds = Math.Sqrt(d);
            double x1 = (-b + ds) / (2 * a);
            double x2 = (-b - ds) / (2 * a);
            return (x1, x2, true, false);

        }
        static void Main(string[] args)
        {
            //var r = SolveSquareEquation(1, -2, 1);
            var r = SolveSquareEquation(1, 2, 3);
            //var r = SolveSquareEquation(2, -7, 6);
            if (r.HasRoots)
                if (r.IsSingleRoot)
                    Console.WriteLine($"Single root: {r.X1}");
                else
                    Console.WriteLine($"X1 = {r.X1} X2 = {r.X2}");
            else
                Console.WriteLine("No roots");
        }
    }
}
