using System;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day3\input.txt";
            var input = System.IO.File.ReadAllLines(file);

            var result1 = CountTrees(input, new int[] { 1, 1 });
            var result2 = CountTrees(input, new int[] { 3, 1 });
            var result3 = CountTrees(input, new int[] { 5, 1 });
            var result4 = CountTrees(input, new int[] { 7, 1 });
            var result5 = CountTrees(input, new int[] { 1, 2 });
            long product = result1 * result2 * result3 * result4 * result5;

            Console.WriteLine($"{result1} * {result2} * {result3} * {result4} * {result5} = {product}");

        }

        private static long CountTrees(string[] input, int[] slope)
        {
            long count = 0;
            for (int x = 0, y = 0; y < input.Length; y += slope[1], x = (x + slope[0]) % input[0].Length)
            {
                if (input[y][x] == '#')
                {
                    count++;
                }
            }
            return count;
        }
    }
}