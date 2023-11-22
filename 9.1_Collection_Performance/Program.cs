using BenchmarkDotNet.Running;

namespace _9._1_Collection_Performance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<CollectionBenchMarkerDemo>();
            Console.ReadLine();
        }
    }
}