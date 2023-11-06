using BenchmarkDotNet.Running;

namespace _1_BenchMarking_Performance_Test.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MemoryBenchmarkerDemo>();
        Console.ReadLine();
    }
}