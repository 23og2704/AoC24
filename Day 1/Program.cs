using System;
using System.Collections.Generic;
using System.IO;

namespace Day_1
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            foreach (string line in lines)
            {
                list1.Add(int.Parse(line.Substring(0, 5)));
                list2.Add(int.Parse(line.Substring(8, 5)));

            }
            list1.Sort();
            list2.Sort();

            for (int i = 0; i < list1.Count; i++)
            {
                int difference = Math.Abs(list1[i] - list2[i]);
                answer += difference;
            }

            return answer;
            
        }
        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();
            Dictionary<int, int> counts = new Dictionary<int, int>();
            foreach (string line in lines)
            {
                list1.Add(int.Parse(line.Substring(0, 5)));
                list2.Add(int.Parse(line.Substring(8, 5)));

            }
            foreach (int i in list2)
            {
                if (counts.ContainsKey(i))
                {
                    counts[i]++;
                } else
                {
                    counts[i] = 1;
                }
            }
            foreach (int i in list1)
            {
                int temp = 0;
                if (counts.ContainsKey((int)i))       
                {
                    temp += counts[i];
                }
                answer += i * temp;
            }
            return answer;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {part1()}");
            Console.WriteLine($"Part 2: {part2()}");
            Console.ReadKey();
        }
    }
}
