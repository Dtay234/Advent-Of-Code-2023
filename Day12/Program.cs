using System.Text.RegularExpressions;

namespace Day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
            int count = 0;
            List<string> solutions = new List<string>();
            //Func<Tuple<string, List<string>, int>, int> memoizedFunction = function.Memoize();

            for (int i = 0; i < lines.Length; i++)
            {
                /*
                string[] groups = Regex.Split(lines[i], @"[.#, ?]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray();
                string[] unknowns = Regex.Split(lines[i], @"[.,\d ]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray();
                string springs = Regex.Split(lines[i], @"[,\d ]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray()[0];

                string[] match = new string[3];

                for (int j = 0; j < 3; j++)
                {
                    string thing = "";
                    for (int k = 0; k < int.Parse(groups[j]); k++)
                    {
                        thing += "#";
                    }

                    match[j] = thing;
                }
                */



                Tuple<string, List<string>, int> tuple = new Tuple<string, List<string>, int>(lines[i], solutions, 0);


                count += functionMemo(tuple);
                
                
            }

            //string line = new string(springs);
            
            //count += GetPermutations("???.### 1,1,3", solutions);
            
            Console.WriteLine("Number of different arrangements of springs: " + count);

            

                
        }

        /*
        public static Func<Tuple<string, List<string>, int>, int> function =
            (thing => GetPermutations(thing));
        */

       

        public static Func<Tuple<string, List<string>, int>, int> function = 
            (x => GetPermutations(x));

        public static Func<Tuple<string, List<string>, int>, int> functionMemo =
            function.Memoize();


        public static int GetPermutations(
            //string originalLine, List<string> solutions, int startIndex
            Tuple<string, List<string>, int> tuple)
        {

                    string originalLine = tuple.Item1;
                    List<string> solutions = tuple.Item2;
                    int startIndex = tuple.Item3;

                    // Here comes the original code
                    string line = Regex.Split(originalLine, @"[,\d ]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray()[0];
                    int count = 0;

                    string[] tempGroups = Regex.Split(originalLine, @"[.#, ?]")
                            .Where(s => !string.IsNullOrEmpty(s))
                            .ToArray();

                    //Get rid of following loops for part 1
                    for (int j = 0; j < 4; j++)
                    {
                        line += "?" + line;
                    }

                    string[] groups = new string[tempGroups.Length * 5];

                    for (int i = 0; i < groups.Length; i++)
                    {
                        groups[i] = tempGroups[i % tempGroups.Length];
                    }

                    originalLine = line + " ";
                    for (int i = 0; i < groups.Length; i++)
                    {
                        originalLine += groups[i];
                        if (i != groups.Length - 1)
                        {
                            originalLine += ",";
                        }
                    }



                    for (int i = 0 + startIndex; i < line.Length; i++)
                    {
                        if (line[i] == '?' && !originalLine.Substring(0, i).Contains('?'))
                        {
                            startIndex++;
                            string newLine = originalLine.Substring(0, i) + "." + originalLine.Substring(i + 1);
                            string newLine2 = originalLine.Substring(0, i) + "#" + originalLine.Substring(i + 1);
                            int test = newLine.Length;

                            tuple = new Tuple<string, List<string>, int>(newLine, solutions, i);
                            count += functionMemo(tuple);
                            tuple = new Tuple<string, List<string>, int>(newLine2, solutions, i);
                            count += functionMemo(tuple);


                        }
                        else if (i == line.Length - 1 && !line.Contains('?'))
                        {
                            string[] match = new string[groups.Length];

                            for (int j = 0; j < match.Length; j++)
                            {
                                string thing = "";
                                for (int k = 0; k < int.Parse(groups[j]); k++)
                                {
                                    thing += "#";
                                }

                                match[j] = thing;
                            }

                            string[] hashes = Regex.Split(line, @"[.,\d ]")
                            .Where(s => !string.IsNullOrEmpty(s))
                            .ToArray();

                            bool matches = true;

                            /*
                            while (hashes.Length == match.Length
                                && matches)
                            {
                                if (match[counter] != hashes[counter])
                                {
                                    matches = false;
                                }
                                counter++;
                            }

                            if (matches)
                                count++;
                            */

                            if (hashes.Length == match.Length
                                //&& !solutions.Contains(line)
                                //&& line.Length == originalLine.Length
                                )
                            {


                                for (int j = 0; j < match.Length; j++)
                                {
                                    if (match[j] != hashes[j])
                                    {
                                        matches = false;
                                        break;
                                    }
                                }

                                if (matches)
                                    //solutions.Add(line);
                                    count++;
                            }

                        }
                    }

                    return count;
        }
    }
}