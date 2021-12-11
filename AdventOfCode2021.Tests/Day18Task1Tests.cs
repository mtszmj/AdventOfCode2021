namespace AdventOfCode2021.Tests;
internal class Day18Task1Tests
{
    public string Example = @"";
    Day18Task1 Solver() => new Day18Task1();
    int Day = 18;

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