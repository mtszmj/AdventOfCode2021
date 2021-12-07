namespace AdventOfCode2021.Tests;
internal class Day07Task2Tests
{
    [TestCase(5, 168)]
    [TestCase(2, 206)]
    public void calculates_fuel(int position, long cost)
    {
        var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = new Day07Task2().CalculateCost(input, position);

        result.Should().Be(cost);
    }

    [Test]
    public void finds_best_result()
    {
        var input = new int[] { 16, 1, 2, 0, 4, 2, 7, 1, 2, 14 };

        var result = new Day07Task2().FindMinFuel(input);

        result.Should().Be(168);
    }

    [Test]
    public void finds_result_98363777()
    {
        var input = Helper.ReadFileAsIntSplitBy(7, ",");

        var result = new Day07Task2().FindMinFuel(input);

        result.Should().Be(98363777);
    }
}