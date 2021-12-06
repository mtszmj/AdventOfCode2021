namespace AdventOfCode2021.Tests;
internal class Day06Task1Tests
{
    [TestCase(1, 5)]
    [TestCase(2, 6)]
    [TestCase(3, 7)]
    [TestCase(4, 9)]
    [TestCase(5, 10)]
    [TestCase(6, 10)]
    [TestCase(7, 10)]
    [TestCase(8, 10)]
    [TestCase(9, 11)]
    [TestCase(10, 12)]
    [TestCase(11, 15)]
    [TestCase(12, 17)]
    [TestCase(13, 19)]
    [TestCase(14, 20)]
    [TestCase(15, 20)]
    [TestCase(16, 21)]
    [TestCase(17, 22)]
    [TestCase(18, 26)]
    [TestCase(80, 5934)]
    public void returns_fish_count(int days, int expected)
    {
        var input = @"3,4,3,1,2".Split(',').Select(int.Parse);

        var result = new Day06Task1().HowMuchIsTheFish(input, days);

        result.Should().Be(expected);
    }

    [Test]
    public void returns_361169()
    {
        var input = Helper.ReadFile(6).Split(',').Select(int.Parse);

        var result = new Day06Task1().HowMuchIsTheFish(input, 80);

        result.Should().Be(361169);
    }
}