using Azure.Messaging.ServiceBus;

namespace _6_Service_Bus_Queue_Subscriber;

public static class Receiver
{
    private static async Task MessageHandler(ProcessMessageEventArgs args)
    {
        string body = args.Message.Body.ToString();
        Console.WriteLine($"Message received: {body}");

        await args.CompleteMessageAsync(args.Message);
    }

    private static Task ErrorHandler(ProcessErrorEventArgs args)
    {
        Console.WriteLine(args.Exception.ToString());
        return Task.CompletedTask;
    }

    public static async Task ReceiveMessagesAsync(AppSettings appSettings)
    {
        await using ServiceBusClient client = new ServiceBusClient(appSettings.ServiceBusConnectionString);
        // create a processor that we can use to process the messages
        ServiceBusProcessor processor = client.CreateProcessor(appSettings.DemoQueueName, new ServiceBusProcessorOptions());

        // add handler to process messages
        processor.ProcessMessageAsync += MessageHandler;
        processor.ProcessErrorAsync += ErrorHandler;

        // start processing
        await processor.StartProcessingAsync();

        Console.WriteLine("Wait for a minute and then press any key to end the processing");
        Console.ReadKey();
    }
}