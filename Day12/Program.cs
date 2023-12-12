using System.Text.RegularExpressions;

namespace Day12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int count = 0;
            List<string> solutions = new List<string>();

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


                count += GetPermutations(lines[i], solutions, 0);
                


                
            }

            //string line = new string(springs);
            
            //count += GetPermutations("???.### 1,1,3", solutions);
            
            Console.WriteLine("Number of different arrangements of springs: " + count);
        }

        public static int GetPermutations(string originalLine, List<string> solutions, int startIndex)
        {
            string line = Regex.Split(originalLine, @"[,\d ]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray()[0]; 
            int count = 0;

            string[] groups = Regex.Split(originalLine, @"[.#, ?]")
                    .Where(s => !string.IsNullOrEmpty(s))
                    .ToArray();

            for (int i = 0 + startIndex; i < line.Length; i++)
            {
                if (line[i] == '?' && !originalLine.Substring(0, i).Contains('?'))
                {
                    startIndex++;
                    string newLine = originalLine.Substring(0, i) + "." + originalLine.Substring(i + 1);
                    string newLine2 = originalLine.Substring(0, i) + "#" + originalLine.Substring(i + 1);
                    int test = newLine.Length;
                    count += GetPermutations(newLine,  solutions, i);
                    
                    count += GetPermutations(newLine2, solutions, i);

                    
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

                    

                    if (hashes.Length == match.Length 
                        //&& !solutions.Contains(line)
                        //&& line.Length == originalLine.Length
                        )
                    {
                        bool matches = true;

                        for (int j = 0; j < match.Length; j++)
                        {
                            if (match[j] != hashes[j])
                            {
                                matches = false;
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