namespace AdventOfCode2021;
public class Day12Task2 : Day12Task1
{
    protected override Path CreatePath(Node node) => new Path2(node);
    protected override Path CreatePath(Path path, Node node) => new Path2(path, node);

    public class Path2 : Path
    {
        public Path2(Node startNode) : base(startNode)
        {
        }

        public Path2(Path path, Node node) : base(path, node)
        {
            if (path is Path2 p)
                visitedSmallCaveTwice = p.visitedSmallCaveTwice;

            if (node.MaxVisits == 1 && Visited.ContainsKey(node) && Visited[node] == 2)
                visitedSmallCaveTwice = true;
        }

        protected bool visitedSmallCaveTwice;

        public override bool CanVisit(Node node)
        {
            return base.CanVisit(node) || (node.MaxVisits == 1 && visitedSmallCaveTwice == false && node.Name != "start" && node.Name != "end");
        }

    }
}