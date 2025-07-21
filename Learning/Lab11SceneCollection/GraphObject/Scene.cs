using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphObject
{
    public class Scene : IEnumerable<Shape>
    {
        private IList<Shape> shapes = new List<Shape>();

        public void Add(Shape shape) => shapes.Add(shape);
        public void Clear() => shapes.Clear();

        public void Scale(double factor)
        {
            foreach (Shape shape in shapes)
                if (shape is IScaleable sc)
                    sc.Scale(factor);
        }

        public void Draw()
        {
            foreach (Shape shape in shapes)
                shape.Draw();
        }

        public IEnumerator<Shape> GetEnumerator()
        {
            return shapes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
