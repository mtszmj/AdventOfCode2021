namespace AdventOfCode2021.Tests;
internal class Day16Task2Tests
{
    public string Example = @"";
    Day16Task2 Solver() => new();
    int Day = 16;

    [TestCase("C200B40A82", 3)]
    [TestCase("04005AC33890", 54)]
    [TestCase("880086C3E88112", 7)]
    [TestCase("CE00C43D881120", 9)]
    [TestCase("D8005AC2A8F0", 1)]
    [TestCase("F600BC2D8F", 0)]
    [TestCase("9C005AC2F8F0", 0)]
    [TestCase("9C0141080250320F1802104A08", 1)]
    public void solves_example(string input, long expected)
    {
        var result = Solver().Calculate(input);
        result.Should().Be(expected);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Calculate(Helper.ReadFile(Day));
        result.Should().Be(200476472872L);
    }
}