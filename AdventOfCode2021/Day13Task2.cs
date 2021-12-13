namespace AdventOfCode2021;
public class Day13Task2 : Day13Task1
{
    public override int Solve(string input)
    {
        var paper = Parse(input.Split(Environment.NewLine));
        paper.FoldAll();
        Console.WriteLine(paper.Print());
        return paper.CountDots();
    }
}