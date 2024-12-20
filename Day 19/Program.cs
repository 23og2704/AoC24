using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_19
{
    internal class Program
    {
        static List<string> patterns = new List<string>();
        static List<string> designs = new List<string>();
        static Dictionary<string, bool> cache = new Dictionary<string, bool>();
        static Dictionary<string, long> cache2 = new Dictionary<string, long>();
        static int maxLength;

        static void load()
        {
            string input = File.ReadAllText("patterns.txt");
            foreach (string s in input.Split(','))
            {
                patterns.Add(s.Trim());
            }
            designs = File.ReadAllLines("designs.txt").ToList();
            maxLength = designs.Select(x => x.Length).Max();
        }
        static bool checkValid(string design)
        {
            if (design == "")
            {
                return true;
            }
            if (cache.ContainsKey(design)) return cache[design];



            for (int i = 1; i < Math.Min(design.Length, maxLength) + 1; i++)
            {
                if (patterns.Contains(design.Substring(0, i)) && checkValid(design.Substring(i)))
                {
                    cache.Add(design, true);
                    return true;
                }
            }
            cache.Add(design, false);
            return false;
        }
        static long checkValid2(string design)
        {
            long temp = 0;
            int i = 0;

            if (design == "")
            {
                return 1;
            }
            if (cache2.ContainsKey(design))
            {
                return cache2[design];
            }
            foreach (string s in patterns.SkipWhile(x => x.Length > design.Length - i))
            {
                if (design.StartsWith(s))
                {
                    i++;
                    temp += checkValid2(design.Substring(s.Length));
                }
            }

            //for (int i = 1; i < Math.Min(design.Length, maxLength) + 1; i++)
            //{
            //    if (patterns.Contains(design.Substring(0, i)))
            //    {
            //        temp += checkValid2(design.Substring(i));
            //    }
            //}

            cache2.Add(design, temp);
            return temp;
        }
        static long part1()
        {
            //long count = 0;
            //foreach (string design in designs)
            //{
            //    if (checkValid(design))
            //    {
            //        count += count2;

            //    }
            //}
            //count2 = 0;
            //return count;
            return 1;
        }

        static long part2()
        {
            long i = 0;
            foreach (string design in designs)
            {
                i += checkValid2(design);
            }
            return i;
        }
        static void Main(string[] args)
        {
            load();
            Console.WriteLine($"Part 1: {part1()}");
            Console.WriteLine($"Part 2: {part2()}");
            Console.ReadKey();
        }
    }
}