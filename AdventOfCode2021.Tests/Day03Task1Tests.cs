namespace AdventOfCode2021.Tests;
internal class Day03Task1Tests
{
    [Test]
    public void returns_198()
    {
        var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

        var inputLines = input.Split(Environment.NewLine);
        var result = new Day03Task1().ReadPowerConsumption(inputLines);

        result.Should().Be(198);
    }

    [Test]
    public void returns_3912944()
    {
        var input = Helper.ReadLinesAsString(3);

        var result = new Day03Task1().ReadPowerConsumption(input);

        result.Should().Be(3912944);
    }
}