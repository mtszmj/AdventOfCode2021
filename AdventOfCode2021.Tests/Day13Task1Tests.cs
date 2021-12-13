namespace AdventOfCode2021.Tests;
internal class Day13Task1Tests
{
    public string Example = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
    Day13Task1 Solver() => new();
    int Day = 13;

    [Test]
    public void parses_example()
    {
        var paper = Solver().Parse(Example.Split(Environment.NewLine));

        paper.Points.Should().Contain((6, 10));
        paper.Points.Should().Contain((0, 14));
        paper.Points.Should().Contain((9, 10));
        paper.Points.Should().Contain((0, 3));
        paper.Points.Should().Contain((10, 4));
        paper.Points.Should().Contain((4, 11));
        paper.Points.Should().Contain((6, 0));
        paper.Points.Should().Contain((6, 12));
        paper.Points.Should().Contain((4, 1));
        paper.Points.Should().Contain((0, 13));
        paper.Points.Should().Contain((10, 12));
        paper.Points.Should().Contain((3, 4));
        paper.Points.Should().Contain((3, 0));
        paper.Points.Should().Contain((8, 4));
        paper.Points.Should().Contain((1, 10));
        paper.Points.Should().Contain((2, 14));
        paper.Points.Should().Contain((8, 10));
        paper.Points.Should().Contain((9, 0));
        
        paper.Folds.ToList()[0].Should().Be(('y', 7));
        paper.Folds.ToList()[1].Should().Be(('x', 5));

        paper.xRange.MinX.Should().Be(0);
        paper.xRange.MaxX.Should().Be(10);
        paper.yRange.MinY.Should().Be(0);
        paper.yRange.MaxY.Should().Be(14);

        Console.WriteLine(paper.Print());
    }

    [Test]
    public void folds_once()
    {
        var paper = Solver().Parse(Example.Split(Environment.NewLine));
        paper.Fold();

        paper.Print().Should().Be(@"#.##..#..#.
#...#......
......#...#
#...#......
.#.#..#.###
...........
...........");
    }

    [Test]
    public void folds_twice()
    {
        var paper = Solver().Parse(Example.Split(Environment.NewLine));
        paper.Fold();
        paper.Fold();

        paper.Print().Should().Be(@"#####
#...#
#...#
#...#
#####
.....
.....");
    }

    [Test]
    public void solves_example()
    {
        var result = Solver().Solve(Example);
        result.Should().Be(17);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(706);
    }
}