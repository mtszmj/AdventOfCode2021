namespace AdventOfCode2021.Tests;
internal class Day10Task1Tests
{
    [TestCase("[({(<(())[]>[[{[]{<()<>>", null)]
    [TestCase("[(()[<>])]({[<{<<[]>>(", null)]
    [TestCase("{([(<{}[<>[]}>{[]{[(<()>", '}')]
    [TestCase("(((({<>}<{<{<>}{[]{[]{}", null)]
    [TestCase("[[<[([]))<([[{}[[()]]]", ')')]
    [TestCase("[{[{({}]{}}([{[{{{}}([]", ']')]
    [TestCase("{<[[]]>}<{[{[{[]{()[[[]", null)]
    [TestCase("[<(<(<(<{}))><([]([]()", ')')]
    [TestCase("<{([([[(<>()){}]>(<<{{", '>')]
    [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", null)]
    public void find_low_points(string input, char? expected)
    {
        var solver = new Day10Task1();
        var result = solver.FindIllegal(input);
        result.Should().Be(expected);        
    }

    [TestCase("[({(<(())[]>[[{[]{<()<>>", 0)]
    [TestCase("[(()[<>])]({[<{<<[]>>(", 0)]
    [TestCase("{([(<{}[<>[]}>{[]{[(<()>", 1197)]
    [TestCase("(((({<>}<{<{<>}{[]{[]{}", 0)]
    [TestCase("[[<[([]))<([[{}[[()]]]", 3)]
    [TestCase("[{[{({}]{}}([{[{{{}}([]", 57)]
    [TestCase("{<[[]]>}<{[{[{[]{()[[[]", 0)]
    [TestCase("[<(<(<(<{}))><([]([]()", 3)]
    [TestCase("<{([([[(<>()){}]>(<<{{", 25137)]
    [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", 0)]
    public void  gets_value(string input, int expected)
    {
        var solver = new Day10Task1();
        var result = solver.ValueIllegal(input);
        result.Should().Be(expected);
    }

    [Test]
    public void gets_value()
    {
        var input = @"[({(<(())[]>[[{[]{<()<>>
[(()[<>])]({[<{<<[]>>(
{([(<{}[<>[]}>{[]{[(<()>
(((({<>}<{<{<>}{[]{[]{}
[[<[([]))<([[{}[[()]]]
[{[{({}]{}}([{[{{{}}([]
{<[[]]>}<{[{[{[]{()[[[]
[<(<(<(<{}))><([]([]()
<{([([[(<>()){}]>(<<{{
<{([{{}}[<[[[<>{}]]]>[]]".Split(Environment.NewLine);
        var solver = new Day10Task1();
        var result = solver.SumIllegal(input);
        result.Should().Be(26397);
    }

    [Test]
    public void solves_task1()
    {
        var input = Helper.ReadLinesAsString(10);
        var solver = new Day10Task1();
        var result = solver.SumIllegal(input);
        result.Should().Be(323691);
    }
}