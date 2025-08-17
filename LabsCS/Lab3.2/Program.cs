/* Лабораторная 3.2

- Используя шаблон gRPC в VisualStudio создать проект сервиса доступа к базе данных с курсами
- Добавить EFC контекст (из предыдущих лабораторных) для доступа к данным
- На языке proto описать сервис для доступа к сущности Course EFC контекста
- Создать клиента получения и отображения данных, полученных от сервиса
*/

using Lab3._2.Services;

namespace Lab3._2
{
	public class Program
	{
		internal static IConfiguration config = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddGrpc();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.MapGrpcService<CourseService>();
			app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

			app.Run();
		}
	}
}