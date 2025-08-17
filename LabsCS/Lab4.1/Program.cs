using System.Reflection;

namespace Lab4._1
{
	internal class Program
	{
		static void Main(string[] args)
		{

			Assembly lib = Assembly.LoadFrom("Lab4.1Library.dll");
			Console.WriteLine($"lib: {lib}");

			foreach (var type in lib.GetTypes())
			{
				if (type.IsClass && type.IsPublic)
				{
					Console.WriteLine($"Class: {type.Name}");
					foreach (var property in type.GetProperties()) {
						//if (property.)
							Console.WriteLine($"\tProperty: {property.Name}, type: {property.PropertyType.Name}");
					}
					Console.WriteLine();
				}
			}
			;


		}
	}
}
