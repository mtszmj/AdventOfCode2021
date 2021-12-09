namespace AdventOfCode2021;
public class Day09Task2 : Day09Task1
{
    public List<int> FindBasinSizes(string[] lines)
    {
        var points = ParseInput(lines);
        var lowPoints = FindLowPoints(points).ToList();

        var maxRow = points.GetLength(0) - 1;
        var maxColumn = points.GetLength(1) - 1;

        var basinSizes = new List<int>();
        foreach (var point in lowPoints)
        {
            var basin = new HashSet<Point> { point };
            FindBasin(point, basin);
            basinSizes.Add(basin.Count);
        }

        return basinSizes;

        void FindBasin(Point point, HashSet<Point> basin)
        {
            var higherPoints = new HashSet<Point>();
            for (var row = point.Row - 1; row <= point.Row + 1; row++)
            {
                if (row < 0 || row > maxRow)
                    continue;

                for (var column = point.Column - 1; column <= point.Column + 1; column++)
                {
                    if (column < 0 || column > maxColumn)
                        continue;
                    if (row != point.Row && column != point.Column)
                        continue;

                    var checkedPoint = points[row, column];
                    if (checkedPoint.Height >= point.Height && checkedPoint.Height < 9 && !basin.Contains(points[row, column]))
                        higherPoints.Add(points[row, column]);
                }
            }

            // first add not to go through one point multiple (check contains)
            foreach (var p in higherPoints)
                basin.Add(point);
            foreach (var p in higherPoints)
                FindBasin(p, basin);
        }
    }

    public int FindThreeBasinsMultiplication(string[] lines)
    {
        return FindBasinSizes(lines).OrderByDescending(x => x).Take(3).Aggregate(1, (a, v) => a * v);
    }

}