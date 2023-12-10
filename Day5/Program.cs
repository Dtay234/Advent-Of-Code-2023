namespace Day5
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] seedsString = lines[0].Split(' ');
            //List<long> seeds = new List<long>();

            /*
            long arrayLength = 0;
            for (int i = 2; i < seedsString.Length; i += 2)
            {
                arrayLength += long.Parse(seedsString[i]);
            }
            */
            
            long[][] seeds = new long[(seedsString.Length - 1) / 2][];

            /*
            for (int i = 1; i < seedsString.Length; i++)
            { 
                seeds[i - 1] = long.Parse(seedsString[i]);
            }
            */

            //int count = 0;
            for (int i = 1; i < seedsString.Length; i += 2)
            {
                long range = long.Parse(seedsString[i + 1]);
                long start = long.Parse(seedsString[i]);
                int index = (int)Math.Ceiling(i / 2.0) - 1;

                seeds[index] = new long[range];

                for (long j = 0; j < range; j++)
                {
                    seeds[index][j] = start + j;
                    //count++;
                }
            }

            bool[][] converted = new bool[seeds.GetLength(0)][];

            for (int i = 0; i < seeds.GetLength(0); i++)
            {
                converted[i] = new bool[seeds[i].Length];
            }

            /*
            List<bool> converted = new List<bool>();

            for (int i = 0; i < seeds.Length; i++)
            {
                converted.Add(false);
            }
            */
            
            for (int i = 3; i < lines.Length; i++)
            {
                string thing = lines[i];
                if (lines[i] == "")
                {
                    i++;
                    for (int j = 0; j < converted.GetLength(0); j++) 
                    {
                        for (int k = 0; k < converted[j].Length; k++)
                        {
                            converted[j][k] = false;                      
                        }                       
                    }
                    continue;
                }

                string[] rangeString = lines[i].Split(' ');
                long[] ranges = new long[rangeString.Length];

                for (int j = 0; j < rangeString.Length; j++)
                {
                    ranges[j] = long.Parse(rangeString[j]);
                }

                for(int j = 0; j < seeds.GetLength(0); j++)
                {
                    for (long k = 0; k < seeds[j].Length; k++)
                    {


                        long seed = seeds[j][k];
                        long difference = seed - ranges[1];


                        if (difference < ranges[2] && difference >= 0 && converted[j][k] == false)
                        {
                            seeds[j][k] = ranges[0] + difference;
                            converted[j][k] = true;
                        }
                        else if (difference < 0)
                        {
                            k -= difference + 1;
                        }

                    }
                }
            }

            long[] mins = new long[seeds.GetLength(0)];

            for (int i = 0; i < mins.Length; i++)
            {
                mins[i] = seeds[i].Min();
            }

            Console.WriteLine(mins.Min());
            */
        }
    }
}