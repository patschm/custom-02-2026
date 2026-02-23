
namespace Objecten;

internal class Simon : Werknemer
{
    public void Analyseert()
    {
        Console.WriteLine("Simon analyseert");
    }

    public override void Werkt()
    {
        Analyseert();
    }
}
