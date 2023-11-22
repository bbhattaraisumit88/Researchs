using BenchmarkDotNet.Attributes;

namespace _9._1_Collection_Performance;

[MemoryDiagnoser]
public class CollectionBenchMarkerDemo
{
    [Benchmark]
    public static void ListExample()
    {
        var records = GetAll().ToList();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    [Benchmark]
    public static void IEnumerableExample()
    {
        var records = GetAll();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    private static IEnumerable<int> GetAll()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
}