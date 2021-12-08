namespace AdventOfCode2021;
public class Day08Task2 : Day08Task1
{
    protected Dictionary<string, int> DisplayToValue = new Dictionary<string, int>
    {
        ["abcefg"] = 0,
        ["cf"] = 1,
        ["acdeg"] = 2,
        ["acdfg"] = 3,
        ["bcdf"] = 4,
        ["abdfg"] = 5,
        ["abdefg"] = 6,
        ["acf"] = 7,
        ["abcdefg"] = 8,
        ["abcdfg"] = 9,
    };

    public int CountOutput(Display[] displays)
    {
        return displays.Select(GetDisplayValue).Sum();
    }

    public int GetDisplayValue(Display display)
    {
        var charTranslation = display.Digits
            .SelectMany(x => x)
            .GroupBy(x => x)
            .ToDictionary(x => x.Key, x => x.Count())
            .Select(x => new Translation
                {
                    Input = x.Key,
                    CountForAll = x.Value
                })
            .ToDictionary(x => x.Input, x => x);

        foreach (var character in display.Digits
            .Where(x => !LengthsToCount.Contains(x.Length))
            .SelectMany(x => x)
            .GroupBy(x => x)
            )
        {
            charTranslation[character.Key].CountWithout1478 = character.Count();
            charTranslation[character.Key].Translate();
        }

        var value = 0;
        foreach (var output in display.Output)
        {
            var digit = string.Join("", output.Select(x => charTranslation[x].Output).OrderBy(x => x));
            value = value * 10 + DisplayToValue[digit];
        }

        return value;
    }

    public class Translation
    {
        public static Dictionary<(int, int), char> Trans = new Dictionary<(int, int), char>
        {
            // (count of segment in all 10 letters, count without 1478) = segment letter
            [(8, 6)] = 'a',
            [(6, 4)] = 'b',
            [(8, 4)] = 'c',
            [(7, 5)] = 'd',
            [(4, 3)] = 'e',
            [(9, 5)] = 'f',
            [(7, 6)] = 'g',
        };

        public char Input { get; set; }
        public char Output { get; set; }
        public int CountForAll { get; set; }
        public int CountWithout1478 { get; set; }

        public void Translate()
        {
            Output = Trans[(CountForAll, CountWithout1478)];
        }
    }
}