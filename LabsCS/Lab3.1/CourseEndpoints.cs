using Microsoft.EntityFrameworkCore;
namespace Lab3._1;

public static class CourseEndpoints
{
	public static void MapCourseEndpoints(this IEndpointRouteBuilder routes)
	{
		var courses = routes.MapGroup("/api/Course");

		courses.MapGet("/", async (AppContext db) =>
		{
			return await db.Courses
				//.Include(c => c.Students)
				//.Include(c => c.Teachers)
				.ToListAsync();
		})
		.WithName("GetAllCourses")
		.WithOpenApi()
		.Produces<List<Course>>(StatusCodes.Status200OK);


		courses.MapGet("/{id}", async (int id, AppContext db) =>
		{
			return await db.Courses.AsNoTracking()
				.Include(c => c.Students)
				.Include(c => c.Teachers)
				.FirstOrDefaultAsync(course => course.Id == id)
				is Course course
					? Results.Ok(course)
					: Results.NotFound();
		})
		.WithName("GetCourseById")
		.WithOpenApi()
		.Produces<Course>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status404NotFound);

		courses.MapGet("/{id}/Students", async (int id, AppContext db) =>
		{
			//return await db.Students
			//	//.Where(s => s.Courses.Union())
			//	.Include(c => c.Students)
			//	.Include(c => c.Teachers)
			//	.FirstOrDefaultAsync(course => course.Id == id)
			//	is Course course
			//		? Results.Ok(course)
			//		: Results.NotFound();
		})
		.WithName("GetStudentsByCourseId")
		.WithOpenApi()
		.Produces<Course>(StatusCodes.Status200OK)
		.Produces(StatusCodes.Status404NotFound);


		/*

				group.MapPut("/{id}", async  (int id, Person person, AppContext db) =>
				{
					var affected = await db.People
						.Where(model => model.Id == id)
						.ExecuteUpdateAsync(setters => setters
						  .SetProperty(m => m.Id, person.Id)
						  .SetProperty(m => m.Name, person.Name)
						  .SetProperty(m => m.Age, person.Age)
						);

					return affected == 1 ? Results.Created($"/api/Person/{person.Id}", person)
						: Results.NotFound();
				})
				.WithName("UpdatePerson")
				.WithOpenApi()
				.Produces(StatusCodes.Status404NotFound)
				.Produces(StatusCodes.Status204NoContent);

				group.MapPost("/", async (Person person, AppContext db) =>
				{
					db.People.Add(person);
					await db.SaveChangesAsync();
					return Results.Created($"/api/Person/{person.Id}",person);
				})
				.WithName("CreatePerson")
				.WithOpenApi()
				.Produces<Person>(StatusCodes.Status201Created);

				group.MapDelete("/{id}", async  (int id, AppContext db) =>
				{
					var affected = await db.People
						.Where(model => model.Id == id)
						.ExecuteDeleteAsync();

					return affected == 1 ? Results.Ok() : Results.NotFound();
				})
				.WithName("DeletePerson")
				.WithOpenApi()
				.Produces<Person>(StatusCodes.Status200OK)
				.Produces(StatusCodes.Status404NotFound);
				*/
	}
}
