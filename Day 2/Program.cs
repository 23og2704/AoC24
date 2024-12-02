using System;
using System.IO;

namespace Day_2
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;

            foreach (string line in lines)
            {
                string[] tokens = line.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int[] levels = Array.ConvertAll(tokens, int.Parse);

                bool safe = false;

                bool currentSafe = true;

                if (levels.Length < 2)
                {
                    currentSafe = false;
                }
                else
                {
                    int diff = 0;
                    int i = 1;

                    while (i < levels.Length)
                    {
                        diff = levels[i] - levels[i - 1];
                        if (diff == 0 || Math.Abs(diff) > 3)
                        {
                            currentSafe = false;
                            break;
                        }
                        else
                        {
                            break;
                        }
                        i++;
                    }

                    if (i == levels.Length)
                    {
                        currentSafe = false;
                    }
                    else if (currentSafe)
                    {
                        bool increasing = diff > 0;
                        bool decreasing = diff < 0;

                        for (; i < levels.Length; i++)
                        {
                            diff = levels[i] - levels[i - 1];

                            if (diff == 0 || Math.Abs(diff) > 3)
                            {
                                currentSafe = false;
                                break;
                            }

                            if (increasing && diff <= 0)
                            {
                                currentSafe = false;
                                break;
                            }

                            if (decreasing && diff >= 0)
                            {
                                currentSafe = false;
                                break;
                            }
                        }
                    }
                }

                if (currentSafe)
                {
                    safe = true;
                }
                else
                {

                    for (int removeIndex = 0; removeIndex < levels.Length; removeIndex++)
                    {
                        int[] newLevels = new int[levels.Length - 1];
                        int index = 0;
                        for (int j = 0; j < levels.Length; j++)
                        {
                            if (j != removeIndex)
                            {
                                newLevels[index++] = levels[j];
                            }
                        }

                        bool newSafe = true;
                        if (newLevels.Length < 2)
                        {
                            newSafe = false;
                        }
                        else
                        {
                            int diff = 0;
                            int i = 1;

                            while (i < newLevels.Length)
                            {
                                diff = newLevels[i] - newLevels[i - 1];
                                if (diff == 0 || Math.Abs(diff) > 3)
                                {
                                    newSafe = false;
                                    break;
                                }
                                else
                                {
                                    break;
                                }
                                i++;
                            }

                            if (i == newLevels.Length)
                            {
                                newSafe = false;
                            }
                            else if (newSafe)
                            {
                                bool increasing = diff > 0;
                                bool decreasing = diff < 0;

                                for (; i < newLevels.Length; i++)
                                {
                                    diff = newLevels[i] - newLevels[i - 1];

                                    if (diff == 0 || Math.Abs(diff) > 3)
                                    {
                                        newSafe = false;
                                        break;
                                    }

                                    if (increasing && diff <= 0)
                                    {
                                        newSafe = false;
                                        break;
                                    }

                                    if (decreasing && diff >= 0)
                                    {
                                        newSafe = false;
                                        break;
                                    }
                                }
                            }
                        }

                        if (newSafe)
                        {
                            safe = true;
                            break;
                        }
                    }
                }

                if (safe)
                {
                    answer++;
                }
            }
            return answer;
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Day 1: {part1()}");
            Console.ReadKey();
        }
    }
}
