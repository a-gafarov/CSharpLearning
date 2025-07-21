using GraphObject;

namespace Lab11SceneCollection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var scene = new Scene();
            scene.Add(new Point(10, 20, "red"));
            scene.Add(new Circle(100, 200, 50, "green"));
            //scene.Draw();
            foreach (var shape in scene) shape.Draw();
        }
    }
}
