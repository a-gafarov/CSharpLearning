for (int i = 1; i <= 10; i++)
{
    if (i == 8) break;
    if (i == 4) continue;
    Console.WriteLine(i);
}

// 1 2 3 .. 10
// 2 4 6 .. 20
// ...
// 10 20 30 .. 100
for (int i = 1; i <= 10; i++)
{
    for(int j = 1; j <= 10; j++)
    {
        if (j == 5) goto metka; //return;
        Console.Write("{0, -5}", i * j);
    }
    Console.WriteLine();
}

metka:
Console.WriteLine("\ncontinue");

int a = 2000;
while (a < 1000)
{
    Console.WriteLine(a); 
    a *= 2; // a = a * 2;
}

a = 2000;
do
{
    Console.WriteLine(a);
    a *= 2;
} while (a < 1000);

/*string[] courses = {
    "Язык C#",
    "Клиент-серверная разработка под .Net На C#",
    "Pattern OOP",
    "Git basics" };*/
ICollection<string> courses = new List<string>() { 
    "Язык C#",
    "Клиент-серверная разработка под .Net На C#",
    "Pattern OOP",
    "Git basics" };

courses.Add("ASP.NET Core Web MVC");

// not good
//for(int i = 0; i < courses.Count; i++)
//    Console.WriteLine(courses[i]); // не работает для ICollection

//IEnumerator<string> en = courses.GetEnumerator();
//while(en.MoveNext())
//{
//    string course = en.Current;
//    Console.WriteLine(course);
//}

// если источник реализует IEnumerable или содержит метод IEnumerator GetEnumerator()
foreach (var course in courses)
    Console.WriteLine(course);
