using Newtonsoft.Json;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

using HttpClient client = new()
{
	BaseAddress = new Uri("http://localhost:5161/"),
};

using HttpResponseMessage response = await client.GetAsync("api/Courses");

var jsonString = await response.Content.ReadAsStringAsync();
//Console.WriteLine($"{jsonString}\n");

//var parsed = JsonConvert.DeserializeObject<object>(jsonString);

var courseList = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonString);

if (courseList != null)
	foreach (var course in courseList)
	{
		if (course.TryGetValue("title", out var title))
			Console.WriteLine($"{title}");
	}
