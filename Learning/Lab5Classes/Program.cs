namespace Lab5Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(10, 20);
            Circle circle = new Circle(100, 200, 50);
            
            point.MoveBy(1, 2);
            circle.MoveBy(10, 20);
            circle.Scale(1.5);

            point.Draw();
            circle.Draw();

            
            
        }
    }
}
