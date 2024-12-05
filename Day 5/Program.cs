using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_5
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            List<(int x, int y)> orderingRules = new List<(int, int)>();
            List<List<int>> updates = new List<List<int>>();
            int i = 0;

            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (line.Contains('|'))
                {
                    string[] parts = line.Split('|');
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    orderingRules.Add((x, y));
                }
                else
                {
                    break;
                }
            }

            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                string[] parts = line.Split(',');
                List<int> update = new List<int>();
                foreach (string part in parts)
                {
                    int pageNumber = int.Parse(part);
                    update.Add(pageNumber);
                }
                updates.Add(update);
            }

            foreach (var update in updates)
            {
                Dictionary<int, int> indexMap = new Dictionary<int, int>();
                for (int idx = 0; idx < update.Count; idx++)
                {
                    int pageNumber = update[idx];
                    indexMap[pageNumber] = idx;
                }
                bool correct = true;
                foreach ((int x, int y) in orderingRules)
                {
                    if (indexMap.ContainsKey(x) && indexMap.ContainsKey(y))
                    {
                        if (indexMap[x] >= indexMap[y])
                        {
                            correct = false;
                            break;
                        }
                    }
                }
                if (correct)
                {
                    int middleIndex = update.Count / 2;
                    int middlePageNumber = update[middleIndex];
                    answer += middlePageNumber;
                }
            }

            return answer;
        }


        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            List<(int x, int y)> orderingRules = new List<(int, int)>();
            List<List<int>> updates = new List<List<int>>();
            int i = 0;

            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (line.Contains('|'))
                {
                    string[] parts = line.Split('|');
                    int x = int.Parse(parts[0]);
                    int y = int.Parse(parts[1]);
                    orderingRules.Add((x, y));
                }
                else if (line.Contains(','))
                {
                    break;
                }
            }

            for (; i < lines.Length; i++)
            {
                string line = lines[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                if (!line.Contains(','))
                {
                    continue; 
                }
                string[] parts = line.Split(',');
                List<int> update = new List<int>();
                foreach (string part in parts)
                {
                    int pageNumber = int.Parse(part);
                    update.Add(pageNumber);
                }
                updates.Add(update);
            }

            foreach (var update in updates)
            {
                Dictionary<int, int> indexMap = new Dictionary<int, int>();
                for (int j = 0; j < update.Count; j++)
                {
                    int pageNumber = update[j];
                    indexMap[pageNumber] = j;
                }
                bool correct = true;
                foreach ((int x, int y) in orderingRules)
                {
                    if (indexMap.ContainsKey(x) && indexMap.ContainsKey(y))
                    {
                        if (indexMap[x] >= indexMap[y])
                        {
                            correct = false;
                            break;
                        }
                    }
                }

                if (!correct)
                {
                    bool changed = true;
                    while (changed)
                    {
                        changed = false;
                        for (int j = 0; j < update.Count - 1; j++)
                        {
                            int x = update[j];
                            int y = update[j + 1];
                            bool yBeforeX = false;
                            for (int t = 0; t < orderingRules.Count; t++)
                            {
                                if (orderingRules[t].x == y && orderingRules[t].y == x) 
                                { 
                                    yBeforeX = true; break; 
                                }

                            }
                            if (yBeforeX)
                            {
                                update[j] = y;
                                update[j + 1] = x;
                                changed = true;
                            }
                        }
                    }

                    int middleIndex = update.Count / 2;
                    int middlePageNumber = update[middleIndex];
                    answer += middlePageNumber;
                }
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

