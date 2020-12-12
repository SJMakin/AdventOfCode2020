using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayNine
    {
        private static List<long> Input =
            File.ReadAllLines(@"Day\9\input.txt")
            .Select(x => Convert.ToInt64(x))
            .ToList();

        public static void ChallengeOne()
        {
            long p = -1;
            const int preableLength = 25;
            for (var i = 25; i < Input.Count; i++)
            {
                var range = Input.GetRange(i - preableLength, preableLength);
                var possibilities = range.Subsets(2).Select(y => y.Sum(x => x));
                p = Input[i];
                if (!possibilities.Contains(p)) break;
            }
            Console.WriteLine(p);
        }

        public static void ChallengeTwo()
        {
            var target = 1309761972;
            var start = 0;
            var end = 0;
            for (var i = 0; i < Input.Count; i++)
            {
                var c = (long) 0;
                start = i;               
                for (var j = i; j < Input.Count; j++)
                {
                    c += Input[j];
                    end = j;
                    if (c >= target) break;
                }
                if (c == target) break;
            }
            var range = Input.GetRange(start, end - start + 1);
            var p = range.Min() + range.Max();
            Console.WriteLine(p);
        }

    }
}
