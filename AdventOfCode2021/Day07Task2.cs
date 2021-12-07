namespace AdventOfCode2021;
public class Day07Task2 : Day07Task1
{
    protected override long FuelCostAlgorith(Dictionary<int, long> crabs, int position)
    {
        // arithmetic sequence (max + min) * number_of_elements / 2
        return crabs.Select(kv => Math.Abs(kv.Key - position) * (Math.Abs(kv.Key - position) + 1) / 2 * kv.Value).Sum();
    }
}