using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        static List<int> jolts = new List<int>();
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day10\input.txt";
            var input = System.IO.File.ReadAllLines(file);
            
            jolts = input.Select(int.Parse).OrderBy(i => i).ToList();
            jolts.Insert(0, 0);

            CountJoltDifferences();
            CountValidArrangements();
        }

        private static void CountValidArrangements()
        {
            long valid = 0;
            // oy... no fucking clue, i give up till i read someone else's solution
            Console.WriteLine($"Valid: {valid}");
        }

        private static void CountJoltDifferences()
        {
            var diff1 = 0;
            var diff3 = 0;
            for (int i = 1; i < jolts.Count; i++)
            {
                switch (jolts[i] - jolts[i - 1])
                {
                    case 1:
                        diff1++;
                        break;
                    case 3:
                        diff3++;
                        break;
                }
            }
            diff3++;
            Console.WriteLine($"diff1: {diff1} * diff3: {diff3} = {diff1 * diff3}");
        }
    }
}
