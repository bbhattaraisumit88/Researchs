namespace _3_CallBackExample;

public class Student
{
    private const int _delay = 5000;
    protected static readonly Student _instance;
    public static Student Instance => _instance;

    static Student() => _instance = new Student();

    public async void Register(ExpectedResult expectedResult, Action successCallBack, Action<string> failureCallBack)
    {
        try
        {
            string module = "registration";
            await ProcessResultAsync(expectedResult, module);
            successCallBack();
        }
        catch (Exception ex)
        {
            failureCallBack(ex.Message);
        }
    }

    private static async Task ProcessResultAsync(ExpectedResult expectedResult, string module)
    {
        await Task.Delay(_delay);
        if (expectedResult.Equals(ExpectedResult.Fail))
            throw new Exception($"Failure expected from {module} input.");

        if (expectedResult.Equals(ExpectedResult.Error))
            UnhandledExceptionTest();
    }

    private static void UnhandledExceptionTest()
    {
        int first = 10;
        int second = 0;
        int result = first / second;
    }

    public async void Remove(ExpectedResult expectedResult, Action<int> successCallBack, Action<string> failureCallBack)
    {
        try
        {
            string module = "removal";
            await ProcessResultAsync(expectedResult, module);
            successCallBack(10);
        }
        catch (Exception ex)
        {
            failureCallBack(ex.Message);
        }
    }
}