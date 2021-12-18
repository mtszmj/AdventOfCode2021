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
        result[7].Should().Be(int.MaxValue); // 7
        result[6].Should().Be(int.MaxValue); // 9
        result[9].Should().Be(4);
    }

    [Test]
    public void finds_min_x_max_steps()
    {
        var solver = Solver();
        var xAndSteps = solver.FindXs(20, 30);
        var result = solver.GetMaxSteps(xAndSteps);
        result.Should().Be((6, int.MaxValue));
    }

    [Test]
    public void finds_nine_as_y()
    {
        var solver = Solver();
        var result = solver.FindY(-10, -5, int.MaxValue);
        result.Should().Be(9);
    }

    [Test]
    public void finds_max_y_45()
    {
        var solver = Solver();
        var result = solver.MaxHeight(6, 9, 20, 30, -10, -5);
        result.Should().Be(45);
    }

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(45);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(10011);
    }
}