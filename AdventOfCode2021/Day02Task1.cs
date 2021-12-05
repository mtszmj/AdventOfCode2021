namespace AdventOfCode2021;
public class Day02Task1
{
    public Day02Task1()
    {
        moveFuncByCommand = new Dictionary<string, Func<int, Position, Position>>
        {
            ["forward"] = (commandValue, position) => position with { Horizontal = position.Horizontal + commandValue },
            ["down"] = (commandValue, position) => position with { Depth = position.Depth + commandValue },
            ["up"] = (commandValue, position) => position with { Depth = position.Depth - commandValue },
        };
    }

    protected readonly Dictionary<string, Func<int, Position, Position>> moveFuncByCommand;

    public Position MoveSubmarine(string[] commands)
    {
        var result = new Position(0, 0);
        foreach (var cmd in commands) 
        {
            var nameAndValue = cmd.Split(" ", StringSplitOptions.TrimEntries);
            result = moveFuncByCommand[nameAndValue[0]].Invoke(int.Parse(nameAndValue[1]), result);
        }
        return result;
    }
}

public record Position(int Horizontal, int Depth)
{
    public int Multiplication => Horizontal * Depth;
}
