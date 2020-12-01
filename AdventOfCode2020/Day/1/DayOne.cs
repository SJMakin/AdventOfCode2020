using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayOne
    {
        private static List<int> Input => File.ReadAllLines(@"Day\1\input.txt").Select(s => Convert.ToInt32(s)).ToList();

        public static void ChallengeOne()
        {
            var p = Input.Subsets(2).FirstOrDefault(p => p.Sum() == 2020).Aggregate((a, b) => a * b);
            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            var p = Input.Subsets(3).FirstOrDefault(p => p.Sum() == 2020).Aggregate((a, b) => a * b);
            Console.WriteLine(p.ToString());
        }
    }
}
