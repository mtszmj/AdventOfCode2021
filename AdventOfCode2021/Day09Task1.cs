namespace AdventOfCode2021;
public class Day09Task1
{
    public record Point(int Row, int Column, int Height);
 
    public Point[,] ParseInput(string[] lines)
    {
        Point[,] points = new Point[lines.Length, lines[0].Length];
        for (int row = 0; row < lines.Length; row++)
            for (int col = 0; col < lines[0].Length; col++)
                points[row, col] = new Point(row, col, lines[row][col] - '0');

        return points;
    }

    public IEnumerable<Point> FindLowPoints(string[] lines)
    {
        var points = ParseInput(lines);

        var maxRow = points.GetLength(0) - 1;
        var maxColumn = points.GetLength(1) - 1;
        for (var row = 0; row <= maxRow; row++)
            for(var col = 0; col <= maxColumn; col++)
            {
                if(
                    (row == 0 || (points[row, col].Height < points[row - 1, col].Height))
                    && (col == 0 || (points[row, col].Height < points[row, col - 1].Height))
                    && (row == maxRow || (points[row, col].Height < points[row + 1, col].Height))
                    && (col == maxColumn || (points[row, col].Height < points[row, col + 1].Height))
                    )
                {
                    yield return points[row, col];
                }
            }
    }

    public int SumRiskLevel(string[] lines)
    {
        return FindLowPoints(lines).Sum(x => x.Height + 1);
    }
}