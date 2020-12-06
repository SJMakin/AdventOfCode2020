using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DaySix
    {
        private static IEnumerable<IEnumerable<char[]>> Input =>
            File.ReadAllLines(@"Day\6\input.txt")
            .GroupAdjacent(x => string.IsNullOrWhiteSpace(x), 
                                (_, group) => group.Select(x => x.ToCharArray()));


        public static void ChallengeOne()
        {
            var p = Input.Select(x => x.Aggregate<IEnumerable<char>>((a, b) => a.Union(b)))
                         .Select(x => x.Count()).Sum();
            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            var p = Input.Select(x => x.Aggregate<IEnumerable<char>>((a, b) => a.Intersect(b)))
                         .Select(x => x.Count()).Sum();
            Console.WriteLine(p.ToString());
        }
    }
}
