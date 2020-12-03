using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayThree
    {
        private static IEnumerable<string> Input =>
            File.ReadAllLines(@"Day\3\input.txt");

        public static void ChallengeOne()
        {
            var p = Input.Select((x, i) => x[(3 * i) % x.Length]).Count(x => x == '#');
            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            var stagerations = new List<(int right, int down)> { (1, 1), (3, 1), (5, 1), (7, 1), (1, 2) };
            var p = stagerations.Select(s => Input.TakeEvery(s.down)
                                                  .Select((x, i) => x[(s.right * i) % x.Length])
                                                  .LongCount(x => x == '#'))
                                .Aggregate((a, b) => a * b);
            Console.WriteLine(p.ToString());
        }
    }
}
