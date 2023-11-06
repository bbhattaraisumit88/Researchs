namespace _2_Publish_Subscribe.ConsoleApp.PublisherSubscriber;

public class MessageSubscriber
{
    private string name;

    public MessageSubscriber(string name)
    {
        this.name = name;
    }

    // Subscribe to the publisher's event
    public void Subscribe(MessagePublisher publisher)
    {
        publisher.MessagePublished += HandleMessage;
    }

    // Event handler method
    private void HandleMessage(object sender, string message)
    {
        Console.WriteLine($"{name} received message: {message}");
    }
}