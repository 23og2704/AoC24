using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day_8
{
    internal class Program
    {
        struct Antenna
        {
            public char Frequency;
            public int X;
            public int Y;
        }
        static int part1()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int height = lines.Length;
            int width = lines.Max(line => line.Length);
            List<Antenna> antennas = new List<Antenna>();

            for (int i = 0; i < height; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char freq = line[j];
                    if (freq != '.')
                    {
                        antennas.Add(new Antenna { Frequency = freq, X = j, Y = i });
                    }
                }
            }

            HashSet<(int x, int y)> antinodes = new HashSet<(int x, int y)>();

            for (int i = 0; i < antennas.Count - 1; i++)
            {
                for (int j = i + 1; j < antennas.Count; j++)
                {
                    Antenna antA = antennas[i];
                    Antenna antB = antennas[j];

                    if (antA.Frequency == antB.Frequency)
                    {
                        int node1x = 2 * antB.X - antA.X;
                        int node1y = 2 * antB.Y - antA.Y;
                        int node2x = 2 * antA.X - antB.X;
                        int node2y = 2 * antA.Y - antB.Y;

                        if (node1x >= 0 && node1x < width && node1y >= 0 && node1y < height)
                        {
                            antinodes.Add((node1x, node1y));
                        }
                        if (node2x >= 0 && node2x < width && node2y >= 0 && node2y < height)
                        {
                            antinodes.Add((node2x, node2y));
                        }
                    }
                }
            }
            return antinodes.Count;
        }

        static int part2()
        {
            string[] lines = File.ReadAllLines("input.txt");
            int height = lines.Length;
            int width = lines.Max(line => line.Length);
            List<Antenna> antennas = new List<Antenna>();

            for (int i = 0; i < height; i++)
            {
                string line = lines[i];
                for (int j = 0; j < line.Length; j++)
                {
                    char freq = line[j];
                    if (freq != '.')
                    {
                        antennas.Add(new Antenna { Frequency = freq, X = j, Y = i });
                    }
                }
            }

            Dictionary<char, List<Antenna>> freqGroups = new Dictionary<char, List<Antenna>>();
            for (int i = 0; i < antennas.Count; i++)
            {
                char freq = antennas[i].Frequency;
                if (!freqGroups.ContainsKey(freq))
                {
                    freqGroups[freq] = new List<Antenna>();
                }
                freqGroups[freq].Add(antennas[i]);
            }

            List<KeyValuePair<char, List<Antenna>>> validFreqGroups = new List<KeyValuePair<char, List<Antenna>>>();
            foreach (KeyValuePair<char, List<Antenna>> pair in freqGroups)
            {
                if (pair.Value.Count >= 2)
                {
                    validFreqGroups.Add(pair);
                }
            }
            HashSet<(int x, int y)> antinodes = new HashSet<(int x, int y)>();

            return antinodes.Count;
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {part1()}");
            Console.WriteLine($"Part 2: {part2()}");
            Console.ReadKey();
        }
    }
}
