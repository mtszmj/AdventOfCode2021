namespace AdventOfCode2021.Tests;
internal class Day07Task1Tests
{
    [TestCase(1, 41)]
    [TestCase(3, 39)]
    [TestCase(10, 71)]
    [TestCase(2, 37)]
    public void calculates_fuel(int position, long cost)
    {
        var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = new Day07Task1().CalculateCost(input, position);

        result.Should().Be(cost);
    }

    [Test]
    public void finds_best_result()
    {
        var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = new Day07Task1().FindMinFuel(input);

        result.Should().Be(37);
    }

    [Test]
    public void finds_result_347011()
    {
        var input = Helper.ReadFileAsIntSplitBy(7, ",");

        var result = new Day07Task1().FindMinFuel(input);

        result.Should().Be(347011);
    }
}