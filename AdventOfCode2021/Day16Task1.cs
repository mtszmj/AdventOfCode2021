namespace AdventOfCode2021;
public class Day16Task1
{
    public long Solve(string input)
    {
        var bin = ToBinary(input);
        return SumVersions(bin, out var end, new());
    }

    public string ToBinary(string hex)
    {
        var x = Convert.FromHexString(hex);
        return string.Join("", x.Select(v => Convert.ToString(v, 2).PadLeft(8, '0')));
    }

    public long SumVersions(ReadOnlySpan<char> span, out int end, Queue<string> operations)
    {
        end = 0;
        var version = span[..3].ToDecimalValue();
        var packet = span[3..6].ToDecimalValue();

        if(packet == 4)
        {
            var index = 0;
            var sb = new StringBuilder();
            var plusOne = true;
            while (plusOne)
            {
                sb.Append(span[(6 + index * 5 + 1)..(6 + (index + 1) * 5)]);
                if (span[6 + index * 5] == '0')
                    plusOne = false;
                index++;
            }
            end = 6 + index * 5;
            var value = sb.ToString().ToDecimalValue();
            operations.Enqueue(value.ToString());

            return version;
        }

        operations.Enqueue(packet switch
        {
            0 => "+",
            1 => "*",
            2 => "min",
            3 => "max",
            5 => ">",
            6 => "<",
            7 => "==",
            _ => "error"
        });

        var lengthType = span[6] == '1';
        if (!lengthType)
        {
            var length = span[7..(7 + 15)].ToDecimalValue();
            var subpackets = span[(7 + 15)..(7 + 15 + (int)length)];

            operations.Enqueue("(");
            var from = 0;
            while (from < subpackets.Length)
            {
                version += SumVersions(subpackets[from..], out end, operations);
                from += end;
            }
            end = from + 22;
            operations.Enqueue(")");
        }

        else
        {
            var numOfSubpackets = span[7..(7 + 11)].ToDecimalValue();
            var subpackets = span[(7+11)..];
            var from = 0;
            operations.Enqueue("(");
            for (var i = 0; i < numOfSubpackets; i++)
            {
                version += SumVersions(subpackets[from..], out end, operations);
                from += end;
            }
            end = from + 18;
            operations.Enqueue(")");
        }

        return version;
    }

}

public static class Ext
{
    public static long ToDecimalValue(this string bin)
    {
        return Convert.ToInt64(bin, 2);
    }

    public static long ToDecimalValue(this ReadOnlySpan<char> span)
    {
        return Convert.ToInt64(span.ToString(), 2);
    }
}