namespace DeWetenschap;

internal class Program
{
    static void Main(string[] args)
    {
        SimonVDMeer simon = new();
        WillemKlein willem = new();

        willem.Bereken(simon.Add, 8, 9);
        willem.Bereken(simon.Subtract);


        MathDel? m1 = simon.Add;
        m1 = m1 + simon.Add;
        m1 = m1 + simon.Subtract;
        m1 = m1 + simon.Add;
        m1 = m1 + simon.Subtract;

        foreach(var m in m1.GetInvocationList())
        {
            Console.WriteLine(m.Method.Name);
        }

        int res = m1!(1,2);
        Console.WriteLine(res);
    }
}
