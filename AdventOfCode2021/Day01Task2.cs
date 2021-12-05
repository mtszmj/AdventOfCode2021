namespace AdventOfCode2021;
public class Day01Task2
{
    private readonly int _windowSize = 3;

    public int GetDepthMeasurementIncreasesCount(int[] input)
    {
        int sum = 0;
        var increases = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (i < _windowSize)
            {
                sum += input[i];
                continue;
            }

            var previous = sum;
            sum += input[i] - input[i - _windowSize];


            if (previous < sum)
                increases++;
        }

        return increases;
    }
}