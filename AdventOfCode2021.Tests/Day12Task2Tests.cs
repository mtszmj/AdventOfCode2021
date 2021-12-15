using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Validators;

namespace AdventOfCode2021.Tests;

[MemoryDiagnoser]
public class Day12Task2Tests
{
    public const string Example = @"start-A
start-b
A-c
A-b
b-d
A-end
b-end";

    public const string Example2 = @"dc-end
HN-start
start-kj
dc-start
dc-HN
LN-dc
HN-end
kj-sa
kj-HN
kj-dc";

    public const string Example3 = @"fs-end
he-DX
fs-he
start-DX
pj-DX
end-zg
zg-sl
zg-pj
pj-he
RW-he
fs-DX
pj-RW
zg-RW
start-pj
he-WI
zg-he
pj-fs
start-RW";

    Day12Task2 Solver() => new();
    int Day = 12;

    [TestCase(Example, "start,A,b,A,b,A,c,A,end")]
    [TestCase(Example, "start,A,b,A,b,A,end")]
    [TestCase(Example, "start,A,b,A,b,end")]
    [TestCase(Example, "start,A,b,A,c,A,b,A,end")]
    [TestCase(Example, "start,A,b,A,c,A,b,end")]
    [TestCase(Example, "start,A,b,A,c,A,c,A,end")]
    [TestCase(Example, "start,A,b,A,c,A,end")]
    [TestCase(Example, "start,A,b,A,end")]
    [TestCase(Example, "start,A,b,d,b,A,c,A,end")]
    [TestCase(Example, "start,A,b,d,b,A,end")]
    [TestCase(Example, "start,A,b,d,b,end")]
    [TestCase(Example, "start,A,b,end")]
    [TestCase(Example, "start,A,c,A,b,A,b,A,end")]
    [TestCase(Example, "start,A,c,A,b,A,b,end")]
    [TestCase(Example, "start,A,c,A,b,A,c,A,end")]
    [TestCase(Example, "start,A,c,A,b,A,end")]
    [TestCase(Example, "start,A,c,A,b,d,b,A,end")]
    [TestCase(Example, "start,A,c,A,b,d,b,end")]
    [TestCase(Example, "start,A,c,A,b,end")]
    [TestCase(Example, "start,A,c,A,c,A,b,A,end")]
    [TestCase(Example, "start,A,c,A,c,A,b,end")]
    [TestCase(Example, "start,A,c,A,c,A,end")]
    [TestCase(Example, "start,A,c,A,end")]
    [TestCase(Example, "start,A,end")]
    [TestCase(Example, "start,b,A,b,A,c,A,end")]
    [TestCase(Example, "start,b,A,b,A,end")]
    [TestCase(Example, "start,b,A,b,end")]
    [TestCase(Example, "start,b,A,c,A,b,A,end")]
    [TestCase(Example, "start,b,A,c,A,b,end")]
    [TestCase(Example, "start,b,A,c,A,c,A,end")]
    [TestCase(Example, "start,b,A,c,A,end")]
    [TestCase(Example, "start,b,A,end")]
    [TestCase(Example, "start,b,d,b,A,c,A,end")]
    [TestCase(Example, "start,b,d,b,A,end")]
    [TestCase(Example, "start,b,d,b,end")]
    [TestCase(Example, "start,b,end")]
    public void contains_path(string input, string path)
    {
        var result = Solver().Solve(input.Split(Environment.NewLine));
        result.Any(x => x.ToString() == path).Should().BeTrue();
    }

    [TestCase(Example, 36)]
    [TestCase(Example2, 103)]
    [TestCase(Example3, 3509)]
    public void has_paths(string input, int paths)
    {
        var result = Solver().Solve(input.Split(Environment.NewLine));
        result.Count.Should().Be(paths);
    }

    [Benchmark]
    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadLinesAsString(Day));
        result.Count.Should().Be(136767);
    }

    [Test]
    public void benchmark()
    {
#if RELEASE
        var config = new ManualConfig();
        config.AddValidator(JitOptimizationsValidator.DontFailOnError);
        config.AddLogger(DefaultConfig.Instance.GetLoggers().ToArray()); // manual config has no loggers by default
        config.AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray()); // manual config has no columns by default
        BenchmarkRunner.Run<Day12Task2Tests>(config);
#endif
    }
}