namespace AdventOfCode2021
{
    public class Day01Task1
    {
        public int GetDepthMeasurementIncreasesCount(int[] input)
        {
            int? previous = null;
            var increases = 0;
            for (var i = 0; i < input.Length; i++)
            {
                if (!previous.HasValue)
                {
                    previous = input[i];
                    continue;
                }

                if (input[i] > previous.Value)
                    increases++;

                previous = input[i];
            }

            return increases;
        }
    }
}