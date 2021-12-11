namespace AdventOfCode2021.Tests;
internal class Day14Task1Tests
{
    public string Example = @"";
    Day14Task1 Solver() => new Day14Task1();
    int Day = 14;

    //[Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(0);
    }

    //[Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(0);
    }
}