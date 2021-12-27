using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day22Task1
{
    public record Step(bool IsOn, int X1, int X2, int Y1, int Y2, int Z1, int Z2);
    public IEnumerable<Step> Parse(string input)
    {
        foreach(var line in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var match = Regex.Match(line, @"^(?<onoff>on|off) x=(?<x1>-?\d+)\.\.(?<x2>-?\d+),y=(?<y1>-?\d+)\.\.(?<y2>-?\d+),z=(?<z1>-?\d+)\.\.(?<z2>-?\d+)$", RegexOptions.Compiled);

            var (x1, x2, y1, y2, z1, z2) = (match.ToInt("x1"), match.ToInt("x2"),
                match.ToInt("y1"), match.ToInt("y2"),
                match.ToInt("z1"), match.ToInt("z2"));

            yield return new Step(match.Groups["onoff"].Value == "on", 
                x1 < x2 ? x1 : x2, 
                x1 < x2 ? x2 : x1,
                y1 < y2 ? y1 : y2, 
                y1 < y2 ? y2 : y1,
                z1 < z2 ? z1 : z2,
                z1 < z2 ? z2 : z1
                )
                ;
        }
    }

    public int Solve(string input)
    {
        var array = new bool[101, 101, 101];

        foreach(var step in Parse(input))
        {
            if (step.X1 < -50 || step.X2 > 50
                || step.Y1 < -50 || step.Y2 > 50
                || step.Z1 < -50 || step.Z2 > 50)
                continue;

            for(var x = step.X1; x <= step.X2; x++)
                for(var y = step.Y1; y <= step.Y2; y++)
                    for(var z = step.Z1; z <= step.Z2; z++)
                        if(step.IsOn)
                            array[x+50, y+50, z+50] = true;
                        else
                            array[x+50, y+50, z+50] = false;
        }

        var count = 0;
        for (var x = -50; x <= 50; x++)
            for (var y = -50; y <= 50; y++)
                for (var z = -50; z <= 50; z++)
                    if (array[x + 50, y + 50, z + 50])
                        count++;
        return count;
    }


}