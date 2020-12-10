using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020._8
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadLines("8/input.txt")
                .Select(m => (operation: m.Split(' ')[0], argument: int.Parse(m.Split(' ')[1]), visited: false))
                .ToList();

            (int accumulator, bool success) Execute(int position, int accumulator)
            {
                if (position == data.Count)
                    return (accumulator, true);

                (string operation, int argument, bool visited) = data[position];

                if (visited)
                    return (accumulator, false);

                data[position] = (operation, argument, true);

                return data[position].operation switch
                {
                    "jmp" => Execute(position + argument, accumulator),
                    "acc" => Execute(position + 1, accumulator + argument),
                    _ => Execute(position + 1, accumulator),
                };
            }

            var part1 = Execute(0, 0);            
            Console.WriteLine($"Answer for day 8 part 1: {part1.accumulator}");

            var part2 = (accumulator: 0, success: false);
            var counter = 0;
            do
            {
                for (int i = counter; i < data.Count; i++)
                {
                    if(data[i].operation is "jmp" or "nop")
                    {
                        counter = i;
                        break;
                    }
                }
                data = data.Select(m => (m.operation, m.argument, false)).ToList();
                (string operation, int argument, bool visited) = data[counter];
                data[counter] = (operation == "jmp" ? "nop" : "jmp", argument, visited);
                part2 = Execute(0, 0);
                data[counter] = (operation, argument, visited);
                counter++;
            } while (!part2.success) ;

            Console.WriteLine($"Answer for day 8 part 2: {part2.accumulator}");

        }
    }
}
