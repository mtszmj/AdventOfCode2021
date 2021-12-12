namespace AdventOfCode2021.Tests;
internal class Day12Task1Tests
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

    Day12Task1 Solver() => new();
    int Day = 12;

    [TestCase(Example, "start,A,b,A,c,A,end")]
    [TestCase(Example, "start,A,b,A,end")]
    [TestCase(Example, "start,A,b,end")]
    [TestCase(Example, "start,A,c,A,b,A,end")]
    [TestCase(Example, "start,A,c,A,b,end")]
    [TestCase(Example, "start,A,c,A,end")]
    [TestCase(Example, "start,A,end")]
    [TestCase(Example, "start,b,A,c,A,end")]
    [TestCase(Example, "start,b,A,end")]
    [TestCase(Example, "start,b,end")]
    [TestCase(Example2, "start,HN,dc,HN,end")]
    [TestCase(Example2, "start,HN,dc,HN,kj,HN,end")]
    [TestCase(Example2, "start,HN,dc,end")]
    [TestCase(Example2, "start,HN,dc,kj,HN,end")]
    [TestCase(Example2, "start,HN,end")]
    [TestCase(Example2, "start,HN,kj,HN,dc,HN,end")]
    [TestCase(Example2, "start,HN,kj,HN,dc,end")]
    [TestCase(Example2, "start,HN,kj,HN,end")]
    [TestCase(Example2, "start,HN,kj,dc,HN,end")]
    [TestCase(Example2, "start,HN,kj,dc,end")]
    [TestCase(Example2, "start,dc,HN,end")]
    [TestCase(Example2, "start,dc,HN,kj,HN,end")]
    [TestCase(Example2, "start,dc,end")]
    [TestCase(Example2, "start,dc,kj,HN,end")]
    [TestCase(Example2, "start,kj,HN,dc,HN,end")]
    [TestCase(Example2, "start,kj,HN,dc,end")]
    [TestCase(Example2, "start,kj,HN,end")]
    [TestCase(Example2, "start,kj,dc,HN,end")]
    [TestCase(Example2, "start,kj,dc,end")]
    public void contains_path(string input, string path)
    {
        var result = Solver().Solve(input.Split(Environment.NewLine));
        result.Any(x => x.ToString() == path).Should().BeTrue();
    }

    [TestCase(Example, 10)]
    [TestCase(Example2, 19)]
    [TestCase(Example3, 226)]
    public void has_paths(string input, int paths)
    {
        var result = Solver().Solve(input.Split(Environment.NewLine));
        result.Count.Should().Be(paths);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadLinesAsString(Day));
        result.Count.Should().Be(4411);
    }
}