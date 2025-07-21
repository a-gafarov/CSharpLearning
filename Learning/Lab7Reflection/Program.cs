using System.Reflection;
using System;

namespace Lab7Reflection
{
    struct Coords
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public void Show() => Console.WriteLine($"{Name} - {Age}");

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
            Assembly assembly = Assembly.GetExecutingAssembly(); 
            foreach (Type t in assembly.GetTypes())
            {
                Console.WriteLine($"{t.Name}  '{t.FullName}' Class: {t.IsClass}");
                Console.WriteLine("Properties");
                PropertyInfo[] ps = t.GetProperties();
                foreach (var pi in ps)
                    Console.WriteLine($"\t{pi.PropertyType.Name} {pi.Name}");
                Console.WriteLine("Methods");
                MethodInfo[] ms = t.GetMethods();
                foreach (var mi in ms)
                    Console.WriteLine($"\t{mi.ReturnType.Name} {mi.Name}");
            }


        }
    }
}
