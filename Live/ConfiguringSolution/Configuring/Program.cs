
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.WebSockets;

namespace Configuring;

internal class Program
{
    static void Main(string[] args)
    {
        //ViaEnvironment();
        //ViaConfiguration();
        TestDataProtectionApi();
    }

    private static void TestDataProtectionApi()
    {
        var factory = new DefaultServiceProviderFactory();
        var services = new ServiceCollection();
        var builder = factory.CreateBuilder(services);
        services.AddDataProtection();

        var provider = builder.BuildServiceProvider();
       var prot =  provider.GetRequiredService<IDataProtectionProvider>();

       var prot2 =  prot.CreateProtector("demo-purpose");
       var test = prot2.Protect("Hello world");
        Console.WriteLine(test);

        var res = prot2.Unprotect(test);
        Console.WriteLine(res);

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
