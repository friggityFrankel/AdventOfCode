using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day1\input.txt";
            var input = System.IO.File.ReadAllLines(file);
            FindTwo(input);
            FindThree(input);
        }

        static void FindTwo(string[] input)
        {
            bool found = false;
            int number1 = 0;
            int number2 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int.TryParse(input[i], out number1);
                for (int j = i + 1; j < input.Length; j++)
                {
                    int.TryParse(input[j], out number2);
                    if (number1 + number2 == 2020)
                    {
                        found = true;
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            Console.WriteLine("Found Two:");
            Console.WriteLine($"number1: {number1}, number2: {number2}, result: {number1 * number2}");
        }

        static void FindThree(string[] input)
        {
            bool found = false;
            int number1 = 0;
            int number2 = 0;
            int number3 = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int.TryParse(input[i], out number1);
                for (int j = i + 1; j < input.Length; j++)
                {
                    int.TryParse(input[j], out number2);
                    for (int k = j + 1; k < input.Length; k++)
                    {
                        int.TryParse(input[k], out number3);
                        if (number1 + number2 + number3 == 2020)
                        {
                            found = true;
                            break;
                        }
                    }
                    if (found)
                    {
                        break;
                    }
                }
                if (found)
                {
                    break;
                }
            }
            Console.WriteLine("Found Three:");
            Console.WriteLine($"number1: {number1}, number2: {number2}, number3: {number3}, result: {number1 * number2 * number3}");
        }
    }
}