Console.Write("Введите число ворон на ветке: ");
int n = int.Parse(Console.ReadLine());
//int n = Convert.ToInt32(Console.ReadLine());
string v;

/*int n2 = n % 100;
if (n2 >= 11 && n2 <= 14)
    v = "ворон";
else
    switch (n % 10)
    {
        case 1: v = "ворона"; break;
        case 2:
        case 3:
        case 4: v = "вороны"; break;
        default: v = "ворон"; break;
    }*/
int n2 = n % 100;
v = (n2 >= 11 && n2 <= 14) ? "ворон" :
    (n % 10) switch
    { 
        1 => "ворона",
        >=2 and <= 4 => "вороны",
        //2 or 3 or 4 => "вороны",
        _ => "ворон"
    };

Console.WriteLine($"На ветке {n} {v}");
