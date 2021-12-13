using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day13Task1
{
    public Paper Parse(string[] lines)
    {
        Paper paper = new Paper();
        var pointsPart = true;
        for (int i = 0; i < lines.Length; i++)
        {
            string? line = lines[i];
            if(pointsPart)
            {
                var point = line.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                if(point.Length < 2)
                    pointsPart = false;
                else paper.AddPoint(int.Parse(point[0]), int.Parse(point[1]));
            }
            else
            {
                var match = Regex.Match(line, @$"^fold along ([xy])=(\d+)$", RegexOptions.Compiled);
                if(match.Success)
                {
                    paper.AddFold(match.Groups[1].Value[0], int.Parse(match.Groups[2].Value)); 
                }
            }
        }
        return paper;
    } 

    public virtual int Solve(string input)
    {
        var paper = Parse(input.Split(Environment.NewLine));
        paper.Fold();
        return paper.CountDots();
    }

    public class Paper
    {
        public HashSet<(int x, int y)> Points { get; } = new();
        public Queue<(char xy, int position)> Folds { get; } = new();

        public (int MinX, int MaxX) xRange = (0, int.MinValue);
        public (int MinY, int MaxY) yRange = (0, int.MinValue);

        public int FoldAll()
        {
            while (Folds.Any())
                Fold();

            return CountDots();
        }   

        public void Fold()
        {
            var (c, position) = Folds.Dequeue();
            if(c == 'x')
            {
                foreach(var (x, y) in Points.Where(xy => xy.x >= position).ToList())
                {
                    Points.Remove((x, y));
                    xRange = ((x - position) < xRange.MinX ? (x - position) : xRange.MinX, position - 1);
                    if(x > position)
                        Points.Add((position - (x - position), y));
                }
            }
            else if (c == 'y')
            {
                foreach (var (x, y) in Points.Where(xy => xy.y >= position).ToList())
                {
                    Points.Remove((x, y));
                    yRange = ((y - position) < yRange.MinY ? (y - position) : yRange.MinY, position - 1);
                    if (y > position)
                        Points.Add((x, position - (y - position)));
                }
            }
        }

        public int CountDots()
        {
            return Points.Count();
        }

        public void AddPoint(int x, int y)
        {
            Points.Add((x, y));

            xRange = (xRange.MinX > x ? x : xRange.MinX, xRange.MaxX < x ? x : xRange.MaxX);
            yRange = (yRange.MinY > y ? y : yRange.MinY, yRange.MaxY < y ? y : yRange.MaxY);
        }

        public void AddFold(char c, int position)
        {
            Folds.Enqueue((c, position));
        }

        public string Print()
        {
            var sb = new StringBuilder();
            for (var y = yRange.MinY; y <= yRange.MaxY; y++)
            {
                for (var x = xRange.MinX; x <= xRange.MaxX; x++)
                    sb.Append(Points.Contains((x, y)) ? "#" : ".");
                if (y < yRange.MaxY) sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}