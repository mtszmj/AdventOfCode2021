namespace AdventOfCode2021;
public class Day08Task1
{
    protected readonly HashSet<int> LengthsToCount = new HashSet<int>() { 2,3,4,7 }; // 1,7,4,8
    public Display[] ParseInput(string[] lines)
    {
        return lines.Select(line => line.Split(" | "))
            .Select(line => new Display { 
                Digits = line[0].Split(" "), 
                Output = line[1].Split(" ") 
            }).ToArray();
    }

    public int Count1478(Display[] displays)
    {
        return displays.SelectMany(x => x.Output).Count(x => LengthsToCount.Contains(x.Length));
    }

    public class Display
    {
        public string[] Digits { get; set; }
        public string[] Output { get; set; }
    }
}