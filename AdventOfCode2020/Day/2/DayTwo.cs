using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayTwo
    {
        private static List<(int min, int max, char letter, string password)> Input => 
            File.ReadAllLines(@"Day\2\input.txt")
            .Select(x => x.Split(new[] { ':', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries))
            .Select(s => (Convert.ToInt32(s[0]), Convert.ToInt32(s[1]), Convert.ToChar(s[2]), s[3])).ToList();

        public static void ChallengeOne()
        {
            var p = Input.Count(x => x.password.Where(c => c == x.letter).CountBetween(x.min, x.max));
            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            var p = Input.Count(x => x.password.Where((c, i) => (i + 1 == x.min || i + 1 == x.max) && c == x.letter).Exactly(1));
            Console.WriteLine(p.ToString());
        }
    }
}
