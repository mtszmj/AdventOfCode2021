namespace AdventOfCode2021.Tests;
internal class Day21Task2Tests
{
    public string Example = @"Player 1 starting position: 4
Player 2 starting position: 8";
    Day21Task2 Solver() => new();
    int Day = 21;

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(444356092776315);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(486638407378784);
    }
}