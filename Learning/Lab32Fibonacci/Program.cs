int k1 = 1, k2 = 1, k3;
Console.Write($"{k1} {k2} ");
while ( (k3 = k1 + k2) < 1000 )
{
    Console.Write($"{k3} " );
    k1 = k2;
    k2 = k3;
}
