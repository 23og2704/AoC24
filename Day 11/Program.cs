using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Security.Policy;

namespace Day_11
{
    internal class Program
    {
        static long part1()
        {
            string lines = File.ReadAllText("input.txt");

            string[] stones = lines.Split(' ');
            List<long> startStones = new List<long>();

            

            foreach (string s in stones)
            {
                startStones.Add(long.Parse(s)); 
            }
            for (int i = 0; i < 75; i++)
            {
                List<long> newStones = new List<long>();
                foreach (var s in startStones)
                {
                    newStones.AddRange(blink(s));
                }
                startStones = newStones;

            }



            return startStones.Count;
        }
        static List<long> blink(long stone)
        {
            List<long> newStones = new List<long>();

            if (stone == 0)
            {
                newStones.Add(1);
            } else
            {
                if (stone.ToString().Length % 2 == 0)
                {
                    string leftStone  = stone.ToString().Substring(0, stone.ToString().Length / 2);
                    string rightStone = stone.ToString().Substring((stone.ToString().Length / 2));

                    newStones.Add(long.Parse(leftStone)); 
                    newStones.Add(long.Parse(rightStone));
                }
                else
                {
                    newStones.Add(stone * 2024);
                }
            }
            return newStones;

        }
        static long part2()
        {
            string lines = File.ReadAllText("input.txt");
            string[] stones = lines.Split(' ');
            Dictionary<long, long> stoneCount = new Dictionary<long, long>();

            foreach (string s in stones)
            {
                if (stoneCount.ContainsKey(long.Parse(s)))
                    stoneCount[long.Parse(s)]++;
                else
                    stoneCount[long.Parse(s)] = 1;
            }

            for (int i = 0; i < 75; i++)
            {
                Dictionary<long, long> newStoneCount = new Dictionary<long, long>();

                foreach (var kvp in stoneCount)
                {
                    long stone = kvp.Key;
                    long count = kvp.Value;

                    if (stone == 0)
                    {
                        if (newStoneCount.ContainsKey(1))
                            newStoneCount[1] += count;
                        else
                            newStoneCount[1] = count;
                    }
                    else
                    {
                        string stoneStr = stone.ToString();
                        if (stoneStr.Length % 2 == 0)
                        {
                            string leftStoneStr = stoneStr.Substring(0, stoneStr.Length / 2);
                            string rightStoneStr = stoneStr.Substring(stoneStr.Length / 2);
                            long leftStone = long.Parse(leftStoneStr);
                            long rightStone = long.Parse(rightStoneStr);

                            if (newStoneCount.ContainsKey(leftStone))
                                newStoneCount[leftStone] += count;
                            else
                                newStoneCount[leftStone] = count;

                            if (newStoneCount.ContainsKey(rightStone))
                                newStoneCount[rightStone] += count;
                            else
                                newStoneCount[rightStone] = count;
                        }
                        else
                        {
                            long newStone = stone * 2024;
                            if (newStoneCount.ContainsKey(newStone))
                                newStoneCount[newStone] += count;
                            else
                                newStoneCount[newStone] = count;
                        }
                    }
                }
                stoneCount = newStoneCount;
            }
            return stoneCount.Values.Sum();
        }


        static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {part1()}");
            Console.WriteLine($"Part 2: {part2()}");
            Console.ReadKey();
        }
    }
}
