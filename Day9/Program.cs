using System;
using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day9\input.txt";
            var input = System.IO.File.ReadAllLines(file);

            FindInvalidNumber(input);
        }

        private static void FindInvalidNumber(string[] input)
        {
            var preamble = 25;
            for (int i = preamble; i < input.Length; i++)
            {
                var isValid = false;
                for (int j = i - preamble; j < i; j++)
                {
                    for (int k = j + 1; k < i; k++)
                    {
                        if (long.Parse(input[j]) + long.Parse(input[k]) == long.Parse(input[i]))
                        {
                            isValid = true;
                            break;
                        }
                    }
                }
                if (!isValid)
                {
                    Console.WriteLine($"Invalid: {input[i]}");
                    FindContiguousSum(input, i);
                }
            }
        }

        private static void FindContiguousSum(string[] input, int index)
        {
            long low = 0;
            long high = 0;
            for (int i = 0; i < index; i++)
            {
                var nums = new List<long>();
                for (int j = i; j < index; j++)
                {
                    nums.Add(long.Parse(input[j]));
                    if (nums.Sum() == long.Parse(input[index]))
                    {
                        low = nums.Min();
                        high = nums.Max();
                        break;
                    }
                }
            }

            Console.WriteLine($"Lowest: {low}");
            Console.WriteLine($"Highest: {high}");
            Console.WriteLine($"Combined: {low + high}");
        }
    }
}
