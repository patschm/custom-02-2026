
using Microsoft.Extensions.Configuration;

namespace Configuring;

internal class Program
{
    static void Main(string[] args)
    {
        //ViaEnvironment();
        ViaConfiguration();
    }

    private static void ViaConfiguration()
    {
        ConfigurationBuilder bld = new ConfigurationBuilder();
        bld.AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);
        bld.AddUserSecrets("Geheim");
        IConfiguration config = bld.Build();
       // config.GetReloadToken()

        Person p = new Person();
        var section = config.GetSection("Blah");


        //section.Bind(p);
        Person p2 = section.Get<Person>();
        Console.WriteLine(section.Value);
        Console.WriteLine(p2.Name);

        var data = config.GetConnectionString("Con1");
        Console.WriteLine(data);
    }

    private static void ViaEnvironment()
    {
        Console.WriteLine(Environment.MachineName);
        Console.WriteLine(Environment.UserName);
        Console.WriteLine(Environment.CurrentDirectory);

        //foreach(var env in Environment.GetEnvironmentVariables())
        //{
        //    Console.WriteLine(env);
        //}

        string arg = Environment.GetEnvironmentVariable("MY_ENV");
        Console.WriteLine(arg);

    }
}
