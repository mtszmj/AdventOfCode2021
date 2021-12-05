namespace AdventOfCode2021;
public class Day04Task1
{
    public virtual Bingo ParseInput(string text)
    {
        var (numbers, boards) = ParseInputData(text);
        var bingo = new Bingo(numbers,boards);
        return bingo;
    }

    protected static (int[] numbers, List<Board> boards) ParseInputData(string text)
    {
        var lines = text.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        var numbers = lines[0].Split(',').Select(x => int.Parse(x)).ToArray();
        var row = 0;
        int[,] boardValues = new int[Board.BoardSize, Board.BoardSize];
        var boards = new List<Board>();
        foreach (var line in lines.Skip(1))
        {
            if (string.IsNullOrEmpty(line))
            {
                row = 0;
                continue;
            }

            var col = 0;
            foreach (var el in line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)))
            {
                boardValues[row, col++] = el;
            }
            row++;
            if (row == Board.BoardSize)
            {
                boards.Add(new Board(boardValues));
                boardValues = new int[Board.BoardSize, Board.BoardSize];
            }
        }

        return (numbers, boards);
    }

    public class Bingo
    {
        public Bingo(IEnumerable<int> numbers, IEnumerable<Board> boards)
        {
            Numbers = numbers.ToArray();
            Boards = boards.ToArray();
        }

        public int[] Numbers { get; set; }
        public Board[] Boards { get; set; }

        public virtual long Play()
        {
            foreach(var number in Numbers)
            {
                foreach(var board in Boards)
                {
                    if (board.MarkValue(number))
                    {
                        return CountWinningResult(board, number);
                    }
                }
            }

            return 0;
        }

        public long CountWinningResult(Board board, int number)
        {
            return board.SumOfUnmarked() * number;
        }
    }

    public class Board
    {
        public const int BoardSize = 5;
        private bool isWinning;
        private Cell[,] Cells = new Cell[BoardSize, BoardSize];
        private Dictionary<int, (Cell cell, int row, int col)> CellByValue = new Dictionary<int, (Cell, int, int)>();

        public Board(int[,] values)
        {
            if (values.GetLength(0) != BoardSize || values.GetLength(1) != BoardSize)
                throw new ArgumentException("Incorrect size of board", nameof(values));

            for (var row = 0; row < BoardSize; row++)
            { 
                for (var col = 0; col < BoardSize; col++)
                {
                    Cells[row, col] = new Cell(values[row, col]);
                    CellByValue[values[row, col]] = (Cells[row, col], row, col);
                }
            }
        }

        public bool IsWinning => isWinning;

        public bool MarkValue(int value)
        {
            if(CellByValue.TryGetValue(value, out var tuple))
            {
                var (cell, row, col) = tuple;
                cell.Set();
                isWinning = CheckWinning(row, col);
            }
                
            return IsWinning;
        }

        public long SumOfUnmarked()
        {
            return CellByValue.Select(x => x.Value.cell).Where(x => !x.IsMarked).Sum(x => x.Value);
        }

        private bool CheckWinning(int row, int col)
        {
            bool isRow = true;
            bool isCol = true;
            for(var i = 0; i < BoardSize; i++)
            {
                isRow &= Cells[row, i].IsMarked;
                isCol &= Cells[i, col].IsMarked;

                if (!isRow && !isCol)
                    return false;
            }

            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for(var row = 0; row < BoardSize; row++)
            {
                for (var col = 0; col < BoardSize-1; col++)
                {
                    sb.AppendFormat($"{Cells[row, col].Value,2} ");
                }
                sb.AppendFormat($"{Cells[row, BoardSize-1].Value,2}{Environment.NewLine}");
            }
            sb.Remove(sb.Length - Environment.NewLine.Length, Environment.NewLine.Length);

            return sb.ToString();
        }
    }

    public class Cell
    {
        private bool isMarked;

        public Cell(int value)
        {
            Value = value;
        }

        public int Value { get; }
        public bool IsMarked => isMarked;
        public void Set()
        {
            isMarked = true;
        }
    }

}