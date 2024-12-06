using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_6
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int direction = 0;
            bool found = false;
            int startRow = 0;
            int startCol = 0;

            for (int i = 0; i < lines.Length && !found; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    if (line[j] == '^' || line[j] == 'v' || line[j] == '<' || line[j] == '>')
                    {
                        startRow = i;
                        startCol = j;
                        if (line[j] == '^')
                        {
                            direction = 0;
                        }
                        if (line[j] == '>')
                        {
                            direction = 1;
                        }
                        if (line[j] == 'v') 
                        { 
                            direction = 2; 
                        }
                        if (line[j] == '<')
                        {
                            direction = 3;
                        }
                        found = true;
                        break;
                    }
                }
            }
            int[] directionRow = { -1, 0, 1, 0 };
            int[] directionCol = { 0, 1, 0, -1 };
            HashSet<(int, int)> visited = new HashSet<(int, int)>();
            visited.Add((startRow, startCol));
            int currentRow = startRow;
            int currentCol = startCol;

            while (true)
            {
                int nextRow = currentRow + directionRow[direction];
                int nextCol = currentCol + directionCol[direction];

                if (nextRow < 0 || nextRow >= lines.Length || nextCol < 0 || nextCol >= lines[nextRow].Length)
                {
                    break;
                }
                if (lines[nextRow][nextCol] == '#')
                {
                    direction = (direction + 1) % 4;
                }
                else
                {
                    currentRow = nextRow;
                    currentCol = nextCol;
                    visited.Add((currentRow, currentCol));
                }
            }
            return visited.Count;
        }

        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int height = lines.Length;
            int width = lines[0].Length;
            HashSet<(int, int)> obstacles = new HashSet<(int, int)>();
            int startRow = 0;
            int startCol = 0;
            int direction = 0;
            bool found = false;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (lines[i][j] == '#')
                    {
                        obstacles.Add((i, j));
                    }
                    else if (lines[i][j] == '^' || lines[i][j] == 'v' || lines[i][j] == '<' || lines[i][j] == '>')
                    {
                        startRow = i;
                        startCol = j;
                        if (lines[i][j] == '^')
                        {
                            direction = 0;
                        }
                        if (lines[i][j] == '>') 
                        {
                            direction = 1; 
                        }

                        if (lines[i][j] == 'v')
                        { 
                            direction = 2; 
                        }
                        if (lines[i][j] == '<')
                        {
                            direction = 3;
                        }
                        found = true;
                    }
                }
            }

            int[] directionRow = { -1, 0, 1, 0 };
            int[] directionCol = { 0, 1, 0, -1 };
            int answer = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if ((i != startRow || j != startCol) && lines[i][j] == '.')
                    {
                        obstacles.Add((i, j));
                        int currentRow = startRow;
                        int currentCol = startCol;
                        int dir = direction;
                        HashSet<(int, int, int)> states = new HashSet<(int, int, int)>();
                        bool loop = false;

                        while (true)
                        {
                            var state = (currentRow, currentCol, dir);
                            if (!states.Add(state))
                            {
                                loop = true;
                                break;
                            }

                            int newRow = currentRow + directionRow[dir];
                            int newCol = currentCol + directionCol[dir];

                            if (newRow < 0 || newRow >= height || newCol < 0 || newCol >= width)
                            {
                                break;
                            }

                            if (obstacles.Contains((newRow, newCol)))
                            {
                                dir = (dir + 1) % 4;
                            }
                            else
                            {
                                currentRow = newRow;
                                currentCol = newCol;
                            }
                        }
                        if (loop)
                        {
                            answer++;
                        }
                        obstacles.Remove((i, j));
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
