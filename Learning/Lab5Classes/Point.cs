namespace Lab5Classes
{
    public class Point 
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public void Draw() => Console.WriteLine($"Point ({X}, {Y})");
        
        public void MoveBy(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }
    }
}
