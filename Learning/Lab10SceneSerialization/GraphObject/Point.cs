namespace GraphObject
{
    public class Point : Shape
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
    }
}
