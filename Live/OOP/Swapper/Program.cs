
using System.Text;

namespace Swapper;

internal class Program
{
    static void Main(string[] args)
    {
        Point<int> point = new Point<int> { X = 10, Y = 20 };
        //point = new Point<long>();

        decimal a = 10;
        decimal b = 20;
        Console.WriteLine($"a={a}, b={b}");
        DoeIets(ref a, ref b ) ;
        Console.WriteLine($"a={a}, b={b}");

        var sb = Create<StringBuilder>();
        sb.Append("A");
    }

    static T Create<T>() where T : class, new()
    {
        return new T();
    }

    static void DoeIets<T>(ref T a, ref T b) where T : IFormattable
    {
        T c = a;
        a = b;
        b = c;
    }
    static void DoeIets(ref int a, ref int b)
    {
        int c = a;
        a = b;
        b = c;
    }
    static void DoeIets(ref long a, ref long b)
    {
        long c = a;
        a = b;
        b = c;
    }
    static void DoeIets(ref float a, ref float b)
    {
        float c = a;
        a = b;
        b = c;
    }
}
