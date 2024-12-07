using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_7
{
    internal class Program
    {
        static long part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            long answer = 0;

            foreach (string s in lines)
            {
                var tSplit = s.Split(':');
                long target = long.Parse(tSplit[0].Trim());
                var numSplit = tSplit[1].Trim().Split(' ');

                List<long> numbers = new List<long>();

                foreach (var num in numSplit)
                {
                    numbers.Add(long.Parse(num));
                }

                if (search(numbers, target, 0, numbers[0]))
                {
                    answer += target;
                }
            }
            return answer;
        }
        static bool search(List<long> numbers, long target, int index, long value)
        {
            if (index == numbers.Count - 1)
            {
                if (value == target)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            if (search(numbers, target, index + 1, value + numbers[index + 1]))
            {
                return true;
            }
            if (search(numbers, target, index + 1, value * numbers[index + 1]))
            {
                return true;
            }
            string c = value + numbers[index + 1].ToString();
            if (search(numbers, target, index + 1, long.Parse(c)))
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Day 1: {part1()}");
            Console.ReadKey();
        }
    }
}
