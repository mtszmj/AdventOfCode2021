namespace AdventOfCode2021;
public class Day18Task2 : Day18Task1
{
    public override long Solve(string input)
    {
        var pairs = input.Split(Environment.NewLine).Select(x => Parse(x)).ToArray();

        List<(Pair left, Pair right)> toSum = new();
        for(var i = 0; i < pairs.Length - 1; i++)
            for(var j = i+1; j < pairs.Length; j++)
            {
                toSum.Add((pairs[i], pairs[j]));
                toSum.Add((pairs[j], pairs[i]));
            }

        return toSum.Max(x => (x.left.DeepCopy() as Pair).SumAndReduce(x.right.DeepCopy() as Pair).Magnitude());
    }
}