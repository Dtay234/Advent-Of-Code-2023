using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

namespace Day14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
            int total = 0;
            

            for (int z = 0; z < 100000; z++)
            {
                lines = CycleMemo(lines);
            }

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

        public static Func<List<char>, List<char>> TempFunc =
            x => TiltPlatform(x);

        public static Func<List<char>, List<char>> TiltPlatformMemo =
            TempFunc.Memoize();

        public static List<char> TiltPlatform(List<char> listToSort) 
        {
            for (int k = 1; k < listToSort.Count; k++)
            {
                if (listToSort[k] == 'O')
                {

                    int counter = 1;


                    try
                    {

                        while (listToSort[k - counter] == '.')
                        {
                            counter++;
                        }
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        counter--;
                    }

                    if (listToSort[k - counter] == '#')
                    {
                        counter--;
                    }


                    listToSort.RemoveAt(k);
                    listToSort.Insert(k - counter, 'O');

                }


            }

            return listToSort;
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

            for (int i = 0; i < newLines.Length; i++)
            {
                string[] thing = Regex.Replace(newLines[i], 
                    @"[.O]+", )
                List<char> listToSort = newLines[i].ToList();

                TiltPlatformMemo(listToSort);

                newLines[i] = new string(listToSort.ToArray());
            }

            newLines = SwitchOrientationMemo(newLines);

            for (int i = 0; i < newLines.Length; i++)
            {
                List<char> listToSort = newLines[i].ToList();

                TiltPlatformMemo(listToSort);

                newLines[i] = new string(listToSort.ToArray());
            }

            newLines = ReverseArray(SwitchOrientationMemo(newLines));

            for (int i = 0; i < newLines.Length; i++)
            {
                List<char> listToSort = newLines[i].ToList();

                TiltPlatformMemo(listToSort);

                newLines[i] = new string(listToSort.ToArray());
            }

            newLines = ReverseArray(SwitchOrientationMemo(ReverseArray(newLines)));

            for (int i = 0; i < newLines.Length; i++)
            {
                List<char> listToSort = newLines[i].ToList();

                TiltPlatformMemo(listToSort);

                newLines[i] = new string(listToSort.ToArray());
            }

            newLines = ReverseArray(newLines);

            return newLines;
        }
        
    }
}