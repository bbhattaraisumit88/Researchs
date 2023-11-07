using _7_ProtoBuf_Json_Alternative.Utility;

using BenchmarkDotNet.Running;

namespace _7_ProtoBuf_Json_Alternative;

public class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<BenchMarkUtility>();
        //var persons = GetAllPersons();
        //ProtoBufExample(persons);
        //JsonExample(persons);
        //Console.WriteLine("Completed!!");
        Console.Read();
    }

    private static IEnumerable<Person> GetAllPersons()
    {
        for (int i = 0; i < 10000; i++)
        {
            Person person = new()
            {
                FirstName = "Wade",
                LastName = "Smith",
                Emails = new List<string> { "wade.smith@gmail.com", "wsmith@company.com" }
            };
            yield return person;
        }
    }

    private static void ProtoBufExample(IEnumerable<Person> persons)
    {
        ProtoBufUtility.ProtoSerialize(persons, "Example");
        var result = ProtoBufUtility.ProtoDeserialize<IEnumerable<Person>>("Example");
    }

    private static void JsonExample(IEnumerable<Person> persons)
    {
        JsonUtility.JsonSerialize(persons, "Example");
        var result = JsonUtility.JsonDeserialize<IEnumerable<Person>>("Example");
    }
}