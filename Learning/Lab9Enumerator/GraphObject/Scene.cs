using GraphObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9Enumerator.GraphObject
{
    public class Scene : IEnumerable
    {
        public void DrawScene()
        {
            foreach (Shape shape in this)
                shape.Draw(); // полиморфизм
        }

        public IEnumerator GetEnumerator()
        {
            yield return new Point(10, 20, "red");
            yield return new Circle(100, 200, 50, "green");
        }

    }
}
