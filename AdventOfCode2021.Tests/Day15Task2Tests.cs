namespace AdventOfCode2021.Tests;
internal class Day15Task2Tests
{
    public string Example = @"1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
    Day15Task2 Solver() => new();
    int Day = 15;

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(315);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(2840);
    }
}