namespace MeerInteractie;

delegate void ExecDel();

internal class Max
{
    public void Execute(ExecDel fun)
    {
        Console.WriteLine("Max gaat het volgende halen:");
        fun();

        //fun.Invoke();
    }
}