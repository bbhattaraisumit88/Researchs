﻿using Azure.Messaging.ServiceBus;

namespace _5_Service_Bus_Queue_Publisher;

public static class Sender
{
    public static async Task SendMessagesAsync(AppSettings appSettings)
    {
        await using ServiceBusClient client = new ServiceBusClient(appSettings.ServiceBusConnectionString);
        ServiceBusSender sender = client.CreateSender(appSettings.DemoQueueName);

        for (int i = 1; i < 6; i++)
        {
            string strMessage = $"Demo message {i}";
            ServiceBusMessage message = new ServiceBusMessage(strMessage);
            await sender.SendMessageAsync(message);
            Console.WriteLine($"Sent: {strMessage}");
        }

        Console.WriteLine("All message sent to the queue, press any key to receive the messages");
    }
}