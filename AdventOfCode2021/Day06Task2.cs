namespace AdventOfCode2021;
public class Day06Task2
{
    private const int FishCycle = 6;
    private const int NewFishCycle = 8;
    public long HowMuchIsTheFish(IEnumerable<int> input, int days)
    {
        var fishCounter = InitCounter(input);
        for(var d = 0; d< days; d++) 
            SimulateDay(fishCounter);
        return fishCounter.Sum();
    }

    private static void SimulateDay(long[] fishCounter)
    {
        var zeroValue = fishCounter[0];
        for (var i = 0; i < NewFishCycle; i++)
            fishCounter[i] = fishCounter[i + 1];

        fishCounter[FishCycle] += zeroValue;
        fishCounter[NewFishCycle] = zeroValue;
    }

    private static long[] InitCounter(IEnumerable<int> input)
    {
        var fishCounter = new long[NewFishCycle + 1];
        foreach (var i in input)
            fishCounter[i]++;
        return fishCounter;
    }
}