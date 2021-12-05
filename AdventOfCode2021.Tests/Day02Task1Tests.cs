namespace AdventOfCode2021.Tests;
internal class Day02Task1Tests
{
    [Test]
    public void moves_to_15_horizontally_and_10_depth_giving_150()
    {
        var input = @"forward 5
down 5
forward 8
up 3
down 8
forward 2";

        var inputLines = input.Split(Environment.NewLine, int.MaxValue, StringSplitOptions.RemoveEmptyEntries);

        var result = new Day02Task1().MoveSubmarine(inputLines);

        result.Horizontal.Should().Be(15);
        result.Depth.Should().Be(10);
        result.Multiplication.Should().Be(150);
    }

    [Test]
    public void returns_1714950_for_task1()
    {
        var input = Helper.ReadLinesAsString(2);

        var result = new Day02Task1().MoveSubmarine(input);

        result.Multiplication.Should().Be(1714950);
    }
}