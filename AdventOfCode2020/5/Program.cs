using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._5
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("5/input.txt")
                .Select(m => new Tuple<string, string>(m.Substring(0, 7).Replace('F', '0').Replace('B', '1'), m.Substring(7, 3).Replace('L', '0').Replace('R', '1')))
                .Select(m => new Tuple<int, int>(Convert.ToInt32(m.Item1, 2), Convert.ToInt32(m.Item2, 2)));                

            var part1 = data.Max(m => m.Item1 * 8 + m.Item2);
            Console.WriteLine($"Answer for day 5 part 1: {part1}");

            var row = data.GroupBy(m => m.Item1).Where(m => m.Count() == 7).First();
            var part2 = row.Key * 8 + (1+2+3+4+5+6+7 - row.Sum(m => m.Item2)); 
            Console.WriteLine($"Answer for day 5 part 2: {part2}");
        }
    }
}
