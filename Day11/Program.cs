namespace Day11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            StreamWriter writer = new StreamWriter("../../../output.txt");

            char[,] space = new char[lines.Length, lines[0].Length];
            List<int> rowsEmpty = new List<int>();
            List<int> colsEmpty = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    space[i,j] = lines[i][j];
                }
            }

            for (int i = 0; i < space.GetLength(0); i++)
            {
                bool empty = true;

                for (int j = 0; j < space.GetLength(1); j++)
                {
                    if (space[i,j] == '#')
                    {
                        empty = false;
                    }
                }

                if (empty)
                {
                    rowsEmpty.Add(i);
                }
            }

            for (int j = 0; j < space.GetLength(1); j++)
            {
                bool empty = true;

                for (int i = 0; i < space.GetLength(1); i++)
                {
                    if (space[i, j] == '#')
                    {
                        empty = false;
                    }
                }

                if (empty)
                {
                    colsEmpty.Add(j);
                }
            }

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {                   
                    writer.Write(lines[i][j]);

                    if (colsEmpty.Contains(j))
                    {
                        writer.Write(lines[i][j]);
                    }
                }

                writer.WriteLine();

                if (rowsEmpty.Contains(i))
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        writer.Write(lines[i][j]);

                        if (colsEmpty.Contains(j))
                        {
                            writer.Write(lines[i][j]);
                        }
                    }

                    writer.WriteLine();
                }
            }

            writer.Close();

            
            List<int[]> galaxies = new List<int[]>();
            /*
            lines = File.ReadAllLines("../../../output.txt");
            space = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    space[i, j] = lines[i][j];
                }
            }
            */
            for (int i = 0; i < space.GetLength(0); i++)
            {
                for (int j = 0; j < space.GetLength(1); j++)
                {
                    char c = space[i, j];

                    if (c == '#')
                    {
                        galaxies.Add(new int[] {i, j});
                    }
                }
            }

            long totalDistance = 0;

            for (int i = 0; i < galaxies.Count;)
            {
                int[] galaxy = galaxies[i];

                foreach (int[] otherGalaxy in galaxies)
                {
                    if (galaxy != otherGalaxy)
                    {
                        //CHANGE THIS TO CHANGE EXPANSION OF EMPTY LINES
                        const int SpaceExpansionFactor = 1000000;

                        int x = (otherGalaxy[1] - galaxy[1]);
                        int y = (otherGalaxy[0] - galaxy[0]);

                        int distanceX = 0;
                        int distanceY = 0;

                        if (x > 0)
                        {
                            for (int j = 0; j < x; j++)
                            {
                                distanceX++;
                                if (colsEmpty.Contains(galaxy[1] + j))
                                {
                                    distanceX += SpaceExpansionFactor - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j > x; j--)
                            {
                                distanceX++;
                                if (colsEmpty.Contains(galaxy[1] + j))
                                {
                                    distanceX += SpaceExpansionFactor - 1;
                                }
                            }
                        }
                        
                        if (y > 0)
                        {
                            for (int j = 0; j < y; j++)
                            {
                                distanceY++;
                                if (rowsEmpty.Contains(galaxy[0] + j))
                                {
                                    distanceY += SpaceExpansionFactor - 1;
                                }
                            }
                        }
                        else
                        {
                            for (int j = 0; j > y; j--)
                            {
                                distanceY++;
                                if (rowsEmpty.Contains(galaxy[0] + j))
                                {
                                    distanceY += SpaceExpansionFactor - 1;
                                }
                            }
                        }
                        

                        totalDistance += (distanceX + distanceY);
                    }
                }

                galaxies.RemoveAt(0);
            }

            Console.WriteLine("Total distance between galaxies: " + totalDistance);
        }
    }
}