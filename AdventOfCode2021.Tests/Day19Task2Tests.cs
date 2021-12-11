namespace AdventOfCode2021.Tests;
internal class Day19Task2Tests
{
    public string Example = @"";
    Day19Task2 Solver() => new();
    int Day = 19;

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