using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int total = 0;
            List<string[]> duplicates = new List<string[]>();
            int offset = 0;

            for (int z = 0; z < 1000000000; z++)
            {
                lines = CycleMemo(lines);

                /*
                Console.Clear();

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        Console.Write(lines[i][j] + " ");
                    }

                    Console.WriteLine();
                }
                
                Console.WriteLine(z);
                */

                if (duplicates.Exists
                   (x => Enumerable.SequenceEqual(lines, x)))
                {
                    int index = duplicates.FindIndex(x => Enumerable.SequenceEqual(lines, x));
                    duplicates.RemoveRange(0, index);
                    offset = index + 1;

                    break;

                }
                else
                {
                    string[] thing = new string[lines.Length];
                    lines.CopyTo(thing, 0);

                    duplicates.Add(thing);
                }

                

            }

            int test = (1000000000 - offset) % (duplicates.Count);

            lines = duplicates[test];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'O')
                    {
                        total += (lines.Length - i);
                    }
                }
            }

            Console.WriteLine(total);
        }

        //Incorrect: 93154 (high) 

        public static Func<string[], string[]> TempFunc =
            x => TiltPlatform(x);

        public static Func<string[], string[]> TiltPlatformMemo =
            TempFunc.Memoize();

        public static string[] TiltPlatform(string[] newLines) 
        {

            for (int i = 0; i < newLines.Length; i++)
            {
                string[] matches = Regex.Matches(newLines[i], @"[.O]+[O]{1}")
                  .OfType<Match>()
                  .Select(m => m.Groups[0].Value)
                  .ToArray();

                foreach (string s in matches)
                {
                    Regex rx = new Regex(string.Join("\\.", s.Split('.')));
                    string sortedString = string.Join("", s.ToCharArray().ToList().OrderByDescending(x => x).ToArray());
                    newLines[i] = rx.Replace(newLines[i], sortedString, 1);
                }
            }

            return newLines;
        }

        public static Func<string, string> TempFunc1 =
            x => ReverseStringNotMemo(x);

        public static Func<string, string> ReverseString =
            TempFunc1.Memoize();

        public static string ReverseStringNotMemo(string line)
        {
            List<char> temp = line.ToList();
            temp.Reverse();
            return new string(temp.ToArray());
        }

        public static Func<string[], string[]> TempFunc4 =
            x => SwitchOrientation(x);

        public static Func<string[], string[]> SwitchOrientationMemo =
            TempFunc4.Memoize();

        public static string[] SwitchOrientation(string[] array)
        {
            int height = array.Length;
            int length = array[0].Length;
            string[] newArray = new string[length];

            for (int i = 0; i < length; i++)
            {
                string newLine = "";

                for (int j = 0; j < height; j++)
                {
                    newLine += array[j][i];
                }

                newArray[i] = newLine;
            }

            return newArray;
        }
       
        public static Func<string[], string[]> TempFunc2 =
            x => ReverseArrayNotMemo(x);

        public static Func<string[], string[]> ReverseArray =
            TempFunc2.Memoize();

        public static string[] ReverseArrayNotMemo(string[] array)
        {
            string[] newArray = new string[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = ReverseString(array[i]);
            }

            return newArray;
        }

        public static Func<string[], string[]> TempFunc3 =
            x => Cycle(x);

        public static Func<string[], string[]> CycleMemo =
            TempFunc3.Memoize();

        public static string[] Cycle(string[] lines)
        {
            string[] newLines = SwitchOrientationMemo(lines);

            newLines = TiltPlatformMemo(newLines);

            newLines = SwitchOrientationMemo(newLines);

            newLines = TiltPlatformMemo(newLines);

            newLines = ReverseArray(SwitchOrientationMemo(newLines));

            newLines = TiltPlatformMemo(newLines);

            newLines = ReverseArray(SwitchOrientationMemo(ReverseArray(newLines)));

            newLines = TiltPlatformMemo(newLines);

            newLines = ReverseArray(newLines);

            return newLines;
        }
        
    }
}