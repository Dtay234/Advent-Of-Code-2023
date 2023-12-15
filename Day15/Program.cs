using System.Numerics;
using System.Text.RegularExpressions;

namespace Day15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string initialization = File.ReadAllText("../../../text.txt");
            string[] input = initialization.Split(',');
            List<List<string>> boxes = new List<List<string>>();

            for (int i = 0; i < 256; i++)
            {
                boxes.Add(new List<string>());
            }

            
            int total = 0;
            long focusingPower = 0;

         
            foreach (string s in input)
            {
                int current = 0;

                //Get rid of this split for part 1

                for (int j = 0; j < Regex.Split(s, @"[-=]")[0].Length; j++)
                {
                    char c = s[j];
                    current += c;
                    current *= 17;
                    current = current % 256;
                }

                if (s.Contains('='))
                {
                    string lens = boxes[current].Find(x => x.StartsWith(s.Split('=')[0]));                  
                    if (!boxes[current].Contains(lens)) 
                    {
                        boxes[current].Add(s.Replace('=', ' '));
                    }
                    else
                    {
                        int index = boxes[current].IndexOf(lens);
                        boxes[current].RemoveAt(index);
                        boxes[current].Insert(index, s.Replace('=', ' '));
                    }
                    
                }
                else if (s.Contains('-'))
                {
                    string lens = boxes[current].Find(x => x.StartsWith(s.Split('-')[0]));
                    boxes[current].Remove(lens);
                }
                

                total += current;
            }

            for (int i = 0; i < boxes.Count; i++)
            {
                List<string> box = boxes[i];
                
                for (int j = 0; j < box.Count; j++)
                {
                    string lens = box[j];
                    long temp = i + 1;
                    temp *= j + 1;
                    temp *= int.Parse(lens.Split(' ')[1]);;

                    focusingPower += temp;
                    
                }
            }


            Console.WriteLine("Sum of step values in " +
                "the initialization sequence: " + total);

            Console.WriteLine("\nSum of focusing power of all lenses: " + focusingPower);

            //Wrong: 47823 (low) 1448115 (high) 259098 (high)
            //Literally all of my problems came from the fact that I was using 2 as the length of the label everywhere
            //since the sample input only has labels with length 2
        }
    }
}