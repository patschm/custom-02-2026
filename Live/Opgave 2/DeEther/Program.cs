namespace DeEther;

internal class Program
{
    static void Main(string[] args)
    {
        var r538 = new RadioStation();
        r538.Subscribers += ViaSms;
        r538.Subscribers += ViaEther;
        r538.Subscribers += ViaKabel;
        r538.Subscribers += ViaRooksignalen;
        r538.Subscribers += ViaSms;
        r538.Subscribers += ViaEther;
        r538.Subscribers += ViaKabel;
        r538.Subscribers += ViaRooksignalen;
        r538.Subscribers += ViaSms;
        r538.Subscribers += ViaEther;
        r538.Subscribers += ViaKabel;
        r538.Subscribers += ViaRooksignalen;
        r538.Subscribers += ViaSms;
        r538.Subscribers += ViaEther;
        r538.Subscribers += ViaKabel;
        r538.Subscribers += ViaRooksignalen;

        r538.Broadcast();


    }

    static void ViaSms(string msg)
    {
        Console.WriteLine($"Via SMS ontvangen: {msg}");
    }
    static void ViaEther(string msg)
    {
        Console.WriteLine($"Via Ether ontvangen: {msg}");
    }
    static void ViaKabel(string msg)
    {
        Console.WriteLine($"Via Kabel ontvangen: {msg}");
    }
    static void ViaRooksignalen(string msg)
    {
        Console.WriteLine($"Via Rooksignalen ontvangen: {msg}");
    }

}
