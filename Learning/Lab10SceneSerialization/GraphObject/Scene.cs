using GraphObject;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GraphObject
{
    public class Scene
    {
        private Shape[] shapes;

        public Scene() 
        {
            shapes = new Shape[] {
                new Point(10, 20, "red"),
                new Circle(100, 200, 50, "green")
            };

        }

        public void DrawScene()
        {
            foreach (var shape in shapes)
                shape.Draw();
        }

        public void SaveToFile(string fileName)
        {
            string s = JsonConvert.SerializeObject(shapes);
            File.WriteAllText(fileName, s);
        }

        public void RestoreFromFile(string fileName)
        {
            JObject[] objects = JsonConvert.DeserializeObject<JObject[]>(
                File.ReadAllText(fileName)); // JObject

            shapes = new Shape[objects.Length];
            for (int i = 0; i < objects.Length; i++)
            { 
                JObject o = objects[i];
                string typeName = "GraphObject." + 
                    o.Property( "ShapeType").Value.ToString();
                //Console.WriteLine(typeName);
                Type t = Type.GetType(typeName);
                shapes[i] = (Shape)o.ToObject(t);
            }
                
        }
    }
}
