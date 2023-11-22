namespace _9_IEnumerable_Vs_List;

internal class Program
{
    private static void Main(string[] args)
    {
        IEnumerableExample();
        ListExample();
        Console.ReadLine();
    }

    private static void ListExample()
    {
        var records = GetAll().ToList();
        int count1 = records.Count();
        bool hasGreaterThanTen1 = records.Any(q => q > 10);
        int count2 = records.Count();
        bool hasGreaterThanTen2 = records.Any(q => q > 10);
    }

    private static void IEnumerableExample()
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