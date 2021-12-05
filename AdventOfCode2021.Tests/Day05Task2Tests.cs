namespace AdventOfCode2021.Tests;
internal class Day05Task2Tests
{
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

        var result = new Day05Task2().ParseInput(input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

        result.Print().Should().Be(
            @"1.1....11.
.111...2..
..2.1.111.
...1.2.2..
.112313211
...1.2....
..1...1...
.1.....1..
1.......1.
222111....");
    }

    [Test]
    public void returns_12_overlaps()
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

        var result = new Day05Task2()
            .ParseInput(input.Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries));

        result.LinesOverlap(2).Should().Be(12);
    }

    [Test]
    public void returns_21140()
    {
        var input = Helper.ReadLinesAsString(5);
        var result = new Day05Task2().ParseInput(input).LinesOverlap(2);

        result.Should().Be(21140);
    }
}