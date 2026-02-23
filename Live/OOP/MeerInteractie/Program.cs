namespace MeerInteractie;

internal class Program
{
    static void Main(string[] args)
    {
        Patrick p = new Patrick();
        Max m = new Max();
        // p.DoeIets(); // Hier doe ik het zelf
        m.Execute(p.DoeIets); // Hier wil ik het Max laten doen
    }
}
