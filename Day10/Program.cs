using System;
using System.Collections.Generic;
using System.Linq;

namespace Day10
{
    class Program
    {
        static string testInput = @"28
33
18
42
31
14
46
20
48
47
24
23
49
45
19
38
39
11
1
32
25
35
8
17
7
9
4
2
34
10
3";
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day10\input.txt";
            //var input = System.IO.File.ReadAllLines(file);
            var input = testInput.Split("\n");
            var jolts = input.Select(int.Parse).OrderBy(i => i).ToList();
            jolts.Insert(0, 0);

            CountJoltDifferences(jolts);
            CountValidArrangements(jolts);
        }

        private static void CountValidArrangements(List<int> jolts)
        {
            long valid = 0;
            // oy...
            Console.WriteLine($"Valid: {valid}");
        }

        private static void CountJoltDifferences(List<int> jolts)
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
