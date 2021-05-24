using System;
using System.Linq;

namespace AdventOfCode2020.Day3
{
    class Day3
    {
        public static void Run()
        {
            var map = System.IO.File.ReadAllLines("Day3/day3.txt")
            // var map = System.IO.File.ReadAllLines("Day3/example.txt")
                .Select(line => line.Select(c => c == '#').ToArray()).ToArray();
            Console.WriteLine(
                CheckSlope(map, 1, 1) *
                CheckSlope(map, 1, 3) *
                CheckSlope(map, 1, 5) *
                CheckSlope(map, 1, 7) *
                CheckSlope(map, 2, 1));
        }

        static long CheckSlope(bool[][] map, int down, int right)
        {
            var width = map[0].Length;
            var x = 0;
            var trees = 0;
            for (var y = 0; y < map.Length; y += down)
            {
                Console.WriteLine("[{0},{1}]: {2}", x % width, y, map[y][x % width]);
                if (map[y][x % width]) trees++;
                x += right;
            }
            Console.WriteLine(trees);
            return trees;
        }
    }
}
