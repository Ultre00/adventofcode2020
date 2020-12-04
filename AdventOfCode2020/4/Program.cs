using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020._4
{
    public static class Program
    {
        public static void Run()
        {
            var data = File.ReadAllText("4/input.txt")
                .Split("\r\n\r\n")
                .Select(m => m.Split("\r\n")
                              .SelectMany(n => n.Split(' '))
                              .Select(n => n.Split(':'))
                              .Select(n => new KeyValuePair<string, string>(n[0], n[1])))
                .Select(m => new Dictionary<string, string>(m));

            var part1 = data.Where(m => 
                m.ContainsKey("byr")
                && m.ContainsKey("iyr")
                && m.ContainsKey("eyr")
                && m.ContainsKey("hgt")
                && m.ContainsKey("hcl")
                && m.ContainsKey("ecl")
                && m.ContainsKey("pid")
            );

            Console.WriteLine($"Answer for day 4 part 1: {part1.Count()}");

            var part2 = part1.Where(m => 
                int.TryParse(m["byr"], out int byr) && byr is >= 1920 and <= 2002
                && int.TryParse(m["iyr"], out int iyr) && iyr is >= 2010 and <= 2020
                && int.TryParse(m["eyr"], out int eyr) && eyr is >= 2020 and <= 2030
                && HeightValid(m["hgt"])
                && HairColorValid(m["hcl"])
                && EyeColorValid(m["ecl"])
                && PassportIdValid(m["pid"])
            );

            Console.WriteLine($"Answer for day 4 part 2: {part2.Count()}");
        }

        private static bool HeightValid(string hgt)
        {
            var result = hgt.Split("cm");
            if(result.Length == 2)
            {
                if (int.TryParse(result[0], out int height) && height is >= 150 and <= 193)
                {
                    return true;
                }
            }

            result = hgt.Split("in");
            if (result.Length == 2)
            {
                if (int.TryParse(result[0], out int height) && height is >= 59 and <= 76)
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HairColorValid(string hcl)
        {
            bool result = new Regex(@"^#(?:[0-9a-f]{6})$").IsMatch(hcl);
            return result;
        }

        private static bool EyeColorValid(string ecl)
        {
            return new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(ecl);
        }

        private static bool PassportIdValid(string pid)
        {
            bool result = new Regex(@"\b\d{9}\b").IsMatch(pid);
            return result;
        }
    }
}
