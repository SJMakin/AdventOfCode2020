using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayEight
    {
        private static List<(int index, string operation, int argument)> Input =
            File.ReadAllLines(@"Day\8\input.txt")
            .Select((x, i) => (index: i, parts: x.Split(' ')))
            .Select(x => (x.index, x.parts[0], Convert.ToInt32(x.parts[1])))
            .ToList();

        public static void ChallengeOne()
        {
            var p = Processor(Input);
            Console.WriteLine(p.result.ToString());
        }

        public static void ChallengeTwo()
        {
            var p = -1;
            for (var i = 0; i < Input.Count; i++)
            {
                var inst = Input[i];
                var tempProgram = Input.ToList();

                if (inst.operation == "acc") continue;
                if (inst.operation == "nop") tempProgram[inst.index] = (inst.index, "jmp", inst.argument);
                if (inst.operation == "jmp") tempProgram[inst.index] = (inst.index, "nop", inst.argument);

                var t = Processor(tempProgram);

                if (!t.looping)
                {
                    p = t.result;
                    break;
                }

            }

            Console.WriteLine(p.ToString());
        }

        private static (bool looping, int result, List<int> history) Processor(
            List<(int index, string operation, int argument)> input)
        {
            var history = new List<int>();
            var accumulator = 0;
            var currentOffset = 0;
            var looping = false;
            while (true)
            {
                if (currentOffset == input.Count)
                {
                    break;
                }

                var instruction = input[currentOffset];
                if (history.Contains(instruction.index))
                {
                    looping = true;
                    break;
                }
                switch (instruction.operation)
                {
                    case "acc":
                        accumulator += instruction.argument;
                        currentOffset++;
                        break;
                    case "jmp":
                        currentOffset += instruction.argument;
                        break;
                    case "nop":
                        currentOffset++;
                        break;
                }
                history.Add(instruction.index);
            }
            return (looping, accumulator, history);
        }
    }
}
