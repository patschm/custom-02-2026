
namespace Objecten;

internal class ACME
{
    private List<IACMEContract> werknemers = new List<IACMEContract>()   ;

    public void Hire(IACMEContract wn)
    {
        werknemers.Add(wn);
    }

    public void StartProducing()
    {
        Console.WriteLine("ACME start te produceren");
        foreach (var werknemer in werknemers)
        {
            werknemer?.Produce();
        }
    }
}
