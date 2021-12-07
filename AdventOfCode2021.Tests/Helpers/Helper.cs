using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021.Tests.Helpers
{
    public static class Helper
    {
        public static string ReadFile(int day)
        {
            return File.ReadAllText($"Files\\Day{day:D2}.txt");
        }

        public static string[] ReadLinesAsString(int day)
        {
            return File.ReadAllLines($"Files\\Day{day:D2}.txt").ToArray();
        }

        public static int[] ReadLinesAsInt(int day)
        {
            return File.ReadAllLines($"Files\\Day{day:D2}.txt").Select(int.Parse).ToArray();
        }

        public static int[] ReadFileAsIntSplitBy(int day, string splitter, StringSplitOptions options = StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
        {
            return File.ReadAllText($"Files\\Day{day:D2}.txt").Split(splitter, options).Select(int.Parse).ToArray();
        }

    }
}
