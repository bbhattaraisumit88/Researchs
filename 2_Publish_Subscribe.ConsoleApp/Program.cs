using _2_Publish_Subscribe.ConsoleApp.PublisherSubscriber;

namespace _2_Publish_Subscribe.ConsoleApp;

internal class Program
{
    private static void Main()
    {
        // Create a message publisher
        MessagePublisher publisher = new MessagePublisher();

        // Create subscribers
        MessageSubscriber subscriber1 = new MessageSubscriber("Subscriber 1");

        // Subscribe subscribers to the publisher's event
        subscriber1.Subscribe(publisher);

        // Publish a message
        publisher.PublishMessage("Hello, world!");

        Console.Read();
    }
}