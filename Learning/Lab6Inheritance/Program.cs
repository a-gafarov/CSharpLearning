using GraphObject;
namespace Lab6Inheritance
{
    internal class Program
    {
        public static void DrawScene(Shape[] scene)
        {
            foreach (Shape shape in scene) 
                shape.Draw(); // полиморфизм
        }
        static void Main(string[] args)
        {
            Shape[] scene = {
                new Point(10, 20, "red"),
                new Circle(100, 200, 50, "green")
            };

            DrawScene(scene);
        }
    }
}
