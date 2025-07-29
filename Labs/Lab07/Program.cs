/* Лабораторная работа 7

1. Вывести список типов текущей сборки
2. Для каждого типа вывести список полей, свойств и методов (с отступом в \t) 
*/

using System.Reflection;
using System.Text;

namespace Lab07
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello, World!");
			Assembly assembly = Assembly.GetExecutingAssembly();
			StringBuilder stringBuilder = new();
			
			foreach (var type in assembly.GetTypes())
			{
				stringBuilder.AppendLine(type.FullName);

				if (type.IsClass)
				{
					stringBuilder.AppendLine($"FullName: {type.FullName}");
					
					stringBuilder.Append("Properties:");					
					foreach (PropertyInfo prop in type.GetProperties())
						stringBuilder.Append(" " + prop.Name);
					stringBuilder.AppendLine();

					stringBuilder.Append("Fields:");
					foreach (FieldInfo field in type.GetFields())
						stringBuilder.Append(" " + field.Name);
					stringBuilder.AppendLine();

					stringBuilder.Append("Methods:");
					foreach (MethodInfo method in type.GetMethods())
						stringBuilder.Append($" {method.Name}{(method.IsAbstract ? "(abstract)" : "") }");
					stringBuilder.AppendLine();

					//foreach (MethodInfo method in type.GetMethods())
					//{
					//	stringBuilder.AppendLine("");
					//	stringBuilder.AppendLine($"Method: {method.Name}");
					//	stringBuilder.AppendLine($"IsAbstract: {method.IsAbstract}");
					//	stringBuilder.AppendLine($"IsAssembly: {method.IsAssembly}");
					//	stringBuilder.AppendLine($"IsDefined: {method.IsDefined}");
					//	stringBuilder.AppendLine($"IsFamily: {method.IsFamily}");
					//	stringBuilder.AppendLine($"IsAssembly: {method.IsAssembly}");
					//	stringBuilder.AppendLine($"IsGenericMethod: {method.IsGenericMethod}");
					//	stringBuilder.AppendLine($"IsGenericMethodDefinition: {method.IsGenericMethodDefinition}");
					//	stringBuilder.AppendLine($"IsConstructedGenericMethod: {method.IsConstructedGenericMethod}");
					//	stringBuilder.AppendLine($"IsVirtual: {method.IsVirtual}");
					//	stringBuilder.AppendLine($"IsStatic: {method.IsStatic}");
					//}
				}

				Console.WriteLine(stringBuilder.ToString());
				stringBuilder.Clear();
			}
		}
	}
}
