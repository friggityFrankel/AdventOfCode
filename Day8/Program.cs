using System;
using System.Collections.Generic;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day8\input.txt";
            var input = System.IO.File.ReadAllLines(file);

            RunInstructions(input);
        }

        private static void RunInstructions(string[] input)
        {
            var index = 0;
            var accumulator = 0;
            var instructions = new List<int>();
            var doLoop = true;
            while (doLoop)
            {
                if (instructions.Contains(index))
                {
                    doLoop = false;
                }
                else
                {
                    instructions.Add(index);
                    var instruct = input[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    switch (instruct[0])
                    {
                        case "acc":
                            accumulator += int.Parse(instruct[1]);
                            index += 1;
                            break;
                        case "jmp":
                            index += int.Parse(instruct[1]);
                            break;
                        case "nop":
                            index += 1;
                            break;
                    }
                }
            }
            Console.WriteLine($"Accumulator: {accumulator}");
        }
    }
}
