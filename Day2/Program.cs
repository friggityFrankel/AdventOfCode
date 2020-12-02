using System;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day2\input.txt";
            var input = System.IO.File.ReadAllLines(file);
            ValidatePart1(input);
            ValidatePart2(input);
        }

        private static void ValidatePart1(string[] input)
        {
            var validCount = 0;
            try
            {
                foreach (var line in input)
                {
                    var pw = line.Split(' ');

                    var countLow = 0;
                    var countHigh = 0;

                    int.TryParse(pw[0].Split('-')[0], out countLow);
                    int.TryParse(pw[0].Split('-')[1], out countHigh);

                    var ch = pw[1][0];
                    var frequency = pw[2].Where(c => (c == ch)).Count();

                    if (frequency >= countLow && frequency <= countHigh)
                    {
                        validCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Part 1 - Valid Passwords: {validCount}");
        }

        private static void ValidatePart2(string[] input)
        {
            var validCount = 0;
            try
            {
                foreach (var line in input)
                {
                    var pw = line.Split(' ');

                    var index1 = 0;
                    var index2 = 0;

                    int.TryParse(pw[0].Split('-')[0], out index1);
                    int.TryParse(pw[0].Split('-')[1], out index2);

                    var ch = pw[1][0];

                    if (pw[2][index1 - 1] == ch ^ pw[2][index2 - 1] == ch )
                    {
                        validCount++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine($"Part 2 - Valid Passwords: {validCount}");
        }

    }
}
