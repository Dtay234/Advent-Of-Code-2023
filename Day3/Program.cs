using System.Xml.Schema;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../../text.txt");
            string symbols = "@#$%&*/+=-";
            string[] nums = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            List<int> numbers = new List<int>();
            int total = 0;
            List<Gear> gears = new List<Gear>();

            for (int i = 0; i < input.Length; i++)
            {
                string line = input[i];

                
                string numberString = "";
                bool nextToSymbol = false;
                Gear gearToChange = null;
                bool nextToGear = false;

                for (int j = 0; j < line.Length; j++)
                {
                    if (nums.Contains(line[j].ToString()))
                    {
                        numberString += line[j];

                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                /*
                                if (i == 127 && line[j] == '9')
                                    Console.WriteLine();
                                */

                                if ((i + k) < input.Length 
                                    && (j + l < line.Length)
                                    && (i + k > 0)
                                    && (j + l > 0))
                                {
                                    char check = input[i + k][j + l];

                                    if (symbols.Contains(check))
                                    {
                                        nextToSymbol = true;
                                    }
                                    
                                    //PART 2
                                    if (check == '*')
                                    {
                                        nextToGear = true;
                                        bool contains = false;

                                        foreach (Gear g in gears)
                                        {
                                            if (g.line == (i + k) && g.character == (j + l))
                                            {
                                                contains = true;
                                                gearToChange = g;
                                                
                                            }
                                        }

                                        if (!contains)
                                        {
                                            gears.Add(new Gear(i + k, j + l));
                                            gearToChange = gears.Last();
                                        }


                                    }
                                }

                            }
                            
                        }
                    }
                    else if (numberString != "" && nextToSymbol)
                    {
                        numbers.Add(int.Parse(numberString));
                        //total += int.Parse(numberString);
                        nextToSymbol = false;
                        numberString = "";
                    }                    
                    else
                    {
                        numberString = "";
                    }
                    
                    if (j == line.Length - 1 && nextToSymbol)
                    {
                        numbers.Add(int.Parse(numberString));
                        //total += int.Parse(numberString);
                        nextToSymbol = false;
                        numberString = "";
                    }
                    /*
                    if (!symbols.Contains(line[j]) &&
                        !nums.Contains(line[j].ToString()) && 
                        line[j] != '.')
                    {
                        Console.WriteLine(line[j]);
                    }
                    */
                    if (nextToGear && numberString != "")
                    {
                        gearToChange.gearRatio *= int.Parse(numberString);
                        gearToChange.adjacent++;
                    }
                    
                    
                }

            }

            foreach (int i in numbers)
            {
                total += i;
            }
            Console.WriteLine(total);

            int gearTotal = 0;

            foreach (Gear g in gears)
            {
                if (g.adjacent == 2)
                {
                    gearTotal += g.gearRatio;
                }
            }

            Console.WriteLine(gearTotal);

        }
    }
}