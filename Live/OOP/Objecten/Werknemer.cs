
namespace Objecten;

internal abstract class Werknemer : Persoon, IACMEContract
{
    public void Produce()
    {
        Werkt();
    }

    public abstract void Werkt();
}
