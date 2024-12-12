using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Day_12
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;

            char[,] grid = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    grid[i, j] = lines[i][j];
                }
            }

            bool[,] visited = new bool[lines.Length, lines[0].Length];

            int[] rowDirection = { -1, 1, 0, 0 };
            int[] colDirection = { 0, 0, -1, 1 };

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    if (!visited[i, j])
                    {
                        char plantType = grid[i, j];
                        List<(int, int)> plots = new List<(int, int)>();
                        Queue<(int, int)> queue = new Queue<(int, int)> ();
                        queue.Enqueue((i, j));
                        visited[i, j] = true;

                        while (queue.Count > 0)
                        {
                            var (r, c) = queue.Dequeue();
                            plots.Add((r, c));

                            for (int k = 0; k < 4; k++)
                            {
                                int tempRow = r + rowDirection[k];
                                int tempCol = c + colDirection[k];
                                if (tempRow >= 0 && tempRow < lines.Length && tempCol >= 0 && tempCol < lines[0].Length)
                                {
                                    if (!visited[tempRow, tempCol] && grid[tempRow, tempCol] == plantType)
                                    {
                                        visited[tempRow, tempCol] = true;
                                        queue.Enqueue((tempRow, tempCol));
                                }
                                }
                            }

                        }
                        int area = plots.Count;
                        int perimeter = 0;

                        foreach (var (row, col) in plots)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                int tempRow = row + rowDirection[k];
                                int tempCol = col + colDirection[k];

                                if (tempRow < 0 || tempRow >= lines.Length || tempCol < 0 || tempCol >= lines[i].Length)
                                {
                                    perimeter++;
                                }
                                else
                                {
                                    if (grid[tempRow, tempCol] != grid[row, col])
                                    {
                                        perimeter++;
                                    }
                                }
                            }
                        }
                        answer += area * perimeter;

                    }
                }
            }
            return answer;
        }

        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;


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
