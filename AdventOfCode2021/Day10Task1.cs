namespace AdventOfCode2021;
public class Day10Task1
{
    protected static readonly Dictionary<char, char> closingCharacter = new Dictionary<char, char>
    {
        ['('] = ')',
        ['['] = ']',
        ['{'] = '}',
        ['<'] = '>',
    };

    protected static readonly Dictionary<char, int> valueCharacter = new Dictionary<char, int>
    {
        [')'] = 3,
        [']'] = 57,
        ['}'] = 1197,
        ['>'] = 25137,
    };

    public char? FindIllegal(string line)
    {
        var stack = new Stack<char>();
        foreach(var c in line)
        {
            if (closingCharacter.ContainsKey(c))
                stack.Push(c);
            else if (stack.Count == 0)
                return c;
            else if (c == closingCharacter[stack.Peek()])
                stack.Pop();
            else return c;
        }

        return null;
    }

    public long ValueIllegal(string input)
    {
        var c = FindIllegal(input);
        if (c is null) return 0;

        return valueCharacter[c.Value];
    }

    public long SumIllegal(string[] input)
    {
        return input.Select(ValueIllegal).Sum();
    }
}