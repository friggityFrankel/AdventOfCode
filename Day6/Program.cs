using System;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day6\input.txt";
            var input = System.IO.File.ReadAllText(file).Split("\n\n");

            Console.WriteLine($"Unique Answers: {CountUniqueAnswers(input)}");
            Console.WriteLine($"All Answered: {CountAllAnswered(input)}");
        }

        private static int CountAllAnswered(string[] input)
        {
            int count = 0;
            foreach (var group in input)
            {
                var answers = group.Split("\n", StringSplitOptions.RemoveEmptyEntries).ToList();
                var first = answers[0].ToCharArray().ToList();
                foreach (var item in answers)
                {
                    first = first.Intersect(item.ToCharArray().ToList()).ToList();
                }
                count += first.Count();
            }
            return count;
        }

        private static int CountUniqueAnswers(string[] input)
        {
            int count = 0;
            foreach (var group in input)
            {
                var answers = group.Replace("\n", "").Trim().ToCharArray();
                count += answers.Distinct().Count();
            }
            return count;
        }


    }
}
