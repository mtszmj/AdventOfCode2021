using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day21Task2
{
    public const int WinningPoints = 21;

    public long Solve(string input)
    {
        var inputLines = input.Split(Environment.NewLine);
        var pos1 = int.Parse(Regex.Match(inputLines[0], @"^Player 1 starting position: (\d+)$").Groups[1].Value);
        var pos2 = int.Parse(Regex.Match(inputLines[1], @"^Player 2 starting position: (\d+)$").Groups[1].Value);
        var dice = InitDiceUniverses();
        var movementTable = InitAllMovements(dice)
            .OrderBy(x => x.Position)
            .GroupBy(x => x.Position)
            .ToDictionary(x => x.Key, x => x.ToArray());

        var queue = new Queue<(int Position1, int Position2, int Points1, int Points2, bool PlayerOneTurn, long NumberOfUniverses)>();
        queue.Enqueue((pos1, pos2, 0, 0, true, 1));
        var player1Wins = 0L;
        var player2Wins = 0L;
        while (queue.TryDequeue(out var game))
        {
            
            if (game.PlayerOneTurn)
            {
                var allUniverses = movementTable[game.Position1];
                foreach(var universe in allUniverses)
                {
                    var points = game.Points1 + universe.FinishPosition;
                    if(points >= WinningPoints)
                    {
                        player1Wins += game.NumberOfUniverses * universe.NumberOfUniverses;
                        continue;
                    }
                    queue.Enqueue((universe.FinishPosition, game.Position2, game.Points1 + universe.FinishPosition, game.Points2, false, game.NumberOfUniverses * universe.NumberOfUniverses));
                }
            }
            else
            {
                var allUniverses = movementTable[game.Position2];
                foreach (var universe in allUniverses)
                {
                    var points = game.Points2 + universe.FinishPosition;
                    if (points >= WinningPoints)
                    {
                        player2Wins += game.NumberOfUniverses * universe.NumberOfUniverses;
                        continue;
                    }
                    queue.Enqueue((game.Position1, universe.FinishPosition, game.Points1, game.Points2 + universe.FinishPosition, true, game.NumberOfUniverses * universe.NumberOfUniverses));
                }
            }
        }

        return player1Wins > player2Wins ? player1Wins : player2Wins;
    }

    
    /// <summary>
    /// Returns sum of three dice rolls with how many times this sum occurs (how many universes)
    /// </summary>
    /// <returns></returns>
    private Dictionary<int, int> InitDiceUniverses()
    {
        // 1->1->1 = 3      // 2->1->1 = 4      // 3->1->1 = 5
        // 1->1->2 = 4      // 2->1->2 = 5      // 3->1->2 = 6
        // 1->1->3 = 5      // 2->1->3 = 6      // 3->1->3 = 7
        // 1->2->1 = 4      // 2->2->1 = 5      // 3->2->1 = 6
        // 1->2->2 = 5      // 2->2->2 = 6      // 3->2->2 = 7
        // 1->2->3 = 6      // 2->2->3 = 7      // 3->2->3 = 8
        // 1->3->1 = 5      // 2->3->1 = 6      // 3->3->1 = 7
        // 1->3->2 = 6      // 2->3->2 = 7      // 3->3->2 = 8
        // 1->3->3 = 7      // 2->3->3 = 8      // 3->3->3 = 9

        // Group by sum value
        // 1->1->1 = 3 (1)
        // .
        // 1->1->2 = 4     
        // 1->2->1 = 4     
        // 2->1->1 = 4 (3)
        // etc.

        return Enumerable.Range(1, 3)
            .SelectMany(a => Enumerable.Range(1, 3)
                .SelectMany(b => Enumerable.Range(1, 3)
                    .Select(c => (a, b, c))
                    )
                )
            .GroupBy(x => x.a + x.b + x.c).ToDictionary(x => x.Key, v => v.Count());
    }

    private IEnumerable<(int Position, int DiceValue, int FinishPosition, int NumberOfUniverses)> InitAllMovements(Dictionary<int, int> diceUniverses)
    {
        foreach(var startingPosition in Enumerable.Range(1, 10))
            foreach (var (diceValue, numberOfUniverses) in diceUniverses)
                yield return (startingPosition, diceValue,  (startingPosition - 1 + diceValue) % 10 + 1, numberOfUniverses);
    }

}