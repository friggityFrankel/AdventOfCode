using System;
using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day5\input.txt";
            var input = System.IO.File.ReadAllLines(file);

            FindSeat(input);
        }

        private static void FindSeat(string[] input)
        {
            // Part 1
            var seatIds = new List<int>();
            foreach (var item in input)
            {
                var row = GetRange(0, 127, item.Substring(0,7));
                var seat = GetRange(0, 7, item.Substring(7));
                seatIds.Add((row*8) + seat);
            }
            Console.WriteLine($"Max SeatId: {seatIds.Max()}");

            // Part 2
            var mySeat = 0;
            for (int i = 0; i < seatIds.Count; i++)
            {
                if (!seatIds.Contains(seatIds[i] + 1) && seatIds.Contains(seatIds[i] + 2))
                {
                    mySeat = seatIds[i] + 1;
                }
            }
            Console.WriteLine($"My SeatId: {mySeat}");
        }

        private static int GetRange(int min, int max, string input)
        {
            var mid = (min + max) / 2;

            if (string.IsNullOrEmpty(input))
            {
            }
            else if (input[0] == 'F' || input[0] == 'L')
            {
                return GetRange(min, mid, input.Substring(1));
            }
            else if (input[0] == 'B' || input[0] == 'R' )
            {
                return GetRange(mid + 1, max, input.Substring(1));
            }

            return mid;
        }
    }
}
