using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._6
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadAllText("6/input.txt")
                .Split("\r\n\r\n");

            var part1 = data
                .Select(m => m.Where(n => n is >= 'a' and <= 'z').Distinct())
                .Sum(m => m.Count());

            Console.WriteLine($"Answer for day 6 part 1: {part1}");

            var part2 = data
                .Select(m => m.Split("\r\n"))
                .Select(m => m.Aggregate((result, cur) => string.Concat(result.Where(n => cur.Any(o => o == n)))))
                .Sum(m => m.Length);

            Console.WriteLine($"Answer for day 6 part 2: {part2}");
        }
    }
}
