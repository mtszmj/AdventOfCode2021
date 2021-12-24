using System.Text.RegularExpressions;

namespace AdventOfCode2021;
public class Day19Task1
{
    public int Solve(string input)
    {
        var scanners = Parse(input).ToArray();
        foreach (var scanner in scanners) scanner.CountBeaconDistances();

        for(var i = 0; i < scanners.Length - 1; i++)
            for(var j = i + 1; j < scanners.Length; j++)
                scanners[i].CheckOverlapping(scanners[j]);

        return int.MinValue;
    }

    public IEnumerable<Scanner> Parse(string input)
    {
        Scanner? current = null;
        foreach (var line in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            var match = Regex.Match(line, @"^--- scanner (?<scannerId>\d+) ---$", RegexOptions.Compiled);
            if (match.Success)
            {
                if (current is not null)
                    yield return current;
                current = new Scanner(int.Parse(match.Groups["scannerId"].Value));
            }
            else
            {
                current.AddPoint(line.Split(',').Select(int.Parse).ToArray());
            }
        }

        yield return current;
    }

    public class Scanner
    {
        public Scanner(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public List<Point> Beacons { get; } = new();

        public List<PointsDistance> Distances { get; } = new();

        public void CountBeaconDistances()
        {
            Distances.Clear();
            for (var i = 0; i < Beacons.Count - 1; i++)
                for (var j = i + 1; j < Beacons.Count; j++)
                {
                    var distance = Math.Round(
                        Math.Sqrt(
                            Math.Pow(Beacons[i].X - Beacons[j].X, 2)
                            + Math.Pow(Beacons[i].Y - Beacons[j].Y, 2)
                            + Math.Pow(Beacons[i].Z - Beacons[j].Z, 2)
                        ), 
                        2);

                    Distances.Add(new(Beacons[i], Beacons[j], distance));
                    Distances.Add(new(Beacons[j], Beacons[i], distance));
                }
        }

        internal IEnumerable<PointsDistance> GetSortedDistancesForPoint(Point p)
        {
            return Distances.Where(x => x.P1 == p).OrderBy(x => x.Distance);
        }

        internal void AddPoint(int[] axis)
        {
            Beacons.Add(new Point(axis[0], axis[1], axis[2]));
        }

        public void CheckOverlapping(Scanner other)
        {
            foreach(var point in Beacons)
            {
                var distances = GetSortedDistancesForPoint(point).ToArray();
                foreach (var otherPoint in other.Beacons)
                {
                    var otherDistances = other.GetSortedDistancesForPoint(otherPoint).ToArray();
                    int i = 0;
                    int j = 0;
                    var aligned = 0;
                    var scanner1 = new List<Point>();
                    var scanner2 = new List<Point>();
                    var corresponding = new List<(Point, Point)>();
                    while (i < distances.Length && j < otherDistances.Length)
                    {
                        if (distances[i].Distance < otherDistances[j].Distance)
                            i++;
                        else if (distances[i].Distance > otherDistances[j].Distance)
                            j++;
                        else
                        {
                            aligned++;
                            scanner1.Add(distances[i].P2);
                            scanner2.Add(otherDistances[j].P2);
                            corresponding.Add((distances[i].P2, otherDistances[j].P2));
                            i++;
                            j++;
                        }
                    }

                    if(aligned >= 11)
                    {

                        scanner1.Insert(0, point);
                        scanner2.Insert(0, otherPoint);
                        corresponding.Insert(0, (point, otherPoint));
                        //Console.WriteLine($"Scanner {Id} aligned with {other.Id} ({aligned})");
                        //Console.WriteLine($"Scanner {Id}:\n{string.Join("\n", scanner1)}");
                        //Console.WriteLine($"Scanner {other.Id}:\n{string.Join("\n", scanner2)}");
                        //Console.WriteLine($"Scanner {Id}-{other.Id}:\n{string.Join("\n", corresponding.Select(x => $"{x.Item1} - {x.Item2}"))}");
                        return;
                    }
                }
            }
        }
    }

    public record Point(int X, int Y, int Z);
    public record PointsDistance(Point P1, Point P2, double Distance);

}