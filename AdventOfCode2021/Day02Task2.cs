using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    public class Day02Task2
    {
        public Day02Task2()
        {
            moveFuncByCommand = new Dictionary<string, Func<int, PositionWithAim, PositionWithAim>>
            {
                ["forward"] = (commandValue, position) => position with { 
                    Horizontal = position.Horizontal + commandValue, 
                    Depth = position.Depth + (position.Aim * commandValue) 
                },
                ["down"] = (commandValue, position) => position with { Aim = position.Aim + commandValue },
                ["up"] = (commandValue, position) => position with { Aim = position.Aim - commandValue },
            };
        }

        protected readonly Dictionary<string, Func<int, PositionWithAim, PositionWithAim>> moveFuncByCommand;

        public Position MoveSubmarine(string[] commands)
        {
            var result = new PositionWithAim(0, 0, 0);
            foreach (var cmd in commands) 
            {
                var nameAndValue = cmd.Split(" ", StringSplitOptions.TrimEntries);
                result = moveFuncByCommand[nameAndValue[0]].Invoke(int.Parse(nameAndValue[1]), result);
            }
            return result;
        }
    }

    public record PositionWithAim(int Horizontal, int Depth, int Aim) : Position(Horizontal, Depth)
    {
    }
}
