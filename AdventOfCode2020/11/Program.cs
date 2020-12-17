using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2020._11
{
    public static class Program
    {
        public static void part1()
        {
            var data = File.ReadLines("11/input.txt")
                .Select(m => m.ToArray())
                .ToArray();

            var numSeats = new int[2];

            int CountSurroundingOccupied(int x, int y, char[][] data)
            {
                int occupied = 0;
                for (int i = (x > 0 ? -1 : 0); i <= (x < (data[0].Length - 1) ? 1 : 0); i++)
                {
                    for (int j = (y > 0 ? -1 : 0); j <= (y < (data.Length - 1) ? 1 : 0); j++)
                    {
                        if (data[y + j][x + i] == '#' && (i != j || i != 0))
                        {
                            occupied++;
                        }
                    }
                }
                return occupied;
            }

            char getNewChar(int x, int y, char[][] data)
            {
                int count = CountSurroundingOccupied(x, y, data);
                return (data[y][x]) switch
                {
                    'L' => count == 0 ? '#' : 'L',
                    '#' => count >= 4 ? 'L' : '#',
                    _ => '.',
                };
            }

            char[][] applyRules(char[][] input)
            {
                var newData = new char[input.Length][];
                for (int i = 0; i < newData.Length; i++)
                {
                    newData[i] = new char[input[0].Length];
                }
                for (int y = 0; y < data.Length; y++)
                {
                    for (int x = 0; x < data[0].Length; x++)
                    {
                        newData[y][x] = getNewChar(x, y, input);
                    }
                }
                return newData;
            }

            var nextData = data;
            do
            {
                nextData = applyRules(nextData);
                numSeats[0] = numSeats[1];
                numSeats[1] = nextData.SelectMany(m => m).Count(m => m == '#');
            } while (numSeats[0] != numSeats[1]);

            var part1 = numSeats[0];
            Console.WriteLine($"Answer for day 11 part 1: {part1}");
        }

        public static void part2()
        {
            var data = File.ReadLines("11/input.txt")
                .Select(m => m.ToArray())
                .ToArray();

            var numSeats = new int[2];

            int CountSurroundingOccupied(int x, int y, char[][] data)
            {
                int checkLeft()
                {
                    for (int i = 1; i <= x; i++)
                    {
                        var c = data[y][x - i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkRight()
                {
                    for (int i = 1; i <= data[0].Length - x - 1; i++)
                    {
                        var c = data[y][x + i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkTop()
                {
                    for (int i = 1; i <= y; i++)
                    {
                        var c = data[y - i][x];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkBottom()
                {
                    for (int i = 1; i <= data.Length - y - 1; i++)
                    {
                        var c = data[y + i][x];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkTopLeft()
                {
                    for (int i = 1; i <= Math.Min(x, y); i++)
                    {
                        var c = data[y - i][x - i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkTopRight()
                {
                    for (int i = 1; i <= Math.Min(data[0].Length - x - 1, y); i++)
                    {
                        var c = data[y - i][x + i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkBottomLeft()
                {
                    for (int i = 1; i <= Math.Min(x, data.Length - y - 1); i++)
                    {
                        var c = data[y + i][x - i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                int checkBottomRight()
                {
                    for (int i = 1; i <= Math.Min(data[0].Length - x - 1, data.Length - y - 1); i++)
                    {
                        var c = data[y + i][x + i];
                        if (c == '#') return 1;
                        if (c == 'L') return 0;
                    }
                    return 0;
                }

                return checkLeft() + checkRight() + checkTop() + checkBottom() + checkTopLeft() + checkTopRight() + checkBottomLeft() + checkBottomRight();
            }

            char getNewChar(int x, int y, char[][] data)
            {
                int count = CountSurroundingOccupied(x, y, data);
                return (data[y][x]) switch
                {
                    'L' => count == 0 ? '#' : 'L',
                    '#' => count >= 5 ? 'L' : '#',
                    _ => '.',
                };
            }

            char[][] applyRules(char[][] input)
            {
                var newData = new char[input.Length][];
                for (int i = 0; i < newData.Length; i++)
                {
                    newData[i] = new char[input[0].Length];
                }
                for (int y = 0; y < data.Length; y++)
                {
                    for (int x = 0; x < data[0].Length; x++)
                    {
                        newData[y][x] = getNewChar(x, y, input);
                    }
                }
                return newData;
            }

            var nextData = data;
            do
            {
                nextData = applyRules(nextData);
                numSeats[0] = numSeats[1];
                numSeats[1] = nextData.SelectMany(m => m).Count(m => m == '#');
            } while (numSeats[0] != numSeats[1]);

            var part2 = numSeats[0];
            Console.WriteLine($"Answer for day 11 part 2: {part2}");
        }

        public static void Run()
        {
            part1();
            part2();
        }
    }
}
