namespace _4_Async_Void;

/// <summary>
/// While using async void if the inner method throws an exception
/// It is only caught in the catch section of the inner method
/// The higher catch section or from the method where the inner method is called gets triggered iff exception occurs in higher methods.
/// Using callback methods addresses this issue.
/// </summary>
internal class Program
{
    private static async Task Main(string[] args)
    {
        try
        {
            Example example = new();
            // Test method is async void and throws exception.
            example.Test();
            Console.WriteLine("Outer1!");
            await Task.Run(() => Console.WriteLine("Outer2!"));
            Console.Read();
        }
        catch (Exception)
        {
            Console.WriteLine("Out");
        }
    }
}