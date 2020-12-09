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
            var bagCount = CountAllBagsInside(bags.Single(b => b.Name == "shiny gold bag"));
            Console.WriteLine($"Total Bags: {bagCount}");
        }

        private static void CountGoldBags(string[] input)
        {
            CreateList(input);

            var bagsWithGold = new List<Bag>();
            // some recursive shit here
            foreach (var item in bags)
            {
                if (CountGoldBagsInside(item) > 0)
                {
                    bagsWithGold.Add(item);
                }
            }
            
            Console.WriteLine($"Total Bags: {bagsWithGold.Count}");
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

        private static int CountGoldBagsInside(Bag bag)
        {
            int count = 0;
            foreach (var bagInside in bag.Holds)
            {
                if (bagInside.Key.Name == "shiny gold bag")
                {
                    count += bagInside.Value;
                }
                else
                {
                    count += CountGoldBagsInside(bagInside.Key);
                }
            }
            return count;
        }

        private static int CountAllBagsInside(Bag bag)
        {
            int count = 0;
            foreach (var bagInside in bag.Holds)
            {
                count += bagInside.Value;
                if (bagInside.Key.Holds.Count > 0)
                {
                    count += (CountAllBagsInside(bagInside.Key) * bagInside.Value);
                }
            }
            return count;
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
