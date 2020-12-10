using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._9
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("9/input.txt")
                .Select(long.Parse)
                .ToList();

            int counter = 25;
            bool hasProperty() {
                var dataToCheck = data.Skip(counter - 25).Take(25);
                return dataToCheck.Any(m => dataToCheck.Any(n => n != m && m + n == data[counter]));
            };

            while (hasProperty())
            {
                counter++;
            }

            var part1 = data[counter];
            Console.WriteLine($"Answer for day 9 part 1: {part1}");

            long CalculatePart2()
            {
                for (int i = 0; i < data.Count; i++)
                {
                    for (int j = 2; j <= data.Count - i; j++)
                    {
                        var numbers = data.Skip(i).Take(j);                      
                        if (numbers.Sum() == part1)
                            return (numbers.Min() + numbers.Max());
                    }
                }
                return 0;
            }

            var part2 = CalculatePart2();
            Console.WriteLine($"Answer for day 9 part 2: {part2}");
        }
    }
}
