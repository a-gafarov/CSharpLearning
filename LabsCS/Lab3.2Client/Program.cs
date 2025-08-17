using Grpc.Net.Client;
using System.Text;
using static Lab3._2.CoursesService;

namespace Lab3._2Client
{
	internal class Program
	{
		async static Task Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			using var channel = GrpcChannel.ForAddress("http://localhost:5001");

			var client = new CoursesServiceClient(channel);
			var reply = await client.ListCoursesAsync(new Google.Protobuf.WellKnownTypes.Empty());

			foreach (var c in reply.Courses)
				Console.WriteLine($"{c.Id}.{c.Title} : {c.Duration}");

		}
	}
}
