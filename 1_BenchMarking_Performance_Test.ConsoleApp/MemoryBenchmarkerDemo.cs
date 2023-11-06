using BenchmarkDotNet.Attributes;

namespace _1_BenchMarking_Performance_Test.ConsoleApp;

[MemoryDiagnoser]
public class MemoryBenchmarkerDemo
{
    [Benchmark]
    public async Task NonConcurrentTaskExecutionAsync()
    {
        await TestTaskAsync();
        await TestTaskAsync();
    }

    [Benchmark]
    public async Task ConcurrentTaskExecutionAsync()
    {
        var task1 = TestTaskAsync();
        var task2 = TestTaskAsync();
        await Task.WhenAll(task1, task2);
    }

    private async Task TestTaskAsync()
    {
        await Task.Delay(5000);
    }
}