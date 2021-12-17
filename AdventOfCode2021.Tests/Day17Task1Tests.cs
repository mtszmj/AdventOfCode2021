namespace AdventOfCode2021.Tests;
internal class Day17Task1Tests
{
    public string Example = @"target area: x=20..30, y=-10..-5";
    Day17Task1 Solver() => new();
    int Day = 17;

    [Test]
    public void parses_example()
    {
        var result = Solver().Parse(Example);
        result.Should().Be((20, 30, -10, -5));
    }
    
    [Test]
    public void finds_x_and_steps()
    {
        var result = Solver().FindXs(20, 30);
        result[7].Should().Be(7);
        result[6].Should().Be(9);
        result[9].Should().Be(4);
    }

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