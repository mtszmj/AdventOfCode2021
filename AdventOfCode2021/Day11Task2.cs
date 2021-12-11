namespace AdventOfCode2021;
public class Day11Task2 : Day11Task1
{
    // non-optimal solution using string representation of table (parsing each iteration), but can solve without modifying task 1
    public int FindIterationWhenAllFlash(string input)
    {
        var previousFlashes = 0L;
        var newFlashes = 0L;
        var iteration = 0;
        while(newFlashes - previousFlashes < 100)
        {
            (input, newFlashes) = Simulate(input, 1);
            iteration++;
        }

        return iteration;
    }
}