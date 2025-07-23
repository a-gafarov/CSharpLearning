namespace Lab02
{
    enum Geometry{ 
        Point,
        Circle,
        Line,
        Triangle
    }

    struct Point(float x, float y)
    {
        public float x = x;
        public float y = y;
        public override string ToString()
        {
            return $"({x};{y})";
        }
    }

    struct Circle(Point center, float radius)
    {
        public Point center = center;
        public float radius = radius;
        
        public override string ToString()
        {
            return $"Center: {center}, Radius: {radius}";
        }
    }

    struct Line(Point from, Point to)
    {
        public Point from = from;
        public Point to = to;
        
        public override string ToString()
        {
            return $"From: {from}, To: {to}";
        }
        public float Length()
        {
            return (float)Math.Sqrt(Math.Pow(from.x - to.x, 2) + Math.Pow(from.y - to.y, 2));
        }
    }

    struct Triangle(Point a, Point b, Point c)
    {
        public Point a = a;
        public Point b = b;
        public Point c = c;
        public readonly Line ab = new(a, b);
        public readonly Line bc = new(b, c);
        public readonly Line ca = new(c, a);

        public override string ToString()
        {
            return $"A: {a}, B: {b}, C: {c}";
        }
        public float Perimiter()
        {
            return ab.Length() + bc.Length() + ca.Length();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Geometry!");

            Point p = new(3, 4);
            Console.WriteLine("\n" + p.GetType());
            Console.WriteLine(p);
            
            Circle c = new(p, 1);
            Console.WriteLine("\n" + c.GetType());
            Console.WriteLine(c);

            Line l = new(p, new Point(4,5));
            Console.WriteLine("\n" + l.GetType());
            Console.WriteLine(l);
            Console.WriteLine($"Length: {l.Length()}");

            Triangle t = new(new Point(0, 0), new Point(0, 3), new Point(4, 0));
            Console.WriteLine("\n" + t.GetType());
            Console.WriteLine(t);
            Console.WriteLine($"Perimeter: {t.Perimiter()}");
        }
    }
}
