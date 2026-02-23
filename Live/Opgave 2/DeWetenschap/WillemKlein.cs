namespace DeWetenschap;

delegate int MathDel(int x, int b);

class WillemKlein
{
    public void Bereken(MathDel problem, int u = 3, int v = 4)
    {
        Console.WriteLine("Willem Klein gaat nu rekenen....");
        int result = problem(u, v);

        Console.WriteLine($"Het resultaat is {result}");
    }
}
