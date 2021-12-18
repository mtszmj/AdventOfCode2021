namespace AdventOfCode2021.Tests;
internal class Day17Task2Tests
{
    public string Example = @"target area: x=20..30, y=-10..-5";
    Day17Task2 Solver() => new();
    int Day = 17;

    [Test]
    public void finds_all_correct_shots()
    {
        var shots = Solver().FindAllValidShots(Example);

        shots.Should().Contain((23, -10));
        shots.Should().Contain((25, -9));
        shots.Should().Contain((27, -5));
        shots.Should().Contain((29, -6));
        shots.Should().Contain((22, -6));
        shots.Should().Contain((21, -7));
        shots.Should().Contain((9, 0));
        shots.Should().Contain((27, -7));
        shots.Should().Contain((24, -5));
        shots.Should().Contain((25, -7));
        shots.Should().Contain((26, -6));
        shots.Should().Contain((25, -5));
        shots.Should().Contain((6, 8));
        shots.Should().Contain((11, -2));
        shots.Should().Contain((20, -5));
        shots.Should().Contain((29, -10));
        shots.Should().Contain((6, 3));
        shots.Should().Contain((28, -7));
        shots.Should().Contain((8, 0));
        shots.Should().Contain((30, -6));
        shots.Should().Contain((29, -8));
        shots.Should().Contain((20, -10));
        shots.Should().Contain((6, 7));
        shots.Should().Contain((6, 4));
        shots.Should().Contain((6, 1));
        shots.Should().Contain((14, -4));
        shots.Should().Contain((21, -6));
        shots.Should().Contain((26, -10));
        shots.Should().Contain((7, -1));
        shots.Should().Contain((7, 7));
        shots.Should().Contain((8, -1));
        shots.Should().Contain((21, -9));
        shots.Should().Contain((6, 2));
        shots.Should().Contain((20, -7));
        shots.Should().Contain((30, -10));
        shots.Should().Contain((14, -3));
        shots.Should().Contain((20, -8));
        shots.Should().Contain((13, -2));
        shots.Should().Contain((7, 3));
        shots.Should().Contain((28, -8));
        shots.Should().Contain((29, -9));
        shots.Should().Contain((15, -3));
        shots.Should().Contain((22, -5));
        shots.Should().Contain((26, -8));
        shots.Should().Contain((25, -8));
        shots.Should().Contain((25, -6));
        shots.Should().Contain((15, -4));
        shots.Should().Contain((9, -2));
        shots.Should().Contain((15, -2));
        shots.Should().Contain((12, -2));
        shots.Should().Contain((28, -9));
        shots.Should().Contain((12, -3));
        shots.Should().Contain((24, -6));
        shots.Should().Contain((23, -7));
        shots.Should().Contain((25, -10));
        shots.Should().Contain((7, 8));
        shots.Should().Contain((11, -3));
        shots.Should().Contain((26, -7));
        shots.Should().Contain((7, 1));
        shots.Should().Contain((23, -9));
        shots.Should().Contain((6, 0));
        shots.Should().Contain((22, -10));
        shots.Should().Contain((27, -6));
        shots.Should().Contain((8, 1));
        shots.Should().Contain((22, -8));
        shots.Should().Contain((13, -4));
        shots.Should().Contain((7, 6));
        shots.Should().Contain((28, -6));
        shots.Should().Contain((11, -4));
        shots.Should().Contain((12, -4));
        shots.Should().Contain((26, -9));
        shots.Should().Contain((7, 4));
        shots.Should().Contain((24, -10));
        shots.Should().Contain((23, -8));
        shots.Should().Contain((30, -8));
        shots.Should().Contain((7, 0));
        shots.Should().Contain((9, -1));
        shots.Should().Contain((10, -1));
        shots.Should().Contain((26, -5));
        shots.Should().Contain((22, -9));
        shots.Should().Contain((6, 5));
        shots.Should().Contain((7, 5));
        shots.Should().Contain((23, -6));
        shots.Should().Contain((28, -10));
        shots.Should().Contain((10, -2));
        shots.Should().Contain((11, -1));
        shots.Should().Contain((20, -9));
        shots.Should().Contain((14, -2));
        shots.Should().Contain((29, -7));
        shots.Should().Contain((13, -3));
        shots.Should().Contain((23, -5));
        shots.Should().Contain((24, -8));
        shots.Should().Contain((27, -9));
        shots.Should().Contain((30, -7));
        shots.Should().Contain((28, -5));
        shots.Should().Contain((21, -10));
        shots.Should().Contain((7, 9));
        shots.Should().Contain((6, 6));
        shots.Should().Contain((21, -5));
        shots.Should().Contain((27, -10));
        shots.Should().Contain((7, 2));
        shots.Should().Contain((30, -9));
        shots.Should().Contain((21, -8));
        shots.Should().Contain((22, -7));
        shots.Should().Contain((24, -9));
        shots.Should().Contain((20, -6));
        shots.Should().Contain((6, 9));
        shots.Should().Contain((29, -5));
        shots.Should().Contain((8, -2));
        shots.Should().Contain((27, -8));
        shots.Should().Contain((30, -5));
        shots.Should().Contain((24, -7));
    }

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(112);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(2994);
    }
}