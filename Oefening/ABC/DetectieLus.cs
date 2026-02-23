using Standards;

namespace ABC;

public delegate void DetectionHandler();

public class DetectieLus
{
    private List<IDetectable> devices = new List<IDetectable>();
    private List<DetectionHandler> detectors = new List<DetectionHandler>();
    public event DetectionHandler? Detect;

    public void Connect(IDetectable detectable)
    {
        devices.Add(detectable); 
    }
    public void Connect(DetectionHandler detector)
    {
        detectors.Add(detector);
    }
    public void Detecteert()
    {
        Console.WriteLine("De detectielus detecteert iets");
        Console.WriteLine("Via interfaces");
        foreach (IDetectable device in devices)
        {
            device.Activate();
        }
        Console.WriteLine("Via delegates");
        foreach (DetectionHandler device in detectors)
        {
            device();
        }
        Console.WriteLine("Via events");
        Detect?.Invoke();
    }
}
