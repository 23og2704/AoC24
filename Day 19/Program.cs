using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Day_19
{
    internal class Program
    {
        static List<string> patterns = new List<string>();
        static List<string> designs = new List<string>();
        static Dictionary<string, bool> cache = new Dictionary<string, bool>();
        static Dictionary<string, long> cache2 = new Dictionary<string, long>();
        static int maxLength;
        static long count2;

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
            if(cache.ContainsKey(design)) return cache[design];

            for (int i = 1; i < Math.Min(design.Length, maxLength)+1; i++)
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
            if (design == "")
            {
                return 0;
            }
            if (cache2.ContainsKey(design)) return cache2[design];

            count2 = 0;
            for (int i = 1; i < Math.Min(design.Length, maxLength) + 1; i++)
            {
                if (patterns.Contains(design.Substring(0, i)))
                {
                    count2 += checkValid2(design.Substring(i));
                }
            }
            cache2.Add(design, count2);
            return count2;
        }
        static long part1()
        {
            long count = 0;
            foreach (string design in designs)
            {
                if (checkValid(design))
                {
                    count += count2;
                    
                }
            }
            return count;
        }

        static long part2()
        {
            long count = 0;
            foreach (string design in designs)
            {

                if (checkValid(design))
                {
                    count += count2;
                }
            }
            return count;
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