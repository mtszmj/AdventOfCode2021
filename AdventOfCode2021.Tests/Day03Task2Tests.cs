namespace AdventOfCode2021.Tests
{
    internal class Day03Task2Tests
    {
        [Test]
        public void returns_230()
        {
            var input = @"00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";

            var inputLines = input.Split(Environment.NewLine);
            var result = new Day03Task2().ReadOxygenAndCO2(inputLines);

            result.Should().Be(230);
        }

        [Test]
        public void returns_4996233()
        {
            var input = Helper.ReadLinesAsString(3);

            var result = new Day03Task2().ReadOxygenAndCO2(input);

            result.Should().Be(4996233);
        }
    }
}
