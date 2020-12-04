using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day4\input.txt";
            var fileText = System.IO.File.ReadAllText(file);
            var input = fileText.Split("\n\n");

            ValidatePassports(input);
        }

        private static void ValidatePassports(string[] passports)
        {
            var requiredFields = new string[] { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };
            var count = 0;
            foreach (var passport in passports)
            {
                var isValid = true;

                string[] p = passport.Split(new[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> d = p.Select(item => item.Split(':')).ToDictionary(i => i[0], i => i[1]);

                foreach (var field in requiredFields)
                {
                    if (!d.Keys.Contains(field))
                    {
                        isValid = false;
                        break;
                    }
                }

                if (isValid)
                {
                    count++;
                }

            }
            Console.WriteLine($"Valid: {count}");
        }
    }
}