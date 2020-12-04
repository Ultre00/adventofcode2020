using System;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._2
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadAllLines("2/input.txt")
                .Select(m => m.Split(' '))
                .Select(m => m[0].Split('-').Concat(new string[] { m[1].Replace(":", " "), m[2] }).ToArray())
                .Select(m => new Tuple<int, int, char, string>(int.Parse(m[0]), int.Parse(m[1]), m[2][0], m[3]));

            Console.WriteLine($"Answer for day 2 part 1: {data.Count(m => m.Item4.Count(n => n == m.Item3) >= m.Item1 && m.Item4.Count(n => n == m.Item3) <= m.Item2) }");

            var count = data.Count(m =>
                (m.Item4[m.Item1 - 1] == m.Item3 && m.Item4[m.Item2 - 1] != m.Item3)
                || (m.Item4[m.Item1 - 1] != m.Item3 && m.Item4[m.Item2 - 1] == m.Item3));
            Console.WriteLine($"Answer for day 2 part 2: {count}");
        }
    }
}
