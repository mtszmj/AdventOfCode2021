namespace AdventOfCode2021;
public class Day07Task1
{
    public long CalculateCost(int[] input, int position)
    {
        var crabs = input.GroupBy(x => x).ToDictionary(key => key.Key, val => val.LongCount());

        return crabs.Select(kv => Math.Abs(kv.Key - position) * kv.Value).Sum();
    }

    public long FindMinFuel(int[] input)
    {
        var crabs = input.GroupBy(x => x).ToDictionary(key => key.Key, val => val.LongCount());

        var minPosition = crabs.Keys.Min();
        var maxPosition = crabs.Keys.Max();

        long min = long.MaxValue;
        for(var position = minPosition; position <= maxPosition; position++)
        {
            var fuel = crabs.Select(kv => Math.Abs(kv.Key - position) * kv.Value).Sum();
            if (min > fuel)
                min = fuel;
        }

        return min;
    }
}