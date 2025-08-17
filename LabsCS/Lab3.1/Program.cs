/*Лабораторная работа 3.1

- Используя шаблон WebAPI в VisualStudio создать проект сервиса доступа к базе данных с курсами
- Добавить EFC контекст (из предыдущих лабораторных) для доступа к данным
- Создать сервисы для удаленного доступа ко всем видам сущностей (включить поддержку OpenAPI через Swagger)
- Протестировать с помощью внешней программы получившиеся сервисы (YAR client в chrome) или через Swagger
- Создать клиента (C# или JavaScript) для получения и отображения данных, полученных от сервиса (добавив ссылку на службу OpenAPI используя Swagger)
*/

using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

namespace Lab3._1
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

			builder.Services.AddSqlServer<AppContext>(config.GetConnectionString("DefaultConnection"));

			builder.Services.AddControllers();

			/*
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();
			*/

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.Configure<JsonOptions>(options =>
			{
				options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
			});


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				//app.MapOpenApi();
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.MapControllers();
			app.MapCourseEndpoints();

			app.Run();
		}
	}
}
