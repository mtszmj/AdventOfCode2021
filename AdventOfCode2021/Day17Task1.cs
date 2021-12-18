using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day17Task1
{
    public int Solve(string input)
    {
        var target = Parse(input);
        var xSteps = GetMaxSteps(FindXs(target.x1, target.x2));
        var y = FindY(target.y1, target.y2, xSteps.steps);
        return MaxHeight(xSteps.x, y, target.x1, target.x2, target.y1, target.y2);
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
                    results[x] = add != 0 ? step : int.MaxValue; // keep highest step count, the more steps the higher y can get
            }
        }

        return results;
    }

    // The more steps there are the higher Y can get
    public (int x, int steps) GetMaxSteps(Dictionary<int, int> xAndSteps)
    {
        return xAndSteps.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Select(x => (x.Key, x.Value)).First();
    }

    public int FindY(int y1, int y2, int steps)
    {
        // we shoot up the way the parabole is back at (x,0),
        // the highest value is when we go to minimum value of y the next step 
        //        _
        //       / \
        // (0,0)/   \
        //           |
        //          T|T
        if (steps == int.MaxValue) 
        {
            return Math.Abs(y1 + 1);
        }

        throw new NotImplementedException();
    }

    public int MaxHeight(int x, int y, int x1, int x2, int y1, int y2)
    {
        var target = false;
        var posX = 0;
        var posY = 0;
        var maxY = int.MinValue;
        while(posY > y1 && posX < x2)
        {
            posX += x;
            x += x > 0 ? -1 : x < 0 ? 1 : 0;
            posY += y--;
            maxY = posY > maxY ? posY: maxY;
            if (posX >= x1 && posX <= x2 && posY >= y1 && posY <= y2)
                target = true;
        }

        return target ? maxY : throw new InvalidOperationException();
    }



}

public static class Extensions
{
    public static int ToInt(this Match match, string groupName)
    {
        return int.Parse(match.Groups[groupName].Value);
    }
}