using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._3
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadAllLines("3/input.txt");

            var part1 = data.CheckSlope(3, 1);
            Console.WriteLine($"Answer for day 3 part 1: {part1}");

            var part2 = part1 * data.CheckSlope(1, 1) * data.CheckSlope(5, 1) * data.CheckSlope(7, 1) * data.CheckSlope(1, 2);
            Console.WriteLine($"Answer for day 3 part 2: {part2}");
        }

        public static long CheckSlope(this string[] data, int right, int down)
        {
            Tuple<int, int> position = new Tuple<int, int>(0, 0);
            long numTrees = 0;

            var (x, y) = position;
            while (y < data.Length)
            {
                if (data[y][x] == '#')
                {
                    numTrees++;
                }
                x = (x + right) % data[0].Length;
                y += down;
            }

            return numTrees;
        }
    }
}
