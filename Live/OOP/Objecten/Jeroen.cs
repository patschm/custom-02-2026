namespace Objecten;

internal class Jeroen : Werknemer
{
    public void MaaktListigeBugs()
    {
        Console.WriteLine("Jeroen maakt listig bugs");
    }

    public override void Werkt()
    {
        MaaktListigeBugs();
    }
}
