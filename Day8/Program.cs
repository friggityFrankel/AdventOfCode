using System;
using System.Collections.Generic;
using System.Linq;

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
            var wasSuccessful = false;
            var correctAccumulator = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var testArray = input.ToList();
                var index = 0;
                var accumulator = 0;
                var instructions = new List<int>();
                var doLoop = true;
                var testSwitch = testArray[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (testSwitch[0] == "jmp")
                {
                    testArray[i] = "nop " + testSwitch[1];
                }
                else if (testSwitch[0] == "nop")
                {
                    testArray[i] = "jmp " + testSwitch[1];
                }

                while (doLoop)
                {
                    if (instructions.Contains(index))
                    {
                        doLoop = false;
                    }
                    else
                    {
                        instructions.Add(index);

                        var instruct = testArray[index].Split(" ", StringSplitOptions.RemoveEmptyEntries);
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

                        if (index == testArray.Count)
                        {
                            wasSuccessful = true;
                            doLoop = false;
                        }
                    }
                }

                if (wasSuccessful)
                {
                    correctAccumulator = accumulator;
                    break;
                }
                //Console.WriteLine($"Accumulator: {accumulator}");
            }

            Console.WriteLine(correctAccumulator);
        }
    }
}
