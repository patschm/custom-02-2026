namespace Objecten;

internal class Program
{
    static void Main(string[] args)
    {
        ACME acme = new ACME();
        San san = new San();
        Simon simon = new Simon();
        Jeroen jeroen = new Jeroen();
        Bokito bokito = new Bokito();

        acme.Hire(san);
        acme.Hire(jeroen);
        acme.Hire(bokito);
        acme.Hire(simon);


        acme.StartProducing();
    }
}
