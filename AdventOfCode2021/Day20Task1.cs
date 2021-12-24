using System.Collections;

namespace AdventOfCode2021;
public class Day20Task1
{
    public record struct Point(int X, int Y);


    public int Solve(string input, int iterations = 2)
    {
        var (algorithm, image, boundaries) = Parse(input);
        //Print(image, boundaries);
        
        var infinitePixel = InitInfinitePixel();

        for(var i = 0; i < iterations; i++)
        {
            (image, boundaries) = Enhance(algorithm, image, boundaries, infinitePixel);
            infinitePixel = EnhanceInfinitePixel(algorithm, infinitePixel);
            //Print(image, boundaries);
        }

        return image.Values.Count(x => x == true);
    }

    private static Dictionary<Point, bool> InitInfinitePixel()
    {
        return new Dictionary<Point, bool>()
        {
            [new Point(0, 0)] = false,
            [new Point(0, 1)] = false,
            [new Point(0, 2)] = false,
            [new Point(1, 0)] = false,
            [new Point(1, 1)] = false,
            [new Point(2, 2)] = false,
            [new Point(2, 0)] = false,
            [new Point(2, 1)] = false,
            [new Point(2, 2)] = false,
        };
    }

    public (Dictionary<Point, bool> Image, (int x1, int x2, int y1, int y2) Boundaries) 
        Enhance(
        BitArray Algorithm, 
        Dictionary<Point, bool> Image, 
        (int x1, int x2, int y1, int y2) Boundaries, 
        Dictionary<Point, bool> InfiniteImagePart)
    {
        var newImage = new Dictionary<Point, bool>();
        for(var row = Boundaries.y1; row <= Boundaries.y2; row++)
            for(var col = Boundaries.x1; col <= Boundaries.x2; col++)
            {
                newImage[new Point(row, col)] = EnhancePixel(Algorithm, Image, row, col, InfiniteImagePart[new Point(1,1)], Boundaries);
            }

        return (newImage, (Boundaries.x1 - 1, Boundaries.x2 + 1, Boundaries.y1 - 1, Boundaries.y2 + 1));
    }

    public Dictionary<Point, bool> EnhanceInfinitePixel(BitArray Algorithm, Dictionary<Point, bool> InfiniteImagePart)
    {
        var value = EnhancePixel(Algorithm, InfiniteImagePart, 1, 1, InfiniteImagePart[new Point(1,1)], (0, 2, 0 , 2));
        foreach(var pixel in InfiniteImagePart.Keys)
        {
            InfiniteImagePart[pixel] = value;
        }
        return InfiniteImagePart;
    }

    private bool EnhancePixel(BitArray algorithm, Dictionary<Point, bool> image, int row, int col, bool infinitePixel, (int x1, int x2, int y1, int y2) Boundaries)
    {
        var index = (GetPixelValue(row - 1, col - 1) << 8)
            | (GetPixelValue(row - 1, col) << 7)
            | (GetPixelValue(row - 1, col + 1) << 6)
            | (GetPixelValue(row, col - 1) << 5)
            | (GetPixelValue(row, col) << 4)
            | (GetPixelValue(row, col + 1) << 3)
            | (GetPixelValue(row + 1, col - 1) << 2)
            | (GetPixelValue(row + 1, col) << 1)
            | (GetPixelValue(row + 1, col + 1) << 0)
            ;

        return algorithm[index];

        int GetPixelValue(int row, int col) 
        {
            if (row <= Boundaries.y1 || row >= Boundaries.y2 || col <= Boundaries.x1 || col >= Boundaries.x2)
                return infinitePixel ? 1 : 0;
            return image.GetValueOrDefault(new Point(row, col), false) ? 1 : 0;
        }
    }

    public (BitArray Algorithm, Dictionary<Point, bool> Image, (int x1, int x2, int y1, int y2) Boundaries) Parse(string input)
    {
        var data = input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToArray();
        var algorithm = new BitArray(data[0].Select(x => x == '#').ToArray());

        var image = new Dictionary<Point, bool>();
        for (var row = 0; row < data.Length - 1; row++)
            for (var col = 0; col < data[1].Length; col++)
                if (data[row + 1][col] == '#')
                    image[new Point(row, col)] = true;
                else
                    image[new Point(row, col)] = false;

        var boundaries = (x1: -5, x2: data[1].Length + 4, y1: -5, y2: data.Length + 4);
        return (algorithm, image, boundaries);
    }

    public void Print(Dictionary<Point, bool> Image, (int x1, int x2, int y1, int y2) Boundaries)
    {
        var sb = new StringBuilder();
        for (var row = Boundaries.y1; row <= Boundaries.y2; row++)
        { 
            for (var col = Boundaries.x1; col <= Boundaries.x2; col++)
                sb.Append(Image.GetValueOrDefault(new Point(row, col), false) ? '◼' : '.');
            sb.AppendLine();
        }
        Console.WriteLine(sb.ToString());
    }
}