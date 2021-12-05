using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day05Task1
    {
        private static string[] Separators =new [] {",", " -> " };
        public virtual OceanFloor ParseInput(string[] lines)
        {
            return new OceanFloor(lines.Select(SplitValues).ToArray());
        }

        public (int x1, int y1, int x2, int y2) SplitValues(string values)
        {
            var vals = values.Split(Separators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x)).ToArray();

            if (vals.Length != 4)
                throw new ArgumentException($"values are not in a correct format: {values} -> {string.Join(",", vals)}");

            return (x1: vals[0], y1: vals[1], x2: vals[2], y2: vals[3]);
        }

        public class OceanFloor
        {
            protected Dictionary<(int x, int y), int> Diagram = new Dictionary<(int x, int y), int>();
            private int maxX;
            private int maxY;

            public OceanFloor((int x1, int y1, int x2, int y2)[] coords)
            {
                foreach (var coord in coords)
                {
                    // check if neither vertical nor horizontal
                    if (IsNotHorizontalNorVertival(coord))
                        continue;

                    var (xl, xh) = coord.x1 <= coord.x2 ? (coord.x1, coord.x2) : (coord.x2, coord.x1);
                    var (yl, yh) = coord.y1 <= coord.y2 ? (coord.y1, coord.y2) : (coord.y2, coord.y1);
                    for (var x = xl; x <= xh; x++)
                        for (var y = yl; y <= yh; y++)
                        {
                            if (Diagram.ContainsKey((x, y)))
                            {
                                Diagram[(x, y)]++;
                                MaxX(x);
                                MaxY(y);
                            }
                            else
                            {
                                Diagram[(x, y)] = 1;
                                MaxX(x);
                                MaxY(y);
                            }
                        }
                }
            }

            protected bool IsNotHorizontalNorVertival((int x1, int y1, int x2, int y2) coord)
            {
                return coord.x1 != coord.x2 && coord.y1 != coord.y2;
            }

            protected void MaxX(int value)
            {
                if (maxX < value)
                    maxX = value;
            }
            protected void MaxY(int value)
            {
                if (maxY < value)
                    maxY = value;
            }

            public int LinesOverlap(int numbersOfOverlap)
            {
                return Diagram.Values.Count(x => x >= numbersOfOverlap);
            }

            public string Print()
            {
                var sb = new StringBuilder();
                for(var y = 0; y <= maxY; y++)
                {
                    for(var x = 0; x <= maxX; x++)
                    {
                        if (Diagram.ContainsKey((x, y)))
                            sb.Append(Diagram[(x, y)]);
                        else
                            sb.Append(".");
                    }
                    if (y < maxY)
                        sb.Append(Environment.NewLine);
                }

                return sb.ToString();
            }
        }
    }
}
