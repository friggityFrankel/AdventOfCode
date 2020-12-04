using System;
using System.Collections.Generic;
using System.Drawing;
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
                string[] p = passport.Split(new[] { " ", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> fields = p.Select(item => item.Split(':')).ToDictionary(i => i[0], i => i[1]);

                var isValid = (fields.Keys.Contains("byr") && ValidateByr(fields["byr"])
                            && fields.Keys.Contains("iyr") && ValidateIyr(fields["iyr"])
                            && fields.Keys.Contains("eyr") && ValidateEyr(fields["eyr"])
                            && fields.Keys.Contains("hgt") && ValidateHgt(fields["hgt"])
                            && fields.Keys.Contains("hcl") && ValidateHcl(fields["hcl"])
                            && fields.Keys.Contains("ecl") && ValidateEcl(fields["ecl"])
                            && fields.Keys.Contains("pid") && ValidatePid(fields["pid"])
                            ) ? true : false;

                if (isValid)
                {
                    count++;
                }

            }
            Console.WriteLine($"Valid: {count}");
        }

        private static bool ValidateByr(string input)
        {
            //four digits; at least 1920 and at most 2002.
            var isValid = false;
            if (input.Length == 4)
            {
                var year = 0;
                int.TryParse(input, out year);
                if (year >= 1920 && year <= 2002)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static bool ValidateIyr(string input)
        {
            //four digits; at least 2010 and at most 2020.
            var isValid = false;
            if (input.Length == 4)
            {
                var year = 0;
                int.TryParse(input, out year);
                if (year >= 2010 && year <= 2020)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static bool ValidateEyr(string input)
        {
            //four digits; at least 2020 and at most 2030.
            var isValid = false;
            if (input.Length == 4)
            {
                var year = 0;
                int.TryParse(input, out year);
                if (year >= 2020 && year <= 2030)
                {
                    isValid = true;
                }
            }
            return isValid;
        }

        private static bool ValidateHgt(string input)
        {
            //a number followed by either cm or in:
            //If cm, the number must be at least 150 and at most 193.
            //If in, the number must be at least 59 and at most 76.
            var height = 0;
            int.TryParse(input.Substring(0, input.Length - 2), out height);
            var isValid = (input.EndsWith("cm") && height >= 150 && height <= 193) || (input.EndsWith("in") && height >= 59 && height <= 76) ? true : false;
            return isValid;
        }

        private static bool ValidateHcl(string input)
        {
            //a # followed by exactly six characters 0-9 or a-f.
            var isValid = false;
            try
            {
                var c = ColorTranslator.FromHtml(input);
                isValid = true;
            }
            catch { }
            
            return isValid;
        }

        private static bool ValidateEcl(string input)
        {
            //exactly one of: amb blu brn gry grn hzl oth.
            var validEcl = new string[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            var isValid = (validEcl.Contains(input)) ? true : false;
            return isValid;
        }

        private static bool ValidatePid(string input)
        {
            //a nine-digit number, including leading zeroes.
            var isValid = false;
            if (input.Length == 9)
            {
                var pid = -1;
                int.TryParse(input, out pid);
                if (pid > -1)
                {
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}