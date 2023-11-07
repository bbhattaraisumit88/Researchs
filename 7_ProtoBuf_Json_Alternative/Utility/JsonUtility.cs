using BenchmarkDotNet.Attributes;

using System.Text.Json;

namespace _7_ProtoBuf_Json_Alternative.Utility;

[MemoryDiagnoser]
public class JsonUtility
{
    public static string _folder = "D://ProtoBuf/Serialized";

    [Benchmark]
    public static void JsonSerialize<T>(T record, string fileName) where T : class
    {
        if (null == record)
            throw new Exception("No Record.");

        if (!Directory.Exists(_folder))
            Directory.CreateDirectory(_folder);

        try
        {
            using (var fileStream = File.Create($"{_folder}/{fileName}.json"))
            {
                JsonSerializer.Serialize(fileStream, record);
            }
        }
        catch
        {
            // Log error
            throw;
        }
    }

    [Benchmark]
    public static T JsonDeserialize<T>(string fileName) where T : class
    {
        try
        {
            using (var fileStream = File.OpenRead($"{_folder}/{fileName}.json"))
            {
                return JsonSerializer.Deserialize<T>(fileStream);
            }
        }
        catch
        {
            throw;
        }
    }
}