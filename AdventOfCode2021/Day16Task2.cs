namespace AdventOfCode2021;
public class Day16Task2 : Day16Task1
{
    public long Calculate(string input)
    {
        var bin = ToBinary(input);
        var queue = new Queue<string>();
        SumVersions(bin, out var end, queue);

        var main = ToOperation(queue.Dequeue());
        var level = 0;
        var current = main;
        var stack = new Stack<IOperation>();
        while (queue.Any())
        {
            var op = queue.Dequeue();
            if (op == "(")
            {
                stack.Push(current);
                level++;
            }
            else if (op == ")")
            {
                stack.Pop();
                stack.TryPeek(out current);
                level--;
            }
            else
            {
                var newOp = ToOperation(op);
                current.Operations.Add(newOp);
                if(newOp is not SingleValue)
                    current = newOp;
            }
        }

        return main.Value;
        //while (queue.Any())
        //{
        //    var cmd = queue.Pop();
        //    if(long.TryParse(cmd, out var value))
        //        values.Add(value);
        //    else
        //    {
        //        var result = cmd switch
        //        {
        //            "+" => values.Sum(),
        //            "*" => values.Aggregate(1L, (a, v) => a * v),
        //            "min" => values.Min(),
        //            "max" => values.Max(),
        //            ">" => values.First() > values.Skip(1).First() ? 1 : 0,
        //            "<" => values.First() < values.Skip(1).First() ? 1 : 0,
        //            "==" => values.First() < values.Skip(1).First() ? 1 : 0,
        //            _ => throw new InvalidOperationException()
        //        };
        //        values.Clear();
        //        queue.Push(result.ToString());
        //    }
        //}

        //return values.First();
    }

    public static IOperation ToOperation(string op)
    {
        if(long.TryParse(op, out var value))
            return new SingleValue { Value = value };

        return op switch
        {
            "+" => new Addition(),
            "*" => new Product(),
            "min" => new Min(),
            "max" => new Max(),
            ">" => new Greater(),
            "<" => new Less(),
            "==" => new Equal(),
            _ => throw new InvalidOperationException()
        };
    }

    public class SingleValue : IOperation
    {
        public long Value { get; set; }
        public List<IOperation> Operations { get; } = new();
    }

    public class Addition : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations.Sum(x => x.Value);
    }

    public class Product : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations.Aggregate(1L, (a, v) => a * v.Value);
    }

    public class Min : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations.Min(x => x.Value);
    }

    public class Max : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations.Max(x => x.Value);
    }

    public class Greater : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations[0].Value > Operations[1].Value ? 1L : 0L;
    }

    public class Less : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations[0].Value < Operations[1].Value ? 1L : 0L;
    }

    public class Equal : IOperation
    {
        public List<IOperation> Operations { get; } = new();
        public long Value => Operations[0].Value == Operations[1].Value ? 1L : 0L;
    }

    public interface IOperation
    {
        long Value { get; }
        List<IOperation> Operations { get; }
    }
}