namespace AdventOfCode2021;
public class Day14Task1
{
    public long Solve(string input, int iterations)
    {
        // parse
        var parts = input.Split($"{Environment.NewLine}{Environment.NewLine}");
        var text = parts[0];
        var rules = parts[1].Split(Environment.NewLine).Select(x => x.Split(" -> ")).ToDictionary(x => x[0], x => x[1]);

        // keep track of text by storing pair of chars only - no need to know exact order of letters
        var pairs = new Dictionary<string, long>();
        for (var i = 0; i < text.Length - 1; i++)
            pairs[text[i..(i + 2)]] = pairs.GetValueOrDefault(text[i..(i + 2)]) + 1;

        // perform iterations
        for (var i = 0; i < iterations; i++)
        {
            var newPairs = new Dictionary<string, long>();
            foreach (var pair in pairs)
            {
                var insert = rules[pair.Key];
                var p1 = $"{pair.Key[0]}{insert}";
                var p2 = $"{insert}{pair.Key[1]}";
                newPairs[p1] = newPairs.GetValueOrDefault(p1) + pair.Value;
                newPairs[p2] = newPairs.GetValueOrDefault(p2) + pair.Value;
            }
            pairs = newPairs;
        }

        // count letters
        var letterCount = new Dictionary<char, long>();
        foreach (var pair in pairs)
        {
            letterCount[pair.Key[0]] = letterCount.GetValueOrDefault(pair.Key[0]) + pair.Value;
            letterCount[pair.Key[1]] = letterCount.GetValueOrDefault(pair.Key[1]) + pair.Value;
        }
        // first and last letter is not counted twice (as all in the middle), therefore add 1
        letterCount[text[0]]++;
        letterCount[text.Last()]++;

        return (letterCount.Values.Max() - letterCount.Values.Min()) / 2;
    }
}