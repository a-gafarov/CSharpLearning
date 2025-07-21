namespace Lab2Figures
{
    enum GraphObjects { Point, Line, Circle }

    record struct Point(int x, int y)
    {
        public int x = x; public int y = y;
    }

    struct Circle
    {

        public int X;
        public int Y;
        public int Radius;

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public override string ToString()
        {
            return string.Format("Circle ({0}, {1}) Radius: {2}", X, Y, Radius);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            GraphObjects g = GraphObjects.Line;
            Console.WriteLine(g);

            Point p = new(10, 20);
            Console.WriteLine(p);

            Circle c = new(10, 20, 5);
            Console.WriteLine(c);
        }


    }
}
