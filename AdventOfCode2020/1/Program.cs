using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2020._1
{
    public static class Program
    {
        public static void Run()
        {
            var numbers = File.ReadAllLines("1/input.txt").Select(int.Parse).ToArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if(numbers[i] + numbers[j] == 2020)
                    {
                        Console.WriteLine($"Answer for day 1 part 1: {numbers[i] * numbers[j]}");
                    }
                    for (int k = j + 1; k < numbers.Length; k++)
                    {
                        if (numbers[i] + numbers[j] + numbers[k] == 2020)
                        {
                            Console.WriteLine($"Answer for day 1 part 2: {numbers[i] * numbers[j] * numbers[k]}");
                        }
                    }
                }
            }
        }
    }
}
