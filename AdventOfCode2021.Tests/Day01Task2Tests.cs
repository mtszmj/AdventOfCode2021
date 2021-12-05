namespace AdventOfCode2021.Tests;
public class Day01Task2Tests
{
        
    [Test]
    public void returns_five_increases()
    {
        var input = new[]
        {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

        var result = new Day01Task2().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(5);
    }

    [Test]
    public void return_1235()
    {
        var input = File.ReadAllLines("Files\\Day01.txt").Select(x => int.Parse(x)).ToArray();

        var result = new Day01Task2().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(1235);
    }
}