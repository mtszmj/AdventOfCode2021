using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day17Task1
{
    public int Solve(string input)
    {
        return -1;
    }

    public (int x1, int x2, int y1, int y2) Parse(string input)
    {
        //target area: x=20..30, y=-10..-5
        var match = Regex.Match(input, @"x=(?<x1>-?\d+)..(?<x2>-?\d+), y=(?<y1>-?\d+)..(?<y2>-?\d+)$");
        return (match.ToInt("x1"), match.ToInt("x2"), match.ToInt("y1"), match.ToInt("y2"));
    }

    public Dictionary<int, int> FindXs(int x1, int x2)
    {
        // (10 + 1) * 10 / 2  = 55
        // 55 * 2 = 110 => sqrt ~ 10-11 -> floor -> 10 -> -1 for safety
        var minX = Math.Floor(Math.Sqrt(x1 * 2)) - 1;
        var maxX = x2;
        Console.WriteLine($"{x1},{x2}, minX: {minX}, maxX: {maxX}");

        var results = new Dictionary<int, int>();
        for(var x = maxX; x >= minX; x--)
        {
            var add = x;
            var posX = 0;
            var step = 0;
            while(add > 0 && posX < x2)
            {
                posX += add;
                add += add > 0 ? -1 : add < 0 ? 1 : 0;
                step++;
                if (posX >= x1 && posX <= x2)
                    results[x] = step; // keep highest step count, the more steps the higher y can get
            }
        }

        return results;
    }




}

public static class Extensions
{
    public static int ToInt(this Match match, string groupName)
    {
        return int.Parse(match.Groups[groupName].Value);
    }
}