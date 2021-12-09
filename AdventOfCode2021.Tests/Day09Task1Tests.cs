namespace AdventOfCode2021.Tests;
internal class Day09Task1Tests
{
    private static readonly string TestInput = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    [Test]
    public void find_low_points()
    {
        var solver = new Day09Task1();
        var parsedInput = solver.ParseInput(TestInput.Split(Environment.NewLine));

        parsedInput[0, 0].Row.Should().Be(0);
        parsedInput[0, 0].Column.Should().Be(0);
        parsedInput[0, 0].Height.Should().Be(2);

        parsedInput[0, 9].Row.Should().Be(0);
        parsedInput[0, 9].Column.Should().Be(9);
        parsedInput[0, 9].Height.Should().Be(0);

        parsedInput[4, 0].Row.Should().Be(4);
        parsedInput[4, 0].Column.Should().Be(0);
        parsedInput[4, 0].Height.Should().Be(9);

        parsedInput[4, 9].Row.Should().Be(4);
        parsedInput[4, 9].Column.Should().Be(9);
        parsedInput[4, 9].Height.Should().Be(8);

        parsedInput[2, 2].Row.Should().Be(2);
        parsedInput[2, 2].Column.Should().Be(2);
        parsedInput[2, 2].Height.Should().Be(5);
    }

    [Test]
    public void finds_low_points()
    {
        var solver = new Day09Task1();
        var lowPoints = solver.FindLowPoints(TestInput.Split(Environment.NewLine)).ToList();

        lowPoints.Should().HaveCount(4);
        lowPoints.Should().Contain(new Day09Task1.Point(0, 1, 1));
        lowPoints.Should().Contain(new Day09Task1.Point(0, 9, 0));
        lowPoints.Should().Contain(new Day09Task1.Point(2, 2, 5));
        lowPoints.Should().Contain(new Day09Task1.Point(4, 6, 5));
    }

    [Test]
    public void finds_result_15()
    {
        var solver = new Day09Task1();
        var riskLevel = solver.SumRiskLevel(TestInput.Split(Environment.NewLine));

        riskLevel.Should().Be(15);
    }

    [Test]
    public void finds_result_530()
    {
        var solver = new Day09Task1();
        var riskLevel = solver.SumRiskLevel(Helper.ReadLinesAsString(9));

        riskLevel.Should().Be(530);
    }
}