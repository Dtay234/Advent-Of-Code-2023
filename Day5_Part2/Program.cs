namespace Day5_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] seedsString = lines[0].Split(' ');
            //Range[] seeds = new Range[(seedsString.Length - 1) / 2];
            List<Range> seeds = new List<Range>();
            List<Map> maps = new List<Map>();
            
            for (int i = 1; i < seedsString.Length; i += 2)
            {
                long range = long.Parse(seedsString[i + 1]);
                long start = long.Parse(seedsString[i]);
                seeds.Add(new Range(start, range));
            }

            long totalSeeds = 0;
            for (int i = 0; i < seeds.Count; i++)
            {
                totalSeeds += seeds[i].Length;
            }


            seedsString = null;

            for (int i = 3; i <= lines.Length; i++)
            {
                if (i == lines.Length || lines[i] == "")
                {
                    for (int j = 0; j < seeds.Count; j++)
                    {
                        Range range = seeds[j];
                        long originalStart = seeds[j].Start;

                        foreach (Map map in maps)
                        {
                            Range[] splitRange = seeds[j].Split(map.sources);

                            if (splitRange != null)
                            {
                                seeds.RemoveAt(j);
                                if (splitRange[0] != null)
                                seeds.Add(splitRange[0]);
                                if (splitRange[2] != null)
                                    seeds.Add(splitRange[2]);

                                if (splitRange[2] == null)
                                {
                                    splitRange[1].ConvertIDs(map);
                                }
                                else
                                {
                                    splitRange[1].ConvertIDs(map, originalStart);
                                }
                                
                                seeds.Insert(0, splitRange[1]);
                                //j++;
                                break;
                            }
                            
                        }
                    }

                    i++;
                    maps.Clear();
                    continue;
                }

                string[] rangeString = lines[i].Split(' ');
                long[] ranges = new long[rangeString.Length];

                for (int j = 0; j < rangeString.Length; j++)
                {
                    ranges[j] = long.Parse(rangeString[j]);
                }

                maps.Add(new Map(ranges[0], new Range(ranges[1], ranges[2])));
                
                
            }

            long min = long.MaxValue;
            totalSeeds = 0;

            for (int i = 0; i < seeds.Count; i++)
            {
                totalSeeds += seeds[i].Length;
                min = Math.Min(seeds[i].start, min);
            }

            Console.WriteLine($"Lowest location ID: {min}");

            /*
            Random random = new Random();
            Range range = new Range(0, 1);
           

            Range[] splitRange;

            
            for (int i = 0; i < 20; i++)
            {
                //Range range2 = new Range(random.Next(-2, 13), random.Next(2, 12));
                Range range2 = new Range(-1, 3);
                splitRange = range.Split(range2);
                Range overlap = range.Overlap(range2);
                Console.WriteLine();
            }
            

            //Console.WriteLine(overlap);
            */ //Testing for ranges
        }
    }
}