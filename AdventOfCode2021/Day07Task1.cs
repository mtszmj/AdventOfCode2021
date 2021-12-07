namespace AdventOfCode2021;
public class Day07Task1
{
    public long CalculateCost(int[] input, int position)
    {
        Dictionary<int, long> crabs = ParseInput(input);

        return FuelCostAlgorith(crabs, position);
    }

    private static Dictionary<int, long> ParseInput(int[] input)
    {
        return input.GroupBy(x => x).ToDictionary(key => key.Key, val => val.LongCount());
    }

    public long FindMinFuel(int[] input)
    {
        var crabs = ParseInput(input);

        var minPosition = crabs.Keys.Min();
        var maxPosition = crabs.Keys.Max();

        long min = long.MaxValue;
        for(var position = minPosition; position <= maxPosition; position++)
        {
            long fuel = FuelCostAlgorith(crabs, position);
            if (min > fuel)
                min = fuel;
        }

        return min;
    }

    protected virtual long FuelCostAlgorith(Dictionary<int, long> crabs, int position)
    {
        return crabs.Select(kv => Math.Abs(kv.Key - position) * kv.Value).Sum();
    }
}