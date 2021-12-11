namespace AdventOfCode2021.Tests;
internal class Day20Task1Tests
{
    public string Example = @"";
    Day20Task1 Solver() => new();
    int Day = 20;

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