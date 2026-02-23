using ABC;
using Axis;
using DoomsdayPreppers;
using Heras;

namespace Oprijlaan;

class Program
{
    static void Main(string[] args)
    {
        var lus = new DetectieLus();
        var hek = new Hek();
        var kuil = new Valkuil();
        var cam = new Camera();

        lus.Connect(hek);
        lus.Connect(kuil);
        lus.Connect(cam);

        lus.Connect(hek.Open);
        lus.Connect(kuil.Open);
        lus.Connect(cam.Start);

        lus.Detect += hek.Open;
        lus.Detect += kuil.Open;
        lus.Detect += cam.Start;


        lus.Detecteert();
        //hek.Open(); // FOUT!!!
    }
}
