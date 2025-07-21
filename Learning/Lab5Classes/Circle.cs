using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Classes
{
    public class Circle
    {
        public int X { get; set; }
        public int Y { get; set; }
        
        private int radius;
        public int Radius 
        { 
            get => radius;
            set
            {
                if (value > 0)
                    radius = value;
                else
                    throw new ArgumentOutOfRangeException($"Circle radius < 0. Value {value}");
            }
        }

        public Circle(int x = 0, int y = 0, int radius = 1)
        {
            X = x;
            Y = y;
            Radius = radius;
        }

        public void Draw() => Console.WriteLine($"Circle ({X}, {Y}) Radius: {Radius}");

        public void MoveBy(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public void Scale(double factor)
        {
            Radius = (int)Math.Round(Radius * factor);
            //            банковское округление!!!
        }
    }
}
