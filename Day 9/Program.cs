using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_9
{
    internal class Program
    {
        static long part1()
        {
            string input = File.ReadAllText("input.txt");
            List<int> disk = new List<int>();
            bool isFile = true; 
            int currentID = 0;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    continue;
                }
                int length = int.Parse(c.ToString());
                if (isFile)
                {
                    for (int i = 0; i < length; i++)
                    {
                        disk.Add(currentID);
                    }
                    currentID++;
                }
                else
                {
                    for (int i = 0; i < length; i++)
                    {
                        disk.Add(-1);
                    }
                }
                isFile = !isFile;
            }

            while (true)
            {
                int freeIndex = disk.IndexOf(-1);
                if (freeIndex == -1)
                {
                    break;
                }

                int fileIndex = -1;
                int fileID = -1;
                for (int i = disk.Count - 1; i > freeIndex; i--)
                {
                    if (disk[i] != -1)
                    {
                        fileIndex = i;
                        fileID = disk[i];
                        break;
                    }
                }

                if (fileIndex == -1)
                {
                    break;
                }
                disk[freeIndex] = fileID;
                disk[fileIndex] = -1;
            }

            long checksum = 0;
            for (int pos = 0; pos < disk.Count; pos++)
            {
                if (disk[pos] != -1)
                {
                    checksum += (long)pos * disk[pos];
                }
            }
            return checksum;
        }
        static long part2()
        {
            string input = File.ReadAllText("input.txt");
            List<int> disk = new List<int>();
            bool isFile = true;
            int currentID = 0;

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    continue;
                }
                int length = int.Parse(c.ToString());
                if (isFile)
                {
                    for (int i = 0; i < length; i++)
                    {
                        disk.Add(currentID);
                    }
                    currentID++;
                }
                else
                {
                    for (int i = 0; i < length; i++)
                    {
                        disk.Add(-1);
                    }
                }
                isFile = !isFile;
            }

            List<int> fileIDs = new List<int>();
            List<int> fileStart = new List<int>();
            List<int> fileLength = new List<int>();

            int position = 0;
            while (position < disk.Count)
            {
                if (disk[position] != -1)
                {
                    int fileID = disk[position];
                    int start = position;
                    int length = 0;
                    while (position < disk.Count && disk[position] == fileID)
                    {
                        length++;
                        position++;
                    }
                    fileIDs.Add(fileID);
                    fileStart.Add(start);
                    fileLength.Add(length);
                }
                else
                {
                    position++;
                }
            }

            List<int> sortedIndices = new List<int>();
            for (int i = 0; i < fileIDs.Count; i++)
            {
                sortedIndices.Add(i);
            }
            sortedIndices.Sort((i1, i2) => fileIDs[i2].CompareTo(fileIDs[i1]));

            foreach (int index in sortedIndices)
            {
                int fileID = fileIDs[index];
                int currentStart = fileStart[index];
                int length = fileLength[index];

                int targetStart = -1;
                for (int i = 0; i <= disk.Count - length; i++)
                {
                    bool fit = true;
                    for (int j = 0; j < length; j++)
                    {
                        if (disk[i + j] != -1)
                        {
                            fit = false;
                            break;
                        }
                    }
                    if (fit)
                    {
                        targetStart = i;
                        break;
                    }
                }

                if (targetStart != -1 && targetStart != currentStart)
                {
                    for (int j = 0; j < length; j++)
                    {
                        disk[targetStart + j] = fileID;
                        disk[currentStart + j] = -1;
                    }
                    fileStart[index] = targetStart;
                }
            }

            long checksum = 0;
            for (int p = 0; p < disk.Count; p++)
            {
                if (disk[p] != -1)
                {
                    checksum += p * disk[p];
                }
            }
            return checksum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {part1()}");
            Console.WriteLine($"Part 2: {part2()}");
            Console.ReadKey();
        }
    }
}
