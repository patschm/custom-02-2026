using Standards;

namespace Axis;

public class Camera : IDetectable
{
    public void Activate()
    {
        Start();
    }

    public void Start()
    {
        Console.WriteLine("De camera begint op te nemen");
    }
}
