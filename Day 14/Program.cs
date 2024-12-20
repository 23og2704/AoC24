using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program
{
    static int part1()
    {
        string[] lines = File.ReadAllLines("input.txt");

        List<int> x = new List<int>();
        List<int> y = new List<int>();
        List<int> rx = new List<int>();
        List<int> ry = new List<int>();

        foreach (string line in lines)
        {
            var parts = line.Split(' ');
            var pPart = parts[0].Substring(2);
            var vPart = parts[1].Substring(2);

            var pCoords = pPart.Split(',').Select(int.Parse).ToArray();
            var vCoords = vPart.Split(',').Select(int.Parse).ToArray();

            x.Add(pCoords[0]);
            y.Add(pCoords[1]);
            rx.Add(vCoords[0]);
            ry.Add(vCoords[1]);
        }

        int width = 101;
        int height = 103;
        int robotCount = x.Count;

        for (int t = 0; t < 100; t++)
        {
            for (int i = 0; i < robotCount; i++)
            {
                int newX = (x[i] + rx[i]) % width;
                if (newX < 0) newX += width;
                x[i] = newX;

                int newY = (x[i] + rx[i]) % height;
                if (newY < 0) newY += height;
                y[i] = newY;
            }
        }

        int midX = 50;
        int midY = 51;

        int countQ1 = 0;
        int countQ2 = 0;
        int countQ3 = 0;
        int countQ4 = 0;

        for (int i = 0; i < robotCount; i++)
        {
            if (x[i] == midX || y[i] == midY)
            {
                continue;
            }

            bool left = x[i] < midX;
            bool top = y[i] < midY;

            if (top && left)
            {
                countQ1++;
            }
            else if (top && !left)
            {
                countQ2++;
            }
            else if (!top && left)
            {
                countQ3++;
            }
            else if (!top && !left)
            {
                countQ4++;
            }
        }
        return countQ1 * countQ2 * countQ3 * countQ4;
    }

    static int part2()
    {
        return -1;
    }
    static void Main()
    {
        Console.WriteLine($"Part 1: {part1()}");
        Console.WriteLine($"Part 2: {part2()}");
        Console.ReadKey();

    }
}
