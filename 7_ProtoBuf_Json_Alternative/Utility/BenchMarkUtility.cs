using BenchmarkDotNet.Attributes;

namespace _7_ProtoBuf_Json_Alternative.Utility;

public class BenchMarkUtility
{
    [Benchmark]
    public void BenchmarkProtoSerialize()
    {
        var persons = GetAllPersons();
        ProtoBufUtility.ProtoSerialize(persons, "Example");
    }

    [Benchmark]
    public void BenchmarkProtoDeserialize()
    {
        var persons = GetAllPersons();
        var result = ProtoBufUtility.ProtoDeserialize<IEnumerable<Person>>("Example");
    }

    [Benchmark]
    public void BenchmarkJsonSerialize()
    {
        var persons = GetAllPersons();
        JsonUtility.JsonSerialize(persons, "Example");
    }

    [Benchmark]
    public void BenchmarkJsonDeserialize()
    {
        var persons = GetAllPersons();
        var result = JsonUtility.JsonDeserialize<IEnumerable<Person>>("Example");
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
}