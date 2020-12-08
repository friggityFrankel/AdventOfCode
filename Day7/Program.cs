using System;
using System.Collections.Generic;
using System.Linq;

namespace Day7
{
    class Program
    {
        static List<Bag> bags;

        static void Main(string[] args)
        {
            var file = @"C:\Users\nukem\source\repos\AdventOfCode\Day7\input.txt";
            var input = System.IO.File.ReadAllLines(file);

            CountGoldBags(input);

        }

        private static void CountGoldBags(string[] input)
        {
            CreateList(input);
            
            // some recursive shit here
            
            Console.WriteLine($"Total Bags: {bags.Count}");
        }

        private static void CreateList(string[] input)
        {
            bags = new List<Bag>();

            foreach (var item in input)
            {
                var info = item.Replace("bags", "bag").Replace(".", "").Replace("\r", "").Split(" contain ");

                var bag = GetBag(info[0]);
                
                if (info.Length > 1)
                {
                    var bagsInside = info[1].Split(", ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var bagInside in bagsInside)
                    {
                        int count = 0;
                        int.TryParse(bagInside[0].ToString(), out count);
                        var bagName = GetBag(bagInside.Substring(2));
                        bag.Holds.Add(bagName, count);
                    }
                }
            }
        }

        private static Bag GetBag(string name)
        {
            if (!bags.Any(b => b.Name == name))
            {
                bags.Add(new Bag(name));
            }
            return bags.Single(b => b.Name == name);
        }

        public class Bag
        {
            public string Name { get; set; }
            public Dictionary<Bag, int> Holds { get; set; }

            public Bag(string name)
            {
                Name = name;
                Holds = new Dictionary<Bag, int>();
            }
        }
    }
}
