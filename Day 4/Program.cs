using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;

namespace Day_4
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            string word = "XMAS";
            int wordLength = word.Length;
            int rows = lines.Length;
            int cols = lines[0].Length;
            int[] x = { 1, -1, 0, 0, 1, -1, 1, -1 };
            int[ ]y = { 0, 0, 1, -1, 1, 1, -1, -1 };

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    for (int k = 0; k < 8; k++)
                    {
                        int tempI = i;
                        int tempJ = j;
                        int l;
                        for (l = 0; l < wordLength; l++)
                        {
                            if (tempI < 0 || tempI >= rows || tempJ < 0 || tempJ >= cols)
                            {
                                break;
                            }
                            if (lines[tempI][tempJ] != word[l])
                            {
                                break;
                            }
                            tempI += x[k];
                            tempJ += y[k];
                        }
                        if (l == wordLength)
                        {
                            answer++;
                        }
                    }
                }
            }


            return answer;
        }

        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;
            int rows = lines.Length;
            int cols = lines[0].Length;

            for (int i = 1; i < rows - 1; i++)
            {
                for (int j = 1; j < cols - 1; j++)
                {
                    if (lines[i][j] != 'A')
                        continue;
                    bool valid1 = false;
                    bool valid2 = false;

                    char nw = lines[i - 1][j - 1];
                    char se = lines[i + 1][j + 1];
                    if ((nw == 'M' && se == 'S') || (nw == 'S' && se == 'M'))
                    {
                        valid1 = true;
                    }

                    char ne = lines[i - 1][j + 1];
                    char sw = lines[i + 1][j - 1];
                    if ((ne == 'M' && sw == 'S') || (ne == 'S' && sw == 'M'))
                    {
                        valid2 = true;
                    }

                    if (valid1 && valid2)
                    {
                        answer++;
                    }
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
