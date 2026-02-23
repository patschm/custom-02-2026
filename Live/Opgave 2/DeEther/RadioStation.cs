
namespace DeEther;

internal delegate void BraadworstHandler(string msg);

internal class RadioStation
{
    //private BraadworstHandler? subscribers;

    public event BraadworstHandler Subscribers;
    //{
    //    add
    //    {
    //        subscribers += value;
    //    }
    //    remove
    //    {
    //        subscribers -= value;
    //    }
    //}

    public void Broadcast()
    {
        Console.WriteLine("Het radiostation zend nu uit");
        Subscribers?.Invoke("Hallo luisteraars");
    }
}
