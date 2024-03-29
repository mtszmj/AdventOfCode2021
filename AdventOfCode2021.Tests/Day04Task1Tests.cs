﻿namespace AdventOfCode2021.Tests;
internal class Day04Task1Tests
{
    [Test]
    public void returns_parsed_bingo()
    {
        var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19

 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7";

        var result = new Day04Task1().ParseInput(input);

        result.Should().NotBeNull();
        result.Numbers.Should().BeEquivalentTo(new[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 });
        result.Boards.Length.Should().Be(3);
        result.Boards[0].ToString().Should()
            .Be(
@"22 13 17 11  0
 8  2 23  4 24
21  9 14 16  7
 6 10  3 18  5
 1 12 20 15 19");
        result.Boards[1].ToString().Should()
            .Be(
@" 3 15  0  2 22
 9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6");
        result.Boards[2].ToString().Should()
            .Be(
@"14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
 2  0 12  3  7");
    }

    [Test]
    public void split_line()
    {
        var line = "22 13 17 11  0";
        var split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
        var ints = split.Select(x => int.Parse(x)).ToList();

        ints.Should().BeEquivalentTo(new[] { 22, 13, 17, 11, 0 });
    }

    [Test]
    public void bingo_returns_4512()
    {
        var input = @"7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1

22 13 17 11  0
8  2 23  4 24
21  9 14 16  7
6 10  3 18  5
1 12 20 15 19

3 15  0  2 22
9 18 13 17  5
19  8  7 25 23
20 11 10 24  4
14 21 16 12  6

14 21 17 24  4
10 16 15  9 19
18  8 23 26 20
22 11 13  6  5
2  0 12  3  7";

        var bingo = new Day04Task1().ParseInput(input);
        var result = bingo.Play();
        result.Should().Be(4512);
    }

    [Test]
    public void returns_65325()
    {
        var input = Helper.ReadFile(4);

        var result = new Day04Task1().ParseInput(input).Play();

        result.Should().Be(65325);
    }
}