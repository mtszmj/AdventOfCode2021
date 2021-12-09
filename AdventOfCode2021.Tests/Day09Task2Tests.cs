namespace AdventOfCode2021.Tests;
internal class Day09Task2Tests
{
    private static readonly string TestInput = @"2199943210
3987894921
9856789892
8767896789
9899965678";

    private static readonly string TestInput2 = @"9999999999999899999999999999
9999999999898789999999999999
9999999898775678999999999999
9999998799654567999999999999
9999999654523456799999999999
9999999543312978899999999999
9999998662106899999999999999
9999987543245679999999999999
9999998765358989999999999999
9999999878767899999999999999
9999999989878999999999999999
9999999999989999999999999999
9999999999999999999999999999";

    [Test]
    public void find_three_basins_1134()
    {
        var solver = new Day09Task2();
        var riskLevel = solver.FindThreeBasinsMultiplication(TestInput.Split(Environment.NewLine));

        riskLevel.Should().Be(1134);
    }

    [Test]
    public void count_basic_size()
    {
        var solver = new Day09Task2();

        var size = TestInput2.Count(x => x is '0' or '1' or '2' or '3' or '4' or '5' or '6' or '7' or '8');

        var basinSize = solver.FindBasinSizes(TestInput2.Split(Environment.NewLine));

        basinSize[0].Should().Be(size);
        basinSize[0].Should().Be(78);
    }


    [Test]
    public void find_three_basins_1019494()
    {
        var solver = new Day09Task2();
        var riskLevel = solver.FindThreeBasinsMultiplication(Helper.ReadLinesAsString(9));

        riskLevel.Should().Be(1019494);
    }
}