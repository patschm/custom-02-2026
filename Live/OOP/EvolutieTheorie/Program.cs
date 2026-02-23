namespace EvolutieTheorie;

internal class Program
{
    static void Main(string[] args)
    {
        // 2002/2003 Framework 1.0/1.1
        MathDel m1 = new MathDel(Add);
        int result = m1(1, 2);

        // 2005. Framework 2.0
        MathDel m2 = Add;
        result = m2(2,3);
        int c = 100;

        MathDel m3 = delegate (int x, int y)
        {
            return x + y + c;
        };

        result = m3(3,4);

        // 2007/2008 Framework 3.0/3.5
        MathDel m4 =  (x,  y) => x + y;
        result = m4(4, 5);


        // Procedures
        Action<string[]> a1 = (params string[] args) => Console.WriteLine(args);

        a1(["Hallo {0}", "World"]);


        // Functions
        Func<int, int, int> m5 = Add;
        result = m5(5, 6);


        // Returns bool
        Predicate<int> pr = (nr) => nr == 42;
        
        
        Console.WriteLine(result);

        int Add(int x, int y)
        {
            return x + y;
        }
    }

    static int Add(int x, int y)
    {
        return x + y;
    }
}


delegate int MathDel(int x, int y);
