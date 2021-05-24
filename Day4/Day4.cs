using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day4
{
    class Day4
    {
        public static void Run()
        {
            string[] validHcl = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var count = System.IO.File.ReadAllText("Day4/day4.txt")
                .Split("\n\n")
                .Select(passport => passport.Replace("\n", " ")
                    .Split(" ")
                    .Select(entry => entry.Split(":"))
                        .Where(it => it.Length == 2)
                        .ToDictionary(it => it[0], it => it[1]))
                .Count(passport => {
                    foreach (var it in passport)
                    {
                        Console.WriteLine("{0}:{1}", it.Key, it.Value);
                    }
                    var height = passport.GetValueOrDefault("hgt", "");
                    var valid = Validate(passport.GetValueOrDefault("byr"), 1920, 2002)
                        && Validate(passport.GetValueOrDefault("iyr"), 2010, 2020)
                        && Validate(passport.GetValueOrDefault("eyr"), 2020, 2030)
                        && ((height.EndsWith("cm") && Validate(height, 150, 193)) || (height.EndsWith("in") && Validate(height, 59, 76)))
                        && new Regex(@"^#[0-9a-f]{6}$").Match(passport.GetValueOrDefault("hcl", "")).Success
                        && validHcl.Contains(passport.GetValueOrDefault("ecl", ""))
                        && new Regex(@"^\d{9}$").Match(passport.GetValueOrDefault("pid", "")).Success
                    ;
                    Console.WriteLine(valid);
                    return valid;
                });
            Console.WriteLine(count);
        }

        private static int ParseInt(string value, int radix = 10)
        {
            if (String.IsNullOrEmpty(value)) return -1;
            var result = Convert.ToInt16(new Regex(@"[1-9]\d+").Match(value).Groups[0].Value, radix);
            Console.WriteLine("{0} => {1}", value, result);
            return result;
        }

        private static bool Validate(string value, int min, int max) {
            var number = ParseInt(value);
            return number >= min && number <= max;
        }

        private static bool Has(string[] entries, string key)
        {
            return entries.Any(it => it.StartsWith(key + ":"));
        }
    }
}
