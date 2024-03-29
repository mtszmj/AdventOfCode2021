﻿namespace AdventOfCode2021;
public class Day15Task1
{
    public class Field
    {
        public Field(int value, long sum)
        {
            Value = value;
            Sum = sum;
        }

        public int Value { get; set; }
        public long Sum { get; set; }
    }

    public long Solve(string input)
    {
        var fields = Parse(input);
        ValueRiskInEachDirectionAndMove(fields);

        return fields[fields.GetLength(0) - 1, fields.GetLength(1) - 1].Sum;
    }

    protected virtual Field[,] Parse(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries).ToArray();
        var fields = new Field[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
            for (var j = 0; j < lines[i].Length; j++)
                fields[i, j] = new Field(int.Parse(lines[i].Substring(j, 1)), long.MaxValue);

        fields[0, 0].Sum = 0L;
        return fields;
    }

    private static void ValueRiskInEachDirectionAndMove(Field[,] fields)
    {
        var queue = new PriorityQueue<(int row, int col), long>();
        queue.Enqueue((0, 0), 0);
        var maxRow = fields.GetLength(0);
        var maxCol = fields.GetLength(1);
        do
        {
            var current = queue.Dequeue();
            var field = fields[current.row, current.col];
            if (current.row - 1 > 0
                && (field.Sum + fields[current.row - 1, current.col].Value < fields[current.row - 1, current.col].Sum))
            {
                fields[current.row - 1, current.col].Sum = field.Sum + fields[current.row - 1, current.col].Value;
                queue.Enqueue((current.row - 1, current.col), fields[current.row - 1, current.col].Sum);
            }
            if (current.row + 1 < maxRow
                && (field.Sum + fields[current.row + 1, current.col].Value < fields[current.row + 1, current.col].Sum))
            {
                fields[current.row + 1, current.col].Sum = field.Sum + fields[current.row + 1, current.col].Value;
                queue.Enqueue((current.row + 1, current.col), fields[current.row + 1, current.col].Sum);
            }
            if (current.col - 1 > 0
                && (field.Sum + fields[current.row, current.col - 1].Value < fields[current.row, current.col - 1].Sum))
            {
                fields[current.row, current.col - 1].Sum = field.Sum + fields[current.row, current.col - 1].Value;
                queue.Enqueue((current.row, current.col - 1), fields[current.row, current.col - 1].Sum);
            }
            if (current.col + 1 < maxCol
                && (field.Sum + fields[current.row, current.col + 1].Value < fields[current.row, current.col + 1].Sum))
            {
                fields[current.row, current.col + 1].Sum = field.Sum + fields[current.row, current.col + 1].Value;
                queue.Enqueue((current.row, current.col + 1), fields[current.row, current.col + 1].Sum);
            }
        }
        while (queue.Count > 0);
    }
}