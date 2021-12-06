namespace AdventOfCode2021.Tests;
internal class Day06Task2Tests
{
    [TestCase(80, 5934)]
    [TestCase(256, 26984457539)]
    public void returns_fish_count(int days, long expected)
    {
        var input = @"3,4,3,1,2".Split(',').Select(int.Parse);

        var result = new Day06Task2().HowMuchIsTheFish(input, days);

        result.Should().Be(expected);
    }

    [Test]
    public void returns_361169()
    {
        var input = Helper.ReadFile(6).Split(',').Select(int.Parse);

        var result = new Day06Task2().HowMuchIsTheFish(input, 256);

        result.Should().Be(361169);
    }
}