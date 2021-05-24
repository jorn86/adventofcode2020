using System;
using System.Linq;

namespace AdventOfCode2020.Day1
{
    class Day1
    {
        public static void Run()
        {
            var lines = System.IO.File.ReadAllLines("Day1/day1.txt").Select(v => Int16.Parse(v)).ToArray();
            for (var i = 0; i < lines.Length; i++)
            {
                for (var j = i + 1; j < lines.Length; j++)
                {
                    for (var k = j; k < lines.Length; k++)
                    {
                        if (lines[i] + lines[j] + lines[k] == 2020)
                        {
                            Console.WriteLine(lines[i] * lines[j] * lines[k]);
                        }
                    }
                }
            }
        }
    }
}
