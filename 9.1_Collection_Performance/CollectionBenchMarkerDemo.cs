using BenchmarkDotNet.Attributes;

namespace _9._1_Collection_Performance;

[MemoryDiagnoser]
public class CollectionBenchMarkerDemo
{
    [Benchmark]
    public void ListExample()
    {
        var records = GetAllList();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    [Benchmark]
    public void IEnumerableExample()
    {
        var records = GetAll();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    [Benchmark]
    public void IReadOnlyCollectionExample()
    {
        var records = GetAllReadOnlyCollection();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    [Benchmark]
    public void DictionaryExample()
    {
        var records = GetAllDictionary();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q.Value > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q.Value > 10);
    }

    private List<int> GetAllList() => GetAll().ToList();

    private IReadOnlyCollection<int> GetAllReadOnlyCollection() => GetAllList();

    private Dictionary<int, int> GetAllDictionary() => GetAll()
                                                       .Select((value, index) => new { Key = index, Value = value })
                                                       .ToDictionary(pair => pair.Key, pair => pair.Value);

    private IEnumerable<int> GetAll()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return i;
        }
    }
}