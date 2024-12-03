using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day_3
{
    internal class Program
    {
        static int day3()
        {
            string text = File.ReadAllText("input.txt");
            int answer = 0;
            string regEx = @"(?<do>do\(\))|(?<dont>don't\(\))|mul\((?<x>\d{1,3}),(?<y>\d{1,3})\)";

            bool enabled = true;
            var matches = Regex.Matches(text, regEx);

            foreach (Match m in matches)
            {
                if (m.Groups["do"].Success)
                {
                    enabled = true;
                }
                else if (m.Groups["dont"].Success)
                {
                    enabled = false;
                }
                if (m.Groups["x"].Success && m.Groups["y"].Success && enabled)
                {
                    int x = int.Parse(m.Groups["x"].Value);
                    int y = int.Parse(m.Groups["y"].Value);
                    answer += x * y;

                }
            }
            return answer;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Day 3: {day3()}");
            Console.ReadKey();
        }
    }
}
