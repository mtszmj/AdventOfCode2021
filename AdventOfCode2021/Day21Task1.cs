using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day21Task1
{
    public long Solve(string input)
    {
        var inputLines = input.Split(Environment.NewLine);
        var pos1 = int.Parse(Regex.Match(inputLines[0], @"^Player 1 starting position: (\d+)$").Groups[1].Value);
        var pos2 = int.Parse(Regex.Match(inputLines[1], @"^Player 2 starting position: (\d+)$").Groups[1].Value);
        var dice = InitDice().ToArray();
        var (score1, score2) = (0, 0);
        var isPlayerOneTurn = true;
        var diceRoll = 0;
        while(score1 < 1000 && score2 < 1000)
        {
            var rollValue = dice[diceRoll % dice.Length];

            if (isPlayerOneTurn)
            {
                pos1 = (pos1 - 1 + rollValue) % 10 + 1;
                (score1, score2) = (score1 + pos1, score2);
            }
            else
            {
                pos2 = (pos2 - 1 + rollValue) % 10 + 1;
                (score1, score2) = (score1, score2 + pos2);
            }
            diceRoll++;
            isPlayerOneTurn = !isPlayerOneTurn;
        }

        return (score1 < score2 ? score1 : score2) * diceRoll * 3;
    }

    public IEnumerable<int> InitDice()
    {
        var i = 0;
        do
        {
            var (a, b, c) = ((i % 100) + 1, ((i + 1) % 100) + 1, ((i + 2) % 100 + 1));
            yield return a + b + c;
            i = (i + 3) % 100;
        }
        while (i != 0);
    }
}