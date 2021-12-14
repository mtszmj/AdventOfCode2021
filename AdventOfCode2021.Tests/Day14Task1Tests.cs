namespace AdventOfCode2021.Tests;
internal class Day14Task1Tests
{
    public string Example = @"NNCB

CH -> B
HH -> N
CB -> H
NH -> C
HB -> C
HC -> B
HN -> C
NN -> C
BH -> H
NC -> B
NB -> B
BN -> B
BB -> N
BC -> B
CC -> N
CN -> C";
    Day14Task1 Solver() => new Day14Task1();
    int Day = 14;

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example, 10);
        result.Should().Be(1588);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day), 10);
        result.Should().Be(3058);
    }
}