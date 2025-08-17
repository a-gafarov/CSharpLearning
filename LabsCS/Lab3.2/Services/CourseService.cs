using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Lab3._2;

namespace Lab3._2.Services
{
	public class CourseService : CoursesService.CoursesServiceBase
	{
		private readonly ILogger<CourseService> _logger;
		public CourseService(ILogger<CourseService> logger)
		{
			_logger = logger;
		}

		public override Task<ListReply> ListCourses(Empty request, ServerCallContext context)
		{
			using (AppContext db = new())
			{
				var listReply = new ListReply();
				var courseList = db.Courses.Select(
					item => new CourseReply
					{
						Id = item.Id,
						Title = item.Title,
						Duration = item.Duration,
						Description = item.Description
					}
				).ToList();
				listReply.Courses.AddRange(courseList);
				return Task.FromResult(listReply);
			}
		}

		public override Task<CourseReply> GetCourse(GetCourseRequest request, ServerCallContext context)
		{
			using (AppContext db = new())
			{
				var course = db.Courses.SingleOrDefault(c => c.Id == request.Id);
				if (course == null)
					throw new RpcException(new Status(StatusCode.NotFound, "Course not found"));
				else
				{
					var courseReply = new CourseReply();
					courseReply.Id = course.Id;
					courseReply.Title = course.Title;
					courseReply.Duration = course.Duration;
					courseReply.Description = course.Description;
					return Task.FromResult(courseReply);
				}
			}
		}

		public override Task<CourseReply> CreateCourse(CreateCourseRequest request, ServerCallContext context)
		{
			return base.CreateCourse(request, context);
		}

		public override Task<CourseReply> DeleteCourse(DeleteCourseRequest request, ServerCallContext context)
		{
			return base.DeleteCourse(request, context);
		}

		public override Task<CourseReply> UpdateCourse(UpdateCourseRequest request, ServerCallContext context)
		{
			return base.UpdateCourse(request, context);
		}


		/*
		public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
		{
			Console.WriteLine($"request.Name: {request.Name}");
			return Task.FromResult(new HelloReply
			{
				Message = "Hello " + request.Name
			});
		}
		*/
	}
}
