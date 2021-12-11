namespace AdventOfCode2021.Tests;
internal class Day11Task2Tests
{
    public string Example = @"5483143223
2745854711
5264556173
6141336146
6357385478
4167524645
2176841721
6882881134
4846848554
5283751526";

    [Test]
    public void find_all_flash_at_once_for_example()
    {
        var solver = new Day11Task2();
        var result = solver.FindIterationWhenAllFlash(Example);
        result.Should().Be(195);
    }

    [Test]
    public void find_all_flash_at_once()
    {
        var solver = new Day11Task2();
        var result = solver.FindIterationWhenAllFlash(Helper.ReadFile(11));
        result.Should().Be(505);
    }
}