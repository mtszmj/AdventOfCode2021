namespace AdventOfCode2021.Tests;
internal class Day14Task2Tests
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
    Day14Task2 Solver() => new();
    int Day = 14;

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example, 40);
        result.Should().Be(2188189693529L);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day), 40);
        result.Should().Be(3447389044530L);
    }
}