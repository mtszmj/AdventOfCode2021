namespace AdventOfCode2021;
public class Day12Task1
{
    public List<Path> Solve(string[] input)
    {
        var graph = Graph.Create(input);
        var paths = Traverse(graph).ToList();
        return paths;
    }

    public IEnumerable<Path> Traverse(Graph graph)
    {
        var path = new Path(graph.Nodes["start"]);
        var paths = new Queue<Path>();
        paths.Enqueue(path);

        while (paths.Any())
        {
            var current = paths.Dequeue();
            var lastNode = current.Nodes.Last();
            foreach (var n in lastNode.GetConnectedNodes())
            {
                if(n.Name == "end")
                    yield return new Path(current, n);
                else if (current.CanVisit(n))
                    paths.Enqueue(new Path(current, n));
            }
        }
    }


    public class Path
    {
        public Path(Node startNode)
        {
            Visited = new() { [startNode] = 1 };
            Nodes = new() { startNode };
        }

        public Path(Path path, Node node)
        {
            Visited = new Dictionary<Node, int>(path.Visited);
            Nodes = new List<Node>(path.Nodes);

            Nodes.Add(node);
            Visited[node] = Visited.GetValueOrDefault(node, 0) + 1;
        }

        Dictionary<Node, int> Visited { get; }
        public List<Node> Nodes { get; }


        public bool CanVisit(Node node)
        {
            return !Visited.ContainsKey(node) || Visited[node] < node.MaxVisits;
        }

        public override string ToString()
        {
            return string.Join(",", Nodes);
        }
    }

    public class Graph
    {
        public Dictionary<string,Node> Nodes { get; } = new Dictionary<string,Node>();

        public static Graph Create(string[] paths)
        {
            var graph = new Graph();
            foreach(var path in paths)
            {
                var nodes = path.Split('-', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
                graph.AddConnection(nodes[0], nodes[1]);
            }
            return graph;
        }

        public void AddConnection(string node1, string node2)
        {
            Node n1 = GetOrCreateNode(node1);
            Node n2 = GetOrCreateNode(node2);

            n1.Connect(n2);
        }

        private Node GetOrCreateNode(string nodeName)
        {
            if (Nodes.ContainsKey(nodeName))
                return Nodes[nodeName];
         
            var node = CreateNode(nodeName);
            Nodes.Add(nodeName, node);
            return node;
        }

        public Node CreateNode(string node)
        {
            if(char.IsLower(node[0]))
                return new Node(node, 1);

            return new Node(node, int.MaxValue);
        }
    }

    public class Node
    {
        public Node(string name, int maxVisits)
        {
            Name = name;
            MaxVisits = maxVisits;
        }

        public string Name { get; }
        public int MaxVisits { get; }
        protected HashSet<Node> ConnectedNodes { get; } = new HashSet<Node>();

        public IEnumerable<Node> GetConnectedNodes()
        {
            return ConnectedNodes.ToImmutableHashSet();
        }

        public void Connect(Node node)
        {
            ConnectedNodes.Add(node);
            node.ConnectedNodes.Add(this);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}