using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day6\input.txt";
            var input = System.IO.File.ReadAllText(file).Split("\n\n");

            Console.WriteLine($"Answers: {CountAnswers(input)}");
        }

        private static int CountAnswers(string[] input)
        {
            int count = 0;
            foreach (var item in input)
            {
                var answers = item.Replace("\n", "").Trim().ToCharArray();
                count += answers.Distinct().Count();
            }
            return count;
        }
    }
}
