namespace AdventOfCode2021;
public class Day10Task2 : Day10Task1
{
    protected static readonly Dictionary<char, int> pointsPerCharacter = new Dictionary<char, int>
    {
        ['('] = 1,
        ['['] = 2,
        ['{'] = 3,
        ['<'] = 4,
    };

    public long FillLine(string line)
    {
        var stack = new Stack<char>();
        foreach(var c in line)
        {
            if (closingCharacter.ContainsKey(c))
                stack.Push(c);
            else if (stack.Count == 0)
                return 0;
            else if (c == closingCharacter[stack.Peek()])
                stack.Pop();
            else return 0;
        }

        var result = 0L;
        foreach(var c in stack)
        {
            result = result * 5 + pointsPerCharacter[c];
        }
        return result;
    }

    public long FindMiddleFillLine(string[] input)
    {
        var list = input.Select(FillLine).Where(x => x > 0).OrderBy(x => x).ToList();
        return list[list.Count / 2];
    }
}