using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Houthakker;

internal class Program
{
    static void Main(string[] args)
    {
        ConfigurationBuilder bld = new ConfigurationBuilder();
        bld.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration config = bld.Build();

        var bld2 = LoggerFactory.Create(logbld => {
            logbld.AddConsole();
            logbld.AddEventLog();
           // logbld.AddFilter((src, lvl) => src == "Bla" &&  lvl >= LogLevel.Trace);
            logbld.AddConfiguration(config.GetSection("Logging"));
            
        });

        ILogger log = bld2.CreateLogger("Blah");
        log.LogCritical("Kritiek");
        log.LogError("Error");
        log.LogWarning("Waarschuwing");
        log.LogInformation("Info");
        log.LogDebug("Debug");
        log.LogTrace("Trace");


        ILogger<Program> log2 = bld2.CreateLogger<Program>();
        log2.LogCritical("Kritiek");
        log2.LogError("Error");
        log2.LogWarning("Waarschuwing");
        log2.LogInformation("Info");
        log2.LogDebug("Debug");
        log2.LogTrace("Trace");





    }
}
