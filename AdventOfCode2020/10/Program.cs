using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020._10
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("10/input.txt")
                .Select(int.Parse)
                .OrderBy(m => m)
                .ToList();
            data.Add(data.Last() + 3);
            data.Insert(0, 0);

            (int countOnes, int CountThrees, _) = data
                .Aggregate((countOnes: 0, countThrees: 0, previous: 0), (result, current) =>
                {
                    (int countOnes, int countThrees, int previous) = result;
                    var jolts = current - previous;
                    if (jolts == 1) countOnes++;
                    else if (jolts == 3) countThrees++;
                    return (countOnes, countThrees, current);
                });

            var part1 = countOnes * CountThrees;
            Console.WriteLine($"Answer for day 10 part 1: {part1}");


            var possibilityMap = new BigInteger[data.Count];
            possibilityMap[data.Count - 1] = 1;

            for (int i = data.Count - 2; i >= 0; i--)
            {
                var cur = data[i];
                var indexesToCheck = data.Where(m => m > cur && m <= cur + 3)
                    .Select(m => data.IndexOf(m))
                    .ToList();

                possibilityMap[i] = indexesToCheck.Aggregate((BigInteger)0, (result, cur) => result + possibilityMap[cur]);
            }

            var part2 = possibilityMap[0];

            Console.WriteLine($"Answer for day 10 part 2: {part2}");

        }
    }
}
