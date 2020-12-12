using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DaySeven
    {
        private static Dictionary<string, List<(int count, string bag)>> Input =>
            File.ReadAllLines(@"Day\7\input.txt")
            .Select(x => x.Replace(" bags", "").Replace(" bag", "").Replace(".", ""))
            .Select(x => x.Split(" contain "))
            .ToDictionary(x => x.First(), x => string.Equals(x.Last(), "no other", StringComparison.OrdinalIgnoreCase)
                                                ? new List<(int count, string bag)>()
                                                : x.Last()
                                                    .Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                                    .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                                                    .Select(x => (Convert.ToInt32(x.First()), string.Join(' ', x.Skip(1)))).ToList()
            );

        public static void ChallengeOne()
        {
            var p = MoreEnumerable.Unfold(new List<string>() { "shiny gold" }
                                            , x => Input.Where(a => a.Value.Any(b => x.Contains(b.bag))).Select(c => c.Key).ToList()
                                            , x => x.Count > 0
                                            , x => x
                                            , x => x)
                                    .SelectMany(x => x)
                                    .Distinct()
                                    .OrderBy(x => x)
                                    .Count();

            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            // Think im going to have to give up on LINQ only at this point.
            var p = GetBagCount("shiny gold") - 1; 
            Console.WriteLine(p.ToString());
        }

        private static int GetBagCount(string target)
        {
            var result = 1;

            foreach (var child in Input[target])
                result += child.count * GetBagCount(child.bag);

            return result;
        }
    }
}
