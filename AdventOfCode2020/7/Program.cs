using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._7
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("7/input.txt")
                .Select(m => m.Split("contain"))
                .Select(m => new KeyValuePair<string, string[]>(string.Join(' ', m[0].Split(' ').Take(2)), m[1].Split(", ")))
                .Select(m => new KeyValuePair<string, (string name, int amount)[]>(m.Key,
                    m.Value[0].Contains("no other bags") ? new (string name, int amount)[0]
                    : m.Value.Select(n => (
                        string.Join(' ', n.Trim().Split(' ').Skip(1).Take(2)), 
                        int.Parse(n.Trim().Split(' ')[0]))).ToArray()))
                .ToDictionary(m => m.Key, m => m.Value);                

            bool HasGold(string record) => data[record].Any(m => m.name == "shiny gold" || HasGold(m.name));
            var part1 = data.Keys.Count(HasGold);            
            Console.WriteLine($"Answer for day 7 part 1: {part1}");

            int CountBags(string record, int multiplier) => data[record].Sum(m => m.amount * multiplier + CountBags(m.name, m.amount * multiplier));
            var part2 = CountBags("shiny gold", 1);
            Console.WriteLine($"Answer for day 7 part 2: {part2}");
        }
    }
}
