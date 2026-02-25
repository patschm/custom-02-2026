using ACME.DTOs;
using Newtonsoft.Json;

namespace ACME.Client;

internal class Program
{
    static HttpClient client;// = new HttpClient();
    static void Main(string[] args)
    {
        var handler = new SocketsHttpHandler();
        handler.EnableMultipleHttp2Connections = true;
        handler.MaxConnectionsPerServer = 10;
        handler.PooledConnectionLifetime = TimeSpan.FromMinutes(4);

        client = new HttpClient(handler);
        client.BaseAddress = new Uri("https://localhost:7082/");
        Simpel();
        Insert();
        Simpel();
        Simpel();

        Console.ReadLine();
    }

    private static void Insert()
    {
       // HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri("https://localhost:7082/");

        WeatherForecast cast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            Summary = "Lenteweer vandaag",
            TemperatureC = 17
        };
        string data = JsonConvert.SerializeObject(cast);
        StringContent content = new StringContent(data);
        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        var response = client.PostAsync("weatherforecast", content).Result;
        Console.WriteLine(response.StatusCode);
        Console.WriteLine(response.Headers.Location.ToString());

       // client.Dispose();
    }

    private static void Simpel()
    {
        //HttpClient client = new HttpClient();
        //client.BaseAddress = new Uri("https://localhost:7082/");

       HttpResponseMessage response = client.GetAsync("weatherforecast").Result;
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            foreach(var item in response.Headers)
            {
                Console.WriteLine($"{item.Key}:{string.Join(',',  item.Value)}");
            }
            foreach (var item in response.Content.Headers)
            {
                Console.WriteLine($"{item.Key}:{string.Join(',', item.Value)}");
            }
            var data = response.Content.ReadAsStringAsync().Result;
            var dataArray = JsonConvert.DeserializeObject<WeatherForecast[]>(data);
            foreach(var item in dataArray)
            {
                Console.WriteLine(item.TemperatureC);
            }
        }
        //client.Dispose();   
    }
}
