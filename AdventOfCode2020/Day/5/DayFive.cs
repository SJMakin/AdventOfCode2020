using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayFive
    {
        private static IEnumerable<(string row, string col)> Input =>
            File.ReadAllLines(@"Day\5\input.txt").Select(x => (x.Substring(0, 7), x.Substring(7, 3)))
            ;


        public static void ChallengeOne()
        {
            (int min, int max) half(bool upper, int min, int max) => upper ? ((min + max + 1) / 2, max) : (min, (min + max) / 2);
            var p = Input.Select(x => x.row.Scan((min: 0, max: 127), (acc, dir) => half(dir == 'B', acc.min, acc.max)).Last().max * 8
                                    + x.col.Scan((min: 0, max: 7), (acc, dir) => half(dir == 'R', acc.min, acc.max)).Last().max)
                            .Max();

            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {

            (int min, int max) half(bool upper, int min, int max) => upper ? ((min + max + 1) / 2, max) : (min, (min + max) / 2);
            var i = Input.Select(x => x.row.Scan((min: 0, max: 127), (acc, dir) => half(dir == 'B', acc.min, acc.max)).Last().max * 8
                                    + x.col.Scan((min: 0, max: 7), (acc, dir) => half(dir == 'R', acc.min, acc.max)).Last().max)
                            .OrderBy(x => x)
                            .ToList();
            var p = Enumerable.Range(i.Min(), i.Max() - i.Min()).Except(i).FirstOrDefault();
            Console.WriteLine(p.ToString());
        }
    }
}
