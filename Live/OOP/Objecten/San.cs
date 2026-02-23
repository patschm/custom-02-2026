namespace Objecten;

internal class San : Werknemer
{
    public void BlaasOp()
    {
        Console.WriteLine("San blaast dingen op");
    }

    public override void Werkt()
    {
        BlaasOp();
    }
}