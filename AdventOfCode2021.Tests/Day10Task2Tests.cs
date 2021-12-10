namespace AdventOfCode2021.Tests;
internal class Day10Task2Tests
{
    [TestCase("[({(<(())[]>[[{[]{<()<>>", 288957)]
    [TestCase("[(()[<>])]({[<{<<[]>>(", 5566)]
    [TestCase("(((({<>}<{<{<>}{[]{[]{}", 1480781)]
    [TestCase("{<[[]]>}<{[{[{[]{()[[[]", 995444)]
    [TestCase("<{([{{}}[<[[[<>{}]]]>[]]", 294)]
    public void find_result(string input, long expected)
    {
        var solver = new Day10Task2();
        var result = solver.FillLine(input);
        result.Should().Be(expected);        
    }

    [Test]
    public void find_middle_result()
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
        var solver = new Day10Task2();
        var result = solver.FindMiddleFillLine(input);
        result.Should().Be(288957);
    }

    [Test]
    public void solves_task_2()
    {
        var input = Helper.ReadLinesAsString(10);
        var solver = new Day10Task2();
        var result = solver.FindMiddleFillLine(input);
        result.Should().Be(2858785164L);
    }
}