using System.Text;
using static System.Math;

using GraphObject;
using System.Text.Json;

namespace OOP
{
    public partial class Course
    { 
        public string? Teacher { get; set; }

        partial void Validate()
        {
            Console.WriteLine("Validation...");
        }

        public class ResetCounter // nested class - нарушает инкапсуляцию
        {
            public void Reset()
            {
                Course.counter = 0;
            }
        }
    }




    public static class StringExt 
    {
        // extension method
        public static string Capitalize(this string s)
        {
            string[] words = s.Split(' ');
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string word in words)
            {
                if (word.Length > 0)
                    stringBuilder.Append(char.ToUpper(word[0]))
                        .Append(word.Substring(1).ToLower())
                        .Append(' ');
            }
            return stringBuilder.ToString();
        }
    }

    public class Program
    {

        static void Main(string[] args)
        {
            string s = "hello sergey"; // Capitalize(s) == "Hello Sergey"
            Console.WriteLine(StringExt.Capitalize(s));
            Console.WriteLine(s.Capitalize());

            Course.ShowCoursesCounter();
            
            Course c1 = new Course() { Description = "Введение в программирование под .net языке C#"};
            //var c1 = new Course();
            //Course c1 = new ();
            //c1.Title = "Язык C#";
            //c1.Length = 140;
            c1.Length = 40; // call set
            Console.WriteLine(c1.Length); // call get
            //c1.Title = "abc";

            //Course c2 = new Course() { Title = "OOP Patterns", Length = 24 };
            Course c2 = new Course("OOP Patterns", 24) 
                { Description = "Шаблоны объектно-ориентированного программирования"};
            //c2.Title = "OOP Patterns";
            //c2.Length = 24;

            

            c1.Show(); // this == c1
            c2.Show(); // this == c2

            Console.WriteLine(c1.ToString());

            Course.ShowCoursesCounter();
            //c1 = null;
            //GC.Collect();

            // y = sin(log(x*PI));
            double x = 5;
            //double y = Math.Sin(Math.Log(x * Math.PI));
            double y = Sin(Log(x * PI));

            //new Course.ResetCounter().Reset();
            var rc = new Course.ResetCounter();
            rc.Reset();

            Course.ShowCoursesCounter();

            var person = new { Name = "Sergey", Age = 47 };
            
            Console.WriteLine(person);
            Console.WriteLine($"{person.Name} - {person.Age}");

            RemoteCourse rc1 = new RemoteCourse("Creating Services with C#", 40, "specialist.ru");
            rc1.Show(); // RemoteCourse.Show() всегда
            rc1.Connect();

            Course course1 = rc1; // implicit conv ref
            course1.Show(); // RemoteCourse.Show() - полиморфизм (полиморфный вызов метод)

            course1 = c1;

            course1.Show(); // Course.Show() - полиморфизм(полиморфный вызов метод)

            // VMT
            /* virtual (override)
             * Class        Method      Address
             * Course       Show        XXXX (Course.Show() )
             * RemoteCourse Show        YYYY (RemoteCourse.Show())
             */

            //RemoteCourse rc2 = (RemoteCourse)course1; // explict conv ref
            //rc2.Connect();

            //if (course1 is RemoteCourse)
            //{
            //    RemoteCourse rc2 = (RemoteCourse)course1;
            //    rc2.Connect();
            //}

            //if (course1 is RemoteCourse rc2)
            //    rc2.Connect();

            RemoteCourse rc2 = course1 as RemoteCourse;
            //if (rc2 != null) rc2.Connect();
            rc2?.Connect();

            (course1 as RemoteCourse)?.Connect();

            //rc1.Show(); 

            Shape[] scene = {
                new Point(10, 20, "red"),
                new Circle(100, 200, 50, "green")
            };

            DrawScene(scene);

            ScaleScene(scene, 1.5);

            DrawScene(scene);

            Circle circle = new Circle(10,10,10);
            circle.Scale(2);
            IScaleable sc1 = circle;
            sc1.Scale(1.5);
            sc1.Scale2();
            
            circle.Draw();

            Star st = new Star();
            //st.AddOne();
            IMath m = st;
            m.AddOne();
            Console.WriteLine(st.num);
            if (m is Star st2)
                Console.WriteLine(st2.num);

            // Serialization using standart .net library
            Circle crx = new Circle(5, 6, 7, "blue");
            string data = JsonSerializer.Serialize(crx);
            Console.WriteLine(data);
            Circle restoredCircle = JsonSerializer.Deserialize<Circle>(data);
            restoredCircle.Draw();

            Point p1 = new Point(10, 20);
            Point p2 = new Point(1, 2);
            Point p3 = p1 + p2; //  Point.Add(p1, p2); 
            Point p4 = 5 + p1;
            p4 += 10; // p4 = p4 + 10;
            p3.Draw();
            p4.Draw();
            (p1 - p2).Draw();
            (-p1).Draw();
            Point pp1 = new Point(10, 20);
            Point pp2 = new Point(10, 20);
            Console.WriteLine(pp1 == pp2);
            Console.WriteLine(pp1 == null);
            Console.WriteLine(p1 > p2);
            double dist = (double)p1; // p1.Distance - explicit
            //double dist2 = p1; // implicit

            Console.WriteLine(p1[0]);
            Console.WriteLine(p1[1]);

            Console.WriteLine(p1["x"]);
            Console.WriteLine(p1["y"]);
        }
        public static void ScaleScene(Shape[] scene, double factor)
        {
            foreach (Shape shape in scene)
                if (shape is IScaleable sc)
                    sc.Scale(factor); // полиморфизм
                //(shape as IScaleable)?.Scale(factor);
        }

        public static void DrawScene(Shape[] scene)
        {
            foreach (Shape shape in scene)
                shape.Draw(); // полиморфизм
        }
    }

    struct Star : IMath
    {
        public int num;

        public void AddOne() => num++;
    }
    interface IMath
    {
        void AddOne();
    }
}
