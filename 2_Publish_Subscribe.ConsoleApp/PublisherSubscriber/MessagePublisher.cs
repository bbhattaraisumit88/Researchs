namespace _2_Publish_Subscribe.ConsoleApp.PublisherSubscriber;

public class MessagePublisher
{
    // Define a delegate for the event
    public delegate void MessagePublishedEventHandler(object sender, string message);

    // Define the event using the delegate
    public event MessagePublishedEventHandler MessagePublished;

    // Method to publish a message
    public void PublishMessage(string message)
    {
        Console.WriteLine("Publishing message: " + message);
        // Raise the event to notify subscribers
        OnMessagePublished(message);
    }

    // Helper method to raise the event
    protected virtual void OnMessagePublished(string message)
    {
        MessagePublished?.Invoke(this, message);
    }
}