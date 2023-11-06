using Microsoft.Extensions.Configuration;

namespace _5_Service_Bus_Queue_Publisher;

internal class Program
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

        await Sender.SendMessagesAsync(appSettings);

        Console.Read();
    }
}