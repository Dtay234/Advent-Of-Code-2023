using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string symbols = "@#$%&*/+=-";
            string nums = "0123456789";
            //List<int> numbers = new List<int>();
            int total = 0;
            
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {

                    if (lines[i][j] == '*')
                    {
                        int gearRatio = 1;
                        string top = null;
                        string middle = null;
                        string bottom = null;
                        int adjascentNums = 0;

                        if (i != 0)
                        {
                            adjascentNums += Regex.Matches(lines[i - 1].Substring(j - 1, 3), @"\d+").Count();
                            top = lines[i - 1];
                        }

                        adjascentNums += Regex.Matches(lines[i].Substring(j - 1, 3), @"\d+").Count();
                        middle = lines[i];

                        if (i != (lines.Length - 1))
                        {
                            adjascentNums += Regex.Matches(lines[i + 1].Substring(j - 1, 3), @"\d+").Count();
                            bottom = lines[i + 1];
                        }

                        if (adjascentNums == 2)
                        {
                            List<Number> adjacent = new List<Number>();
                            int counter = 0;
                            
                            if (i != 0)
                            {
                                for (int k = 0; k < top.Length; k++)
                                {
                                    if (nums.Contains(top[k]))
                                    {
                                        string number = Regex.Split(top.Substring(k), @"[\D]+")
                                            .Where(s => !string.IsNullOrEmpty(s))
                                            .ToArray()[0];

                                        
                                        adjacent.Add(new Number(number, i - 1, k));
                                        k += number.Length - 1;
                                    }
                                }
                            }

                            for (int k = 0; k < middle.Length; k++)
                            {
                                if (nums.Contains(middle[k]))
                                {
                                    string number = Regex.Split(middle.Substring(k), @"\D+")
                                        .Where(s => !string.IsNullOrEmpty(s))
                                        .ToArray()[0];

                                    
                                    adjacent.Add(new Number(number, i - 1, k));
                                    k += number.Length - 1;
                                }
                            }

                            if (i != (lines.Length - 1))
                            {
                                for (int k = 0; k < bottom.Length; k++)
                                {
                                    if (nums.Contains(bottom[k]))
                                    {
                                        string number = Regex.Split(bottom.Substring(k), @"\D+")
                                            .Where(s => !string.IsNullOrEmpty(s))
                                            .ToArray()[0];

                                        
                                        adjacent.Add(new Number(number, i - 1, k));
                                        k += number.Length - 1;
                                    }
                                }
                            }

                            

                            foreach (Number number in adjacent)
                            {
                                if (number.IsAdjacent(i, j) )
                                {
                                    gearRatio *= number.value;
                                }
                            }

                            total += gearRatio;
                        }


                        
                    }

                }
            }
            
            Console.WriteLine(total);
        }
    }
}