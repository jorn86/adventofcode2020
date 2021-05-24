using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day2
{
    class Day2
    {
        public static void Run()
        {
            var regex = new Regex(@"^(\d+)-(\d+) (\w): (\w+)$");
            var count = System.IO.File.ReadAllLines("Day2/day2.txt")
                .Select(line => regex.Matches(line)[0].Groups)
                .Select(groups => new Line(Int16.Parse(groups[1].Value) - 1, Int16.Parse(groups[2].Value) - 1, groups[3].Value[0], groups[4].Value))
                .Count(line => {
                    if (line.Password.Length <= line.SecondIndex) return false;
                    var first = line.Password[line.FirstIndex] == line.Letter;
                    var second = line.Password[line.SecondIndex] == line.Letter;
                    return first != second;
                });
            Console.WriteLine(count);
        }
    }

    record Line(int FirstIndex, int SecondIndex, char Letter, string Password);
}
