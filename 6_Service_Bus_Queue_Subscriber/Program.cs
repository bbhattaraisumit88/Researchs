using Microsoft.Extensions.Configuration;

namespace _6_Service_Bus_Queue_Subscriber;

public class Program
{
    private static async Task Main(string[] args)
    {
        // get the configuration details from appsettings.json
        IConfiguration configuration = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .Build();

        var appSettings = new AppSettings();
        configuration.GetSection("AppSettings").Bind(appSettings);

        await Receiver.ReceiveMessagesAsync(appSettings);

        Console.Read();
    }
}