namespace AdventOfCode2021;
public class Day03Task2
{
    public object ReadOxygenAndCO2(string[] inputLines)
    {
        var lineSize = inputLines[0].Length;
        var mostCommon = new int[lineSize];
        var leastCommon = new int[lineSize];
        var oxygen = inputLines.ToImmutableArray();
        var co2 = inputLines.ToImmutableArray();

        var index = 0;
        while(oxygen.Length > 1)
        {
            var result = 0;
            foreach (var line in oxygen)
            {
                _ = line[index] == '1' ? ++result : --result;
            }

            oxygen = result >= 0 
                ? oxygen.Where(line => line[index] == '1').ToImmutableArray() 
                : oxygen.Where(line => line[index] == '0').ToImmutableArray();

            index = (++index) % lineSize;
        }
        var oxygenResult = Convert.ToInt32(oxygen[0], 2);


        index = 0;
        while (co2.Length > 1)
        {
            var result = 0;
            foreach (var line in co2)
            {
                _ = line[index] == '1' ? ++result : --result;
            }

            co2 = result >= 0
                ? co2.Where(line => line[index] == '0').ToImmutableArray()
                : co2.Where(line => line[index] == '1').ToImmutableArray();
             
            index = (++index) % lineSize;
        }

        var co2Result = Convert.ToInt32(co2[0], 2);

        return oxygenResult * co2Result;
    }
}