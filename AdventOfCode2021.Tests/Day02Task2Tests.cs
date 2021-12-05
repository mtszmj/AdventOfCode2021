namespace AdventOfCode2021.Tests
{
    internal class Day02Task2Tests
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

            var result = new Day02Task2().MoveSubmarine(inputLines);

            result.Horizontal.Should().Be(15);
            result.Depth.Should().Be(60);
            result.Multiplication.Should().Be(900);
        }

        [Test]
        public void returns_1281977850_for_task2()
        {
            var input = Helper.ReadLinesAsString(2);

            var result = new Day02Task2().MoveSubmarine(input);

            result.Multiplication.Should().Be(1281977850);
        }
    }
}
