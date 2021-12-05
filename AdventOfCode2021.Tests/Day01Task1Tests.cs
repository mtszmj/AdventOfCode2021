namespace AdventOfCode2021.Tests;
public class Day01Task1Tests
{
        
    [Test]
    public void returns_seven_increases()
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

        var result = new Day01Task1().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(7);
    }

    [Test]
    public void returns_zero_increases_when_one_value_only()
    {
        var input = new[]
        {
            199
        };

        var result = new Day01Task1().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(0);
    }

    [Test]
    public void returns_zero_increases_when_equal_values()
    {
        var input = new[]
        {
            199,
            199
        };

        var result = new Day01Task1().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(0);
    }

    [Test]
    public void return_zero_increases_when_decreases_only()
    {
        var input = new[]
        {
            199,
            198,
            197
        };

        var result = new Day01Task1().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(0);
    }

    [Test]
    public void return_1195()
    {
        var input = File.ReadAllLines("Files\\Day01.txt").Select(x => int.Parse(x)).ToArray();

        var result = new Day01Task1().GetDepthMeasurementIncreasesCount(input);

        result.Should().Be(1195);
    }
}