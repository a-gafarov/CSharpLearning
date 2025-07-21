using System.Reflection;

namespace Reflection
{
    [AttributeUsage(AttributeTargets.Class)]
    public class DeveloperAttribute : System.Attribute
    {
        public string Author { get; init; }
        public DeveloperAttribute(string author)
        { 
            Author = author;
        }
    }
    
    struct Coords 
    { 
        public int X { get; set; }
        public int Y { get; set; }
    }
    [Developer("Sergey")]
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Show() => Console.WriteLine($"{Name} - {Age}");
        
    }


    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly(); // Assembly.LoadFrom()
            foreach (Type t in assembly.GetTypes())
            {
                Console.WriteLine($"{t.Name}  '{t.FullName}' Class: {t.IsClass}");
            }


            Console.WriteLine("*******************");
            Type type = typeof(Person);
                //(new Person()).GetType();
                //Type.GetType("Reflection.Person");
                //typeof(Person);
            PropertyInfo[] ps = type.GetProperties();
            foreach (var pi in ps)
                Console.WriteLine(pi.Name);
            Console.WriteLine("*******************");
            MethodInfo[] ms = type.GetMethods();
            foreach (var mi in ms)
                Console.WriteLine(mi.Name);

            DeveloperAttribute? attr = type.GetCustomAttribute<DeveloperAttribute>();
            if (attr != null)
                Console.WriteLine("Type {0} has attribute with author {1}",
                        type.FullName, attr.Author);



        }
    }
}
