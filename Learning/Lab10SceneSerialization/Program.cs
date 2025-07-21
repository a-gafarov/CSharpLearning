using GraphObject;

namespace Lab10SceneSerialization
{
    internal class Program
    {
        const string fileName = @"..\..\..\scene.json";
        static void Main(string[] args)
        {
            Scene scene = new Scene();
            scene.DrawScene();
            scene.SaveToFile(fileName);

            scene = new Scene();
            scene.RestoreFromFile(fileName);
            scene.DrawScene();
        }
    }
}
