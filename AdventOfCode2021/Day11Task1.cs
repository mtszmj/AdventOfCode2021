namespace AdventOfCode2021;
public class Day11Task1
{
    public (string State, long Flashes) Simulate(string input, int iterations)
    {
        var data = Parse(input);
        var flashes = 0L;
        for (var iteration = 0; iteration < iterations; iteration++)
        {
            var adjacement = new Queue<(int i, int j)>();
            // Add Energy
            for (var i = 0; i < data.GetLength(0); i++)
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    data[i, j]++;
                    if (data[i, j] == 10)
                    {
                        for (var k = i - 1; k <= i + 1; k++)
                            for (var m = j - 1; m <= j + 1; m++)
                            {
                                if (k < 0 || k >= data.GetLength(0) || m < 0 || m >= data.GetLength(1))
                                    continue;

                                if (data[k, m] == 10)
                                    continue;

                                adjacement.Enqueue((k, m));
                            }
                    }
                }

            while (adjacement.TryDequeue(out var current))
            {
                if (data[current.i, current.j] >= 10)
                    continue;

                data[current.i, current.j]++;
                if(data[current.i, current.j] == 10)
                {
                    for (var k = current.i - 1; k <= current.i + 1; k++)
                        for (var m = current.j - 1; m <= current.j + 1; m++)
                        {
                            if (k < 0 || k >= data.GetLength(0) || m < 0 || m >= data.GetLength(1))
                                continue;

                            if (data[k, m] == 10)
                                continue;

                            adjacement.Enqueue((k, m));
                        }
                }
            }

            // Count flashes and zero
            for (var i = 0; i < data.GetLength(0); i++)
                for (var j = 0; j < data.GetLength(1); j++)
                {
                    if (data[i, j] > 10)
                        throw new InvalidDataException($"Iteration: {iteration}, [{i},{j}]: {data[i,j]}\n{Print(data)}");
                    else if (data[i,j] == 10)
                    {
                        flashes++;
                        data[i, j] = 0;
                    }
                }
        }
        return (Print(data), flashes);
    }

    protected int[,] Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();
        var result = new int[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
            for (var j = 0; j < lines[i].Length; j++)
                result[i, j] = int.Parse(lines[i][j].ToString());

        return result;
    }

    protected string Print(int[,] data)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < data.GetLength(0); i++)
        { 
            for (var j = 0; j < data.GetLength(1); j++)
                sb.Append(data[i, j]);
            
            if(i < data.GetLength(0) - 1)
                sb.AppendLine();
        }
        return sb.ToString();
    }
}