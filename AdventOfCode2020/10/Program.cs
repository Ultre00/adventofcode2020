using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._10
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("10/input.txt")
                .Select(long.Parse)
                .ToList();

            var part1 = 1;
            Console.WriteLine($"Answer for day 10 part 1: {part1}");
        }
    }
}
