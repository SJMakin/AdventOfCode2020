using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq;

namespace AdventOfCode2020
{
    internal static class DayFour
    {
        private static IEnumerable<Dictionary<string, string>> Input =>
            File.ReadAllLines(@"Day\4\input.txt")
                .GroupAdjacent(x => string.IsNullOrWhiteSpace(x), (_, group) => string.Join(' ', group))
                .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                                .Select(s => s.Split(':'))
                                .ToDictionary(a => a[0], a => a[1]))
                .Where(x => x.Any());

        public static void ChallengeOne()
        {
            var requiredFields = new[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            var p = Input.Count(x => requiredFields.All(f => x.ContainsKey(f)));
            Console.WriteLine(p.ToString());
        }

        public static void ChallengeTwo()
        {
            bool between(int value, int min, int max) => value >= min && value <= max;
            bool validYearRange(string s, int min, int max) => s.Length == 4 && between(Convert.ToInt32(s), min, max);

            var eyeColors = new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

            var requiredFields = new Dictionary<string, Predicate<string>>
            {
                {"byr", (s) => validYearRange(s, 1920, 2002) },
                {"iyr", (s) => validYearRange(s, 2010, 2020) },
                {"eyr", (s) => validYearRange(s, 2020, 2030) },
                {"hgt", (s) =>
                    {
                        var height = Convert.ToInt32(new string(s.TakeWhile(c => char.IsDigit(c)).ToArray()));
                        return (s.EndsWith("cm", StringComparison.OrdinalIgnoreCase) && between(height, 150, 193))
                            || (s.EndsWith("in", StringComparison.OrdinalIgnoreCase) && between(height, 59, 76));
                    }
                },
                {"hcl", (s) => s.Length == 7 && s.StartsWith('#') && int.TryParse(s.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out _)},
                {"ecl", (s) => eyeColors.Any(c => string.Equals(c, s, StringComparison.OrdinalIgnoreCase)) },
                {"pid", (s) => s.Length == 9 && s.All(c => char.IsDigit(c)) }
            };

            var p = Input.Count(x => requiredFields.All(f => x.ContainsKey(f.Key) && f.Value(x[f.Key])));
            Console.WriteLine(p.ToString());
        }
    }
}
