namespace AdventOfCode2021.Tests;
internal class Day16Task1Tests
{
    public string Example = @"";
    Day16Task1 Solver() => new();
    int Day = 16;

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