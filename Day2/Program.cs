namespace Day2
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            
            int total = 0;
            bool possible;
            int powerSum = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int gameNum = i + 1;
                possible = true;
                string[] sets = (lines[i].Split(":"))[1].Split(";");
                int minBlue = 0;
                int minGreen = 0;
                int minRed = 0;

                for (int j = 0; j < sets.Length; j++)
                {
                    string[] cubes = sets[j].Split(",");

                    foreach (string s in cubes)
                    {
                        string[] thing = s.Trim().Split(" ");

                        switch (thing[1])
                        {
                            case "blue":
                                if (int.Parse(thing[0]) > 14)
                                {
                                    possible = false;
                                    
                                }
                                minBlue = Math.Max(minBlue, int.Parse(thing[0]));
                                break;
                            case "green":
                                if (int.Parse(thing[0]) > 13)
                                {
                                    possible = false;
                                    
                                }
                                minGreen = Math.Max(minGreen, int.Parse(thing[0]));
                                break;
                            case "red":
                                if (int.Parse(thing[0]) > 12)
                                {
                                    
                                    possible = false;
                                }
                                minRed = Math.Max(minRed, int.Parse(thing[0]));
                                break;
                        }
                    }
                }

                //PART 1
                if (possible)
                {
                    total += (i + 1);
                }
                //Part 2
                powerSum += (minBlue * minGreen * minRed);
            }

            Console.WriteLine(total);
            Console.WriteLine(powerSum);
        }
    }
}