namespace GraphObject
{
    public class Point : Shape, IComparable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0, string color = DEFAULT_COLOR)
            : base(color)
        {
            X = x;
            Y = y;
        }

        public override void Draw() => Console.WriteLine($"Point ({X}, {Y}) {Color}");
        
        public void MoveBy(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public static Point operator +(Point p1, Point p2) =>
            new Point(p1.X + p2.X, p1.Y + p2.Y);
        
        public static Point operator +(Point p, int k) =>
            new Point(p.X + k, p.Y + k);
        public static Point operator +(int k, Point p) => p + k;

        public static Point operator -(Point p1, Point p2) =>
            new Point(p1.X - p2.X, p1.Y - p2.Y);

        public static Point operator -(Point p) =>
            new Point( -p.X, -p.Y);

        // Методы Equals и GetHashCode() переопределяют вместе
        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y, Color);
        }
        public override bool Equals(object? obj)
        {
            if (obj != null && obj.GetType() == typeof(Point) ) 
            {
                Point p = (Point)obj;
                return (this.X == p.X) && (this.Y == p.Y) && (this.Color == p.Color);
            }
            /*if (obj is Point p)
                return (this.X == p.X) && (this.Y == p.Y);*/

            return base.Equals(obj);
        }

        public static bool operator ==(Point p1, Point p2) => object.Equals(p1, p2);
        public static bool operator !=(Point p1, Point p2) => !(p1 == p2);

        public double Distance
        {
            get => Math.Sqrt(X * X + Y * Y);
        }

        public int CompareTo(Point p)
        {
            if (this.Distance > p.Distance) return 1;
            if (this.Distance < p.Distance) return -1;
            return 0;
        }
        public static bool operator >(Point p1, Point p2) => p1.CompareTo(p2) > 0;
        public static bool operator <(Point p1, Point p2) => p1.CompareTo(p2) < 0;

        public static explicit operator double(Point p) => p.Distance;

        // Только когда оно очевидно
        // public static implicit operator double(Point p) => p.Distance;

        public int this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return X;
                    case 1: return Y;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0: X = value; break;
                    case 1: Y = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }
        }

        public int this[string index]
        {
            get
            {
                switch (char.ToLower(index[0]))
                {
                    case 'x': return X;
                    case 'y': return Y;
                    default: throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (char.ToLower(index[0]))
                {
                    case 'x': X = value; break;
                    case 'y': Y = value; break;
                    default: throw new IndexOutOfRangeException();
                }
            }

        }

    }
}
