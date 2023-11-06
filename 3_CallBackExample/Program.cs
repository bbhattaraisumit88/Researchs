namespace _3_CallBackExample;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Please enter expected output 'pass', 'fail' or 'error': ");
        string userInput = Console.ReadLine();
        ExpectedResult input = Enum.TryParse(userInput, true, out ExpectedResult expectedResult) ? expectedResult : ExpectedResult.None;
        if (!input.Equals(ExpectedResult.None))
        {
            Student.Instance.Register(
                    input,
                    () => Console.WriteLine("Registration success!"),
                    error => Console.WriteLine($"Registration error! {error}")
                );
            Console.WriteLine("Registration completed.");

            Student.Instance.Remove(
                   input,
                   success => Console.WriteLine($"Removal success! and the value is {success}"),
                   error => Console.WriteLine($"Removal error! {error}")
               );
            Console.WriteLine("Removal completed.");
        }
        else
            Console.WriteLine($"Invalid input {userInput}");

        Console.Read();
    }
}