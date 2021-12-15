namespace AdventOfCode2021;
public class Day15Task2 : Day15Task1
{
    protected override Field[,] Parse(string input)
    {
        var baseTile = base.Parse(input);
        var rows = baseTile.GetLength(0);
        var cols = baseTile.GetLength(1);
        
        var fields = new Field[rows * 5, cols * 5];
        for (var i = 0; i < 5 * rows; i++)
            for (var j = 0; j < 5 * cols; j++)
            {
                
                if (i < rows && j < cols)
                    fields[i, j] = baseTile[i, j];
                else
                {
                    var add = (int)Math.Floor((float)i / rows) + (int)Math.Floor((float)j / cols);
                    fields[i, j] = new Field(
                        baseTile[i % rows, j % cols].Value + add > 9 
                        ? baseTile[i % rows, j % cols].Value + add - 9 
                        : baseTile[i % rows, j % cols].Value + add, 
                        long.MaxValue);
                }
            }

        return fields;
    }
}