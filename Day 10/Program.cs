using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_10
{
    internal class Program
    {
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int answer = 0;

            int rows = lines.Length;
            int cols = lines[0].Length;

            int[,] map = new int[rows, cols];  

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i,j] = lines[i][j] - '0';
                }
            }

            List<(int row, int col)> trailheads = new List<(int row, int col)>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (map[i,j] == 0)
                    {
                        trailheads.Add((i, j));
                    }
                }
            }

            HashSet<(int row, int col)> nines = new HashSet<(int row, int col)>();
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols ; j++)
                {
                    if (map[i, j] == 9)
                    {
                        nines.Add((i, j));
                    }
                }
            }

            foreach (var trailhead in trailheads)
            {
                HashSet<(int row, int col)> reachableNines = new HashSet<(int, int)>();
                HashSet<(int row, int col)> visited = new HashSet<(int, int)>();
                int rnine = search(trailhead.row, trailhead.col, map, rows, cols, visited, reachableNines);
                answer += rnine;
            }


            return answer;
        }
        static int search(int i, int j, int[,] map, int rows, int cols, HashSet<(int row, int col)> visited, HashSet<(int row, int col)> reachableNines)
        {
            int[] rowSearch = { -1, 1, 0, 0 };
            int[] columnSearch = {0, 0, -1, 1 };
            int count = 0;
            visited.Add((i, j));

            if (map[i, j] == 9)
            {
                return 1;
            }

            for (int k = 0; k < 4 ; k++)
            {
                int temp1 = i + rowSearch[k];
                int temp2 = j + columnSearch[k];

                if (temp1 >= 0 && temp1 < rows && temp2 >= 0 && temp2 < cols)
                {
                    if (map[temp1, temp2] == map[i, j] + 1)
                    {
                        count += search(temp1, temp2, map, rows, cols, visited, reachableNines);
                    }
                }


            }
            visited.Remove((i, j));
            return count;
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
