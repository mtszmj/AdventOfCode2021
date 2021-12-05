namespace AdventOfCode2021.Tests;
internal class Day05Task1Tests
{
    [TestCase("0,9 -> 5,9", 0, 9, 5, 9)]
    [TestCase("8,0 -> 0,8", 8, 0, 0, 8)]
    [TestCase("9,4 -> 3,4", 9, 4, 3, 4)]
    [TestCase("2,2 -> 2,1", 2, 2, 2, 1)]
    [TestCase("7,0 -> 7,4", 7, 0, 7, 4)]
    [TestCase("6,4 -> 2,0", 6, 4, 2, 0)]
    [TestCase("0,9 -> 2,9", 0, 9, 2, 9)]
    [TestCase("3,4 -> 1,4", 3, 4, 1, 4)]
    [TestCase("0,0 -> 8,8", 0, 0, 8, 8)]
    [TestCase("5,5 -> 8,2", 5, 5, 8, 2)]
    public void split_line_returns_coords(string input, int x1Result, int y1Result, int x2Result, int y2Result)
    {
        var (x1, y1, x2, y2) = new Day05Task1().SplitValues(input);

        x1.Should().Be(x1Result);
        y1.Should().Be(y1Result);
        x2.Should().Be(x2Result);
        y2.Should().Be(y2Result);
    }

    [Test]
    public void returns_diagram()
    {
        var input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        var result = new Day05Task1().ParseInput(input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

        result.Print().Should().Be(
            @".......1..
..1....1..
..1....1..
.......1..
.112111211
..........
..........
..........
..........
222111....");
    }

    [Test]
    public void returns_5_overlaps()
    {
        var input = @"0,9 -> 5,9
8,0 -> 0,8
9,4 -> 3,4
2,2 -> 2,1
7,0 -> 7,4
6,4 -> 2,0
0,9 -> 2,9
3,4 -> 1,4
0,0 -> 8,8
5,5 -> 8,2";

        var result = new Day05Task1().ParseInput(input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

        result.LinesOverlap(2).Should().Be(5);
    }

    [Test]
    public void returns_7269()
    {
        var input = Helper.ReadLinesAsString(5);
        var result = new Day05Task1().ParseInput(input).LinesOverlap(2);

        result.Should().Be(7269);
    }
}