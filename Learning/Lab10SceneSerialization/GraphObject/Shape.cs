using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphObject
{
    public abstract class Shape
    {
        public string ShapeType { get; init; }
        
        public const string DEFAULT_COLOR = "black";
        public string Color { get; set; }
        public Shape(string color = DEFAULT_COLOR)
        {
            Color = color;
            ShapeType = this.GetType().Name;
        }

        public abstract void Draw();
        
    }
}
