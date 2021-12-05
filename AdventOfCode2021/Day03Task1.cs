namespace AdventOfCode2021
{
    public class Day03Task1
    {
        public object ReadPowerConsumption(string[] inputLines)
        {
            var lineSize = inputLines[0].Length;
            var mostCommonBit = new int[lineSize];
            foreach(var line in inputLines)
            {
                for(var i = 0; i < lineSize; i++)
                {
                    _ = line[i] == '1' ? ++mostCommonBit[i] : --mostCommonBit[i];
                }
            }

            StringBuilder gammaSb = new StringBuilder();
            StringBuilder epsilonSb = new StringBuilder();
            for(var i = 0; i < lineSize; i++)
            {
                gammaSb.Append(mostCommonBit[i] > 0 ? '1' : '0');
                epsilonSb.Append(mostCommonBit[i] < 0 ? '1' : '0');
            }

            var gamma = Convert.ToInt32(gammaSb.ToString(), 2);
            var epsilon = Convert.ToInt32(epsilonSb.ToString(), 2);

            return gamma * epsilon;
        }
    }
}
