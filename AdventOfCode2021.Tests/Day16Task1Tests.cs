namespace AdventOfCode2021.Tests;
internal class Day16Task1Tests
{
    public string Example = @"";
    Day16Task1 Solver() => new();
    int Day = 16;

    [TestCase("D2FE28", "110100101111111000101000")]
    [TestCase("38006F45291200", "00111000000000000110111101000101001010010001001000000000")]
    [TestCase("EE00D40C823060", "11101110000000001101010000001100100000100011000001100000")]
    public void converts_to_binary(string hex, string bin)
    {
        Solver().ToBinary(hex).Should().Be(bin);
    }

    [TestCase("110100101111111000101000", 6)]
    [TestCase("00111000000000000110111101000101001010010001001000000000", 9)]
    [TestCase("11101110000000001101010000001100100000100011000001100000", 14)]
    public void get_vesions_sum(string bin, int versions)
    {
        Solver().SumVersions(bin, out var end).Should().Be(versions);
    }


    [TestCase("8A004A801A8002F478", 16)]
    [TestCase("620080001611562C8802118E34", 12)]
    [TestCase("C0015000016115A2E0802F182340", 23)]
    [TestCase("A0016C880162017C3686B18A3D4780", 31)]
    public void solves_example(string input, int expected)
    {
        var result = Solver().Solve(input);
        result.Should().Be(expected);
    }

    [Test]
    public void solves_task()
    {
        var result = Solver().Solve(Helper.ReadFile(Day));
        result.Should().Be(904);
    }
}