namespace AdventOfCode2021
{
    public class Day05Task2 : Day05Task1
    {
        public override OceanFloor ParseInput(string[] lines)
        {
            return new OceanFloor2(lines.Select(SplitValues).ToArray());
        }

        public class OceanFloor2 : OceanFloor
        {
            public OceanFloor2((int x1, int y1, int x2, int y2)[] coords) : base(coords)
            {
                //Console.WriteLine(Print());
                foreach (var coord in coords)
                {
                    if (IsNotDiagonal(coord))
                        continue;

                    var diff = Math.Abs(coord.x1 - coord.x2);
                    var xAdd = (coord.x2 - coord.x1) > 0 ? 1 : -1;
                    var yAdd = (coord.y2 - coord.y1) > 0 ? 1 : -1;

                    for (int iX = 0, iY = 0; iX <= diff && iY <= diff; iX++, iY++)
                    {
                        var x = coord.x1 + iX * xAdd;
                        var y = coord.y1 + iY * yAdd;
                        
                        Diagram[(x, y)] = Diagram.GetValueOrDefault((x, y), 0) + 1;
                        MaxX(x);
                        MaxY(y);
                    }
                }

            }

            protected bool IsNotDiagonal((int x1, int y1, int x2, int y2) coord)
            {
                return Math.Abs(coord.x1 - coord.x2) != Math.Abs(coord.y1 - coord.y2);
            }
        }
    }
}
