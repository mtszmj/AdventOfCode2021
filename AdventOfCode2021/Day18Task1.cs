namespace AdventOfCode2021;
public class Day18Task1
{
    public interface IElement
    {
        int Level { get; set; }
        IElement? Left { get; set; }
        IElement? Right { get; set; }
        Pair? Parent { get; set; }
        IElement Add(IElement element);
        (int count, int maxLevel) Count();

        Pair Plus(IElement added);
        void SetLevel(int level);
        long Magnitude();

        Pair? SearchExplode();
        Value? SearchLeftValue(IElement explodePair, HashSet<IElement> visited);
        Value? SearchRightValue(IElement explodePair, HashSet<IElement> visited);
    }

    public class Pair : IElement
    {
        public IElement? Left { get; set; }
        public IElement? Right { get; set; }
        public Pair? Parent { get; set; }

        public int Level { get; set; }

        public IElement Add(IElement element)
        {
            if (Left is null)
                Left = element;
            else if (Right is null)
                Right = element;
            else throw new InvalidOperationException();

            element.Parent = this;
            element.Level = Level + 1;

            return element;
        }

        public (int count, int maxLevel) Count()
        {
            if (Left is null && Right is null)
                return (1, Level);

            (int count, int maxLevel) left = default;
            (int count, int maxLevel) right = default;

            if (Left is not null)
                left = Left.Count();
            if (Right is not null)
                right = Right.Count();

            return (left.count + right.count + 1, left.maxLevel > right.maxLevel ? left.maxLevel : right.maxLevel) ;
        }

        public override string ToString()
        {
            return $"[{Left},{Right}]";
        }

        public Pair Plus(IElement added)
        {
            var newPair = new Pair();
            newPair.Add(this);
            newPair.Add(added);
            this.SetLevel(newPair.Level + 1);
            added.SetLevel(newPair.Level + 1);
            return newPair;
        }

        public void SetLevel(int level)
        {
            Level = level;
            Left?.SetLevel(level + 1);
            Right?.SetLevel(level + 1);
        }

        public Pair? SearchExplode()
        {
            if (Level == 4)
                return this;

            var explode = Left?.SearchExplode();
            if (explode is not null)
                return explode;
            explode = Right?.SearchExplode();
            if (explode is not null)
                return explode;

            return null;
        }

        public bool Explode()
        {
            var toExplode = SearchExplode();
            if (toExplode is null)
                return false;

            var leftValue = toExplode.SearchLeftValue(toExplode, new());
            var rightValue = toExplode.SearchRightValue(toExplode, new());

            if (leftValue is not null)
                leftValue.Number += (toExplode.Left as Value)?.Number ?? throw new InvalidOperationException("Explode - left value");

            if (rightValue is not null)
                rightValue.Number += (toExplode.Right as Value)?.Number ?? throw new InvalidOperationException("Explode - right value");

            var zero = new Value() { Level = toExplode.Level, Parent = toExplode.Parent };
            if (toExplode.Parent.Left == toExplode)
                toExplode.Parent.Left = zero;
            else if (toExplode.Parent.Right == toExplode)
                toExplode.Parent.Right = zero;

            return true;
        }

        public Value? SearchLeftValue(IElement explodePair, HashSet<IElement> visited)
        {
            visited.Add(this);

            if (this == explodePair)
            {
                return (Parent as Pair)?.SearchLeftValue(explodePair, visited);
            } 

            if (visited.Contains(Left))
            {
                return (Parent as Pair)?.SearchLeftValue(explodePair, visited);
            }
            else if (visited.Contains(Right))
            {
                var v = Left.SearchLeftValue(explodePair, visited);
                if (v is not null)
                    return v;
                return (Parent as Pair)?.SearchLeftValue(explodePair, visited);
            }
            else
            {
                var v = Right.SearchLeftValue(explodePair, visited);
                if (v is not null)
                    return v;
                v = Left.SearchLeftValue(explodePair, visited);
                if (v is not null)
                    return v;
                return (Parent as Pair)?.SearchLeftValue(explodePair, visited);
            }
        }

        public Value? SearchRightValue(IElement explodePair, HashSet<IElement> visited)
        {
            visited.Add(this);

            if (this == explodePair)
            {
                return (Parent as Pair)?.SearchRightValue(explodePair, visited);
            }

            if (visited.Contains(Right))
            {
                return (Parent as Pair)?.SearchRightValue(explodePair, visited);
            }
            else if (visited.Contains(Left))
            {
                var v = Right.SearchRightValue(explodePair, visited);
                if (v is not null)
                    return v;
                return (Parent as Pair)?.SearchRightValue(explodePair, visited);
            }
            else
            {
                var v = Left.SearchRightValue(explodePair, visited);
                if (v is not null)
                    return v;
                v = Right.SearchRightValue(explodePair, visited);
                if (v is not null)
                    return v;
                return (Parent as Pair)?.SearchRightValue(explodePair, visited);
            }
        }

        public bool Split()
        {
            Value? toSplit = SearchSplit();
            if (toSplit is null)
                return false;

            var left = toSplit.Number / 2;
            var right = left + (toSplit.Number % 2);

            var pair = new Pair() { Level = toSplit.Level, Parent = toSplit.Parent };
            pair.Add(new Value { Number = left });
            pair.Add(new Value { Number = right });

            if (toSplit.Parent?.Left == toSplit)
                toSplit.Parent.Left = pair;
            else if (toSplit.Parent?.Right == toSplit)
                toSplit.Parent.Right = pair;
            else throw new InvalidOperationException();

            return true;
        }

        public Value? SearchSplit()
        {
            Value? toSplit = null;
            if (Left is Value val && (val.Number > 9))
                return val;
            else if (Left is Pair p)
                toSplit = p.SearchSplit();
            
            if (toSplit is not null)
                return toSplit;

            if (Right is Value val2 && (val2.Number > 9))
                return val2;
            else if (Right is Pair p)
                toSplit = p.SearchSplit();

            return toSplit; // Value or null
        }

        public Pair SumAndReduce(Pair right)
        {
            var sum = Plus(right);
            sum.Reduce();
            return sum;
        }

        public void Reduce()
        {
            while (true)
            {
                if (this.Explode())
                    continue;
                if (this.Split())
                    continue;
                break;
            }
        }

        public long Magnitude()
        {
            return 3 * Left.Magnitude() + 2 * Right.Magnitude();
        }
    }

    public class Value : IElement
    {
        public long Number;

        public int Level { get; set; }
        public Pair? Parent { get; set; }
        public IElement? Left { get; set; }
        public IElement? Right { get; set; }

        public IElement Add(IElement element)
        {
            throw new NotImplementedException();
        }

        public (int count, int maxLevel) Count()
        {
            return (1, Level);
        }

        public long Magnitude()
        {
            return Number;
        }

        public Pair Plus(IElement added)
        {
            throw new NotImplementedException();
        }

        public Pair? SearchExplode()
        {
            return null;
        }

        public Value? SearchLeftValue(IElement explodePair, HashSet<IElement> visited)
        {
            return this;
        }

        public Value? SearchRightValue(IElement explodePair, HashSet<IElement> visited)
        {
            return this;
        }

        public void SetLevel(int level)
        {
            Level = level;
        }

        public override string ToString()
        {
            return Number.ToString();
        }
    }

    public Pair Parse(ReadOnlySpan<char> input)
    {
        var stack = new Stack<IElement>();
        IElement current = new Pair();
        var level = 0;
        for(var index = 1; index < input.Length - 1; index++)
        {
            var c = input[index];
            if (c == '[')
            {
                level++;
                stack.Push(current);
                current = current.Add(new Pair());
            }
            else if (c == ']')
            {
                level--;
                current = stack.Pop();
            }
            else if (c == ',') continue;
            else // read numver while ',' or ']'
            {
                var sb = new StringBuilder();
                while (input[index] != ',' && input[index] != ']')
                {
                    sb.Append(input[index++]);
                }
                if (input[index] == ']') index--;
                current.Add(new Value() { Number = long.Parse(sb.ToString()) });
            }
        }

        return current as Pair;
    }

    public Pair SumsMany(params Pair[] elements)
    {
        if (elements.Length < 2)
            throw new ArgumentException("too few elements in parameter", nameof(elements));
        var result = elements[0];
        for(var i = 1; i < elements.Length; i++)
            result = result.SumAndReduce(elements[i]);

        return result;
    }

    public long Solve(string input)
    {
        var pairs = input.Split(Environment.NewLine).Select(x => Parse(x)).ToArray();
        var result = SumsMany(pairs);
        return result.Magnitude();
    }
}