namespace AdventOfCode2021;
public class Day04Task2 : Day04Task1
{
    public override Bingo ParseInput(string text)
    {
        var (numbers, boards) = ParseInputData(text);
        var bingo = new Bingo2(numbers, boards);
        return bingo;
    }

    public class Bingo2 : Bingo
    {
        public Bingo2(IEnumerable<int> numbers, IEnumerable<Board> boards) : base(numbers, boards)
        {
        }

        public override long Play()
        {
            var boardsCount = Boards.Length;
            var boards = Boards.ToList();

            foreach(var number in Numbers)
            {
                for (int i = 0; i < boardsCount; i++)
                {
                    Board? board = boards[i];
                    if (board.MarkValue(number))
                    {
                        boards.Remove(board);
                        boardsCount--;
                        i--;
                        if(boardsCount == 0)
                        {
                            return CountWinningResult(board, number);
                        }
                    }
                }
            }

            return 0;
        }
    }
}