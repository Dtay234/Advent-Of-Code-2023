using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            long count = 0;
            List<string> solutions = new List<string>();


            for (int i = 0; i < lines.Length; i++)
            {
                string[] line = lines[i].Split(' ');


                string firstPart = line[0];
                string secondPart = line[1];

                string newLine = "";

                for (int j = 0; j < 5; j++)
                {
                    newLine += firstPart;
                    if (i != 4)
                    {
                        newLine += "?";
                    }
                }

                newLine += " ";

                for (int j = 0; j < 5; j++)
                {
                    newLine += secondPart;
                    if (i != 4)
                    {
                        newLine += ",";
                    }
                }

                count += GetCombinations(newLine);
            }

            Console.WriteLine("Number of different arrangements of springs: " + count);
        }


        public static bool Matches(Tuple<string, int[]> input)
        {
            string line = input.Item1;
            int[] groups = input.Item2;


            bool matches = true;

            string[] strings = Regex.Split(line, @"[ .\d,]")
                .Where(line => !string.IsNullOrEmpty(line))
                .ToArray();


            for (int i = 0; i < Math.Min(groups.Length, strings.Length); i++)
            {
                if (groups[i] != strings[i].Length)
                {
                    matches = false;
                    break;
                }
            }

            if (groups.Length != strings.Length)
            {
                matches = false;
            }



            return matches;
        }

        public static long GetCombinations(string input)
        {
            string line = "";
            line += input;
            int unknown = Regex.Matches(input, @"[?]").Count();
            int[] unknownIndices = new int[unknown];
            int counter = 0;
            long combinations = (long)Math.Pow(2, unknown);

            string[] groups = Regex.Split(input, @"[.#, ?]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray()
                    ;
            int[] brokenSprings = Array.ConvertAll(groups, s => int.Parse(s));

            string springs = Regex.Split(input, @"[,\d ]")
                .Where(s => !string.IsNullOrEmpty(s))
                .ToArray()[0];

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '?')
                {
                    unknownIndices[counter] = i;
                    counter++;
                }
            }

            line = line.Replace('?', '.');

            long count = 0;


            for (int i = 0; i < combinations; i++)
            {
                for (int j = 0; j < unknown; j++)
                {
                    if (((i + 1) % ((int)(Math.Pow(2, j))) == 0))
                    {
                        line = Change(line, (unknownIndices[j]));
                    }
                }

                Tuple<string, int[]> tuple = new Tuple<string, int[]>(line, brokenSprings);
                if (Matches(tuple))
                {
                    count++;
                }

            }

            return count;
        }

        public static string Change(string input, int index)
        {
            if (input[index] == '.')
            {
                return input.Substring(0, index) + "#" + input.Substring(index + 1);
            }
            else if (input[index] == '#')
            {
                return input.Substring(0, index) + "." + input.Substring(index + 1);
            }
            else
            {
                return input.Substring(0, index) + "." + input.Substring(index + 1);
            }
        }
    }
}