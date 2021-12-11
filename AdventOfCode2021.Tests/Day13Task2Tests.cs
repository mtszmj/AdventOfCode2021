namespace AdventOfCode2021.Tests;
internal class Day13Task2Tests
{
    public string Example = @"";
    Day13Task2 Solver() => new Day13Task2();
    int Day = 13;

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