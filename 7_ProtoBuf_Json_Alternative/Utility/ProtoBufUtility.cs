using BenchmarkDotNet.Attributes;

using ProtoBuf;

namespace _7_ProtoBuf_Json_Alternative.Utility;

[MemoryDiagnoser]
public class ProtoBufUtility
{
    public static string _folder = "D://ProtoBuf/Serialized";

    public static byte[] ProtoSerialize<T>(T record) where T : class
    {
        if (null == record) return null;

        try
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, record);
                return stream.ToArray();
            }
        }
        catch
        {
            // Log error
            throw;
        }
    }

    [Benchmark]
    public static void ProtoSerialize<T>(T record, string fileName) where T : class
    {
        if (null == record)
            throw new Exception("No Record.");

        if (!Directory.Exists(_folder))
            Directory.CreateDirectory(_folder);

        try
        {
            using (var fileStream = File.Create($"{_folder}/{fileName}.buf"))
            {
                Serializer.Serialize(fileStream, record);
            }
        }
        catch
        {
            // Log error
            throw;
        }
    }

    public static T ProtoDeserialize<T>(byte[] data) where T : class
    {
        if (null == data) return null;

        try
        {
            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
        catch
        {
            // Log error
            throw;
        }
    }

    [Benchmark]
    public static T ProtoDeserialize<T>(string fileName) where T : class
    {
        try
        {
            using (var fileStream = File.OpenRead($"{_folder}/{fileName}.buf"))
            {
                return Serializer.Deserialize<T>(fileStream);
            }
        }
        catch
        {
            throw;
        }
    }
}