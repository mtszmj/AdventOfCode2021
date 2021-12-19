namespace AdventOfCode2021.Tests;
internal class Day18Task1Tests
{
    public string Example = @"[[[0,[5,8]],[[1,7],[9,6]]],[[4,[1,2]],[[1,4],2]]]
[[[5,[2,8]],4],[5,[[9,9],0]]]
[6,[[[6,2],[5,6]],[[7,6],[4,7]]]]
[[[6,[0,7]],[0,9]],[4,[9,[9,0]]]]
[[[7,[6,4]],[3,[1,3]]],[[[5,5],1],9]]
[[6,[[7,3],[3,2]]],[[[3,8],[5,7]],4]]
[[[[5,4],[7,7]],8],[[8,3],8]]
[[9,3],[[9,9],[6,[4,9]]]]
[[2,[[7,7],7]],[[5,8],[[9,3],[0,2]]]]
[[[[5,2],5],[8,[3,7]]],[[5,[7,5]],[4,4]]]";
    Day18Task1 Solver() => new Day18Task1();
    int Day = 18;

    [TestCase("[1,2]", 3, 1)]
    [TestCase("[[1,2],3]", 5, 2)]
    [TestCase("[9,[8,7]]", 5, 2)]
    [TestCase("[[1,9],[8,5]]", 7, 2)]
    [TestCase("[[[[1,2],[3,4]],[[5,6],[7,8]]],9]", 17, 4)]
    [TestCase("[[[9,[3,8]],[[0,9],6]],[[[3,7],[4,9]],3]]", 21, 4)]
    [TestCase("[[[[1,3],[5,3]],[[1,3],[8,7]]],[[[4,9],[6,9]],[[8,2],[7,3]]]]", 31, 4)]
    public void parses(string line, int count, int maxLevel)
    {
        var main = Solver().Parse(line);
        main.Level.Should().Be(0);
        var cnt = main.Count();

        cnt.count.Should().Be(count);
        cnt.maxLevel.Should().Be(maxLevel);
    }

    [Test]
    public void adds_two_pairs()
    {
        var solver = Solver();
        var p1 = solver.Parse("[1,2]");
        var p2 = solver.Parse("[[3,4],5]");
        var sum = p1.Plus(p2);
        sum.ToString().Should().Be("[[1,2],[[3,4],5]]");

        var cnt = sum.Count();
        cnt.count.Should().Be(9);
        cnt.maxLevel.Should().Be(3);
    }

    [TestCase("[1,2]", null)]
    [TestCase("[[[[[9,8],1],2],3],4]", "[9,8]")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[3,2]")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "[3,2]")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[7,3]")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[3,2]")]
    public void finds_pair_to_explode(string input, string expected)
    {
        var solver = Solver();
        var main = solver.Parse(input);
        var pairToExplode = main.SearchExplode();
        if (expected is null)
            pairToExplode.Should().BeNull();
        else
            pairToExplode.ToString().Should().Be(expected);
    }


    [TestCase("[[[[[9,8],1],2],3],4]", null)]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "4")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "4")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "1")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "4")]
    public void finds_left_value(string input, string expected)
    {
        var solver = Solver();
        var main = solver.Parse(input);
        var pairToExplode = main.SearchExplode();
        var left = pairToExplode.SearchLeftValue(pairToExplode, new());
        if (expected is null)
            left.Should().BeNull();
        else
            left.ToString().Should().Be(expected);
    }

    [TestCase("[[[[[9,8],1],2],3],4]", "1")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", null)]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "1")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "6")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", null)]
    public void finds_right_value(string input, string expected)
    {
        var solver = Solver();
        var main = solver.Parse(input);
        var pairToExplode = main.SearchExplode();
        var left = pairToExplode.SearchRightValue(pairToExplode, new());
        if (expected is null)
            left.Should().BeNull();
        else
            left.ToString().Should().Be(expected);
    }


    [TestCase("[[[[[9,8],1],2],3],4]", "[[[[0,9],2],3],4]")]
    [TestCase("[7,[6,[5,[4,[3,2]]]]]", "[7,[6,[5,[7,0]]]]")]
    [TestCase("[[6,[5,[4,[3,2]]]],1]", "[[6,[5,[7,0]]],3]")]
    [TestCase("[[3,[2,[1,[7,3]]]],[6,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]")]
    [TestCase("[[3,[2,[8,0]]],[9,[5,[4,[3,2]]]]]", "[[3,[2,[8,0]]],[9,[5,[7,0]]]]")]
    public void explodes(string input, string expected)
    {
        var solver = Solver();
        var main = solver.Parse(input);
        var exploded = main.Explode();
        exploded.Should().BeTrue();
        main.ToString().Should().Be(expected);
    }

    [TestCase("[[[[0,7],4],[15,[0,13]]],[1,1]]", "[[[[0,7],4],[[7,8],[0,13]]],[1,1]]")]
    [TestCase("[[[[0,7],4],[[7,8],[0,13]]],[1,1]]", "[[[[0,7],4],[[7,8],[0,[6,7]]]],[1,1]]")]
    public void splits(string input, string expected)
    {
        var solver = Solver();
        var main = solver.Parse(input);
        var split = main.Split();
        split.Should().BeTrue();
        main.ToString().Should().Be(expected);
    }

    [TestCase(@"[[[[4,3],4],4],[7,[[8,4],9]]]", "[1,1]", "[[[[0,7],4],[[7,8],[6,0]]],[8,1]]")]
    [TestCase(@"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]", "[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]", "[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]")]
    [TestCase(@"[[[[4,0],[5,4]],[[7,7],[6,0]]],[[8,[7,7]],[[7,9],[5,0]]]]", "[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]", "[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]")]
    [TestCase(@"[[[[6,7],[6,7]],[[7,7],[0,7]]],[[[8,7],[7,7]],[[8,8],[8,0]]]]", "[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]", "[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]")]
    [TestCase(@"[[[[7,0],[7,7]],[[7,7],[7,8]]],[[[7,7],[8,8]],[[7,7],[8,7]]]]", "[7,[5,[[3,8],[1,4]]]]", "[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]")]
    [TestCase(@"[[[[7,7],[7,8]],[[9,5],[8,7]]],[[[6,8],[0,8]],[[9,9],[9,0]]]]", "[[2,[2,2]],[8,[8,1]]]", "[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]")]
    [TestCase(@"[[[[6,6],[6,6]],[[6,0],[6,7]]],[[[7,7],[8,9]],[8,[8,1]]]]", "[2,9]", "[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]")]
    [TestCase(@"[[[[6,6],[7,7]],[[0,7],[7,7]]],[[[5,5],[5,6]],9]]", "[1,[[[9,3],9],[[9,0],[0,7]]]]", "[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]")]
    [TestCase(@"[[[[7,8],[6,7]],[[6,8],[0,8]]],[[[7,7],[5,0]],[[5,5],[5,6]]]]", "[[[5,[7,4]],7],1]", "[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]")]
    [TestCase(@"[[[[7,7],[7,7]],[[8,7],[8,7]]],[[[7,0],[7,7]],9]]", "[[[[4,2],2],6],[8,7]]", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
    public void adds_two(string one, string two, string expected)
    {
        var solver = Solver();
        var left = solver.Parse(one);
        var right = solver.Parse(two);

        var result = left.SumAndReduce(right);
        result.ToString().Should().Be(expected);
    }


    [TestCase(@"[1,1]
[2,2]
[3,3]
[4,4]", "[[[[1,1],[2,2]],[3,3]],[4,4]]")]
    [TestCase(@"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]", "[[[[3,0],[5,3]],[4,4]],[5,5]]")]
    [TestCase(@"[1,1]
[2,2]
[3,3]
[4,4]
[5,5]
[6,6]", "[[[[5,0],[7,4]],[5,5]],[6,6]]")]
    [TestCase(@"[[[0,[4,5]],[0,0]],[[[4,5],[2,6]],[9,5]]]
[7,[[[3,7],[4,3]],[[6,3],[8,8]]]]
[[2,[[0,8],[3,4]]],[[[6,7],1],[7,[1,6]]]]
[[[[2,4],7],[6,[0,5]]],[[[6,8],[2,8]],[[2,1],[4,5]]]]
[7,[5,[[3,8],[1,4]]]]
[[2,[2,2]],[8,[8,1]]]
[2,9]
[1,[[[9,3],9],[[9,0],[0,7]]]]
[[[5,[7,4]],7],1]
[[[[4,2],2],6],[8,7]]", "[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]")]
    public void adds_many(string lines, string expected)
    {
        var solver = Solver();
        var input = lines.Split(Environment.NewLine).Select(x => solver.Parse(x));
        var result = solver.SumsMany(input.ToArray());
        result.ToString().Should().Be(expected);
    }


    [TestCase("[9,1]", 29)]
    [TestCase("[[9,1],[1,9]]", 129)]
    [TestCase("[[1,2],[[3,4],5]]", 143)]
    [TestCase("[[[[0,7],4],[[7,8],[6,0]]],[8,1]]", 1384)]
    [TestCase("[[[[1,1],[2,2]],[3,3]],[4,4]]", 445)]
    [TestCase("[[[[3,0],[5,3]],[4,4]],[5,5]]", 791)]
    [TestCase("[[[[5,0],[7,4]],[5,5]],[6,6]]", 1137)]
    [TestCase("[[[[8,7],[7,7]],[[8,6],[7,7]]],[[[0,7],[6,6]],[8,7]]]", 3488)]
    [TestCase("[[[[6,6],[7,6]],[[7,7],[7,0]]],[[[7,7],[7,7]],[[7,8],[9,9]]]]", 4140)]
    public void counts_magnitude(string input, long expected)
    {
        var solver = Solver();
        var root = solver.Parse(input);
        root.Magnitude().Should().Be(expected);
    }

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(4140);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(4173);
    }
}