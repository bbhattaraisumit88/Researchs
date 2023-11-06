namespace _4_Async_Void;

public class Example
{
    public async void Test()
    {
        try
        {
            await Task.Delay(1500);
            await Task.Delay(1500);
            Console.WriteLine("Inner!");
            throw new Exception("Exception occured!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }
}