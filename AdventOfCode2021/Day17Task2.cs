namespace AdventOfCode2021;
public class Day17Task2 : Day17Task1
{
    public override int Solve(string input)
    {
        (int x1, int x2, int y1, int y2) target = Parse(input);
        var validXs = FindXs(target.x1, target.x2);
        var xSteps = GetMaxSteps(validXs);
        var y = FindY(target.y1, target.y2, xSteps.steps);
        var allValidShots = FindAllValidShots(target, y, validXs).ToHashSet();
        return allValidShots.Count();
    }

    public HashSet<(int x, int y)> FindAllValidShots(string input)
    {
        (int x1, int x2, int y1, int y2) target = Parse(input);
        var validXs = FindXs(target.x1, target.x2);
        var xSteps = GetMaxSteps(validXs);
        var y = FindY(target.y1, target.y2, xSteps.steps);
        return new HashSet<(int x, int y)>(FindAllValidShots(target, y, validXs));
    }



    public IEnumerable<(int x, int y)> FindAllValidShots((int x1, int x2, int y1, int y2) target, int maxY, Dictionary<int, int> validXs)
    {
        foreach(var shotX in validXs.Keys)
        {
            for(var shotY = maxY; shotY >= target.y1; shotY--)
            {
                var x = shotX;
                var y = shotY;
                var posX = 0;
                var posY = 0;
                while (posY > target.y1 && posX < target.x2)
                {
                    posX += x;
                    x += x > 0 ? -1 : x < 0 ? 1 : 0;
                    posY += y--;
                    if (posX >= target.x1 && posX <= target.x2 && posY >= target.y1 && posY <= target.y2)
                        yield return (shotX, shotY);
                }
            }
            
        }
    }
}