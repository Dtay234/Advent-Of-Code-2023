using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            int[] animalPos = null;
            List<int[]> loop = new List<int[]>();
            int loopSize = 0;
            string fromSouth = "S|F7";
            string fromEast = "S-FL";
            string fromWest = "S-7J";
            string fromNorth = "S|JL";
            
            //Regex splitter = new Regex(@"\W");
            //string[] test = splitter.Split("A.B.C");

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (lines[i][j] == 'S')
                    {
                        animalPos = new int[] {i, j};
                    }
                }
            }

            int[] currentPos = animalPos;
            int cameFrom = -1;

            do
            {
                bool foundPipe = false;
                
                for (int i = 0; i < 4; i++)
                {
                    if (i != cameFrom)
                    {
                        try
                        {
                            switch (i)
                            {
                                case 0:
                                    if (fromSouth.Contains(lines[currentPos[0] - 1][currentPos[1]])
                                        && fromNorth.Contains(lines[currentPos[0]][currentPos[1]]))
                                    {
                                        foundPipe = true;
                                        cameFrom = 3;
                                        currentPos = new int[] { currentPos[0] - 1, currentPos[1] };
                                    }
                                    break;
                                case 1:
                                    if (fromEast.Contains(lines[currentPos[0]][currentPos[1] - 1])
                                        && fromWest.Contains(lines[currentPos[0]][currentPos[1]]))
                                    {
                                        foundPipe = true;
                                        cameFrom = 2;
                                        currentPos = new int[] { currentPos[0], currentPos[1] - 1 };
                                    }
                                    break;
                                case 2:
                                    if (fromWest.Contains(lines[currentPos[0]][currentPos[1] + 1])
                                        && fromEast.Contains(lines[currentPos[0]][currentPos[1]]))
                                    {
                                        foundPipe = true;
                                        cameFrom = 1;
                                        currentPos = new int[] { currentPos[0], currentPos[1] + 1 };
                                    }
                                    break;
                                case 3:
                                    if (fromNorth.Contains(lines[currentPos[0] + 1][currentPos[1]])
                                        && fromSouth.Contains(lines[currentPos[0]][currentPos[1]]))
                                    {
                                        foundPipe = true;
                                        cameFrom = 0;
                                        currentPos = new int[] { currentPos[0] + 1, currentPos[1] };
                                    }
                                    break;
                            }
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    if (foundPipe)
                    {
                        loop.Add(currentPos);
                        break;
                    }
                }

                loopSize++;
            } while (currentPos[0] != animalPos[0] || currentPos[1] != animalPos[1]);

            Console.WriteLine("Farthest number of steps; " + loopSize/2.0);
            /*
            for (int i = 0; i < loop.Count; i++)
            {
                int[] tile = loop[i];

                if (lines[tile[0]][tile[1]] == '-') 
                {
                    loop.RemoveAt(i);
                    i--;
                }
            }
            */
            loop.OrderBy(element => element[1])
                .ThenBy(element => element[0]);

            int count = 0;
            /*
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                bool contains = false;

                for (int j = 0; j < line.Length; j++)
                {
                    if (loop.Find(array => (array[0] == i && array[1] == j)) != null)
                    {
                        contains = true;
                    }          
                }

                if (!contains)
                {
                    continue;
                }



                /*
                for (int j = 0; j < line.Length; j++)
                {
                    if (loop.Find(array => (array[0] == i && array[1] == j)) != null)
                    {
                        line = line.Substring(j);
                        break;
                    }
                }

                for (int j = line.Length - 1; j > 0; j--)
                {
                    if (loop.Find(array => (array[0] == i && array[1] == j)) != null)
                    {
                        line = line.Substring(line.Length - j - 1, j);
                        break;
                    }
                }
                

                
                string condition = "SF7JL|-";
                string[] splitLine =
                    Regex.Split(line, @"[SF7JL|-]")
                    .Where(s => !string.IsNullOrEmpty(s)).ToArray();
                // Array.Find(line, )
                */
                /*
                int[][] tempIndices = loop.FindAll(array => array[0] == i)
                    .OrderBy(x => x[1]).ToArray();
                int[] indices = new int[tempIndices.GetLength(0)];

                for (int k = 0; k < tempIndices.GetLength(0); k++)
                {
                     indices[k] = tempIndices[k][1];
                }
                
                string[] splitLine = new string[indices.Length / 2 + 1];

                for (int j = 0; j < indices.Length; j += 2)
                {
                    if (j + 1 >= indices.Length)
                    {
                        break;
                    }
                    int test1 = indices[j];
                    int test2 = indices[j + 1];
                    char debug1 = line[indices[j]];
                    char debug2 = line[indices[j + 1]];

                    


                    /*
                    if ((line[indices[j]] == 'L' || line[indices[j]] == 'F')
                        && (line[indices[j + 1]] == '7' || line[indices[j + 1]] == 'J')
                        
                        ) 
                    {
                        j--;
                        continue;
                    }
                    else if (indices.Count() % 2 == 1)
                    {
                        //j--;
                    }
                    */
                    /*
                    splitLine[j/2] =
                        Regex.Replace(
                            line.Substring(indices[j], indices[j + 1] - indices[j] + 1),
                            @"[SF7JL|]", 
                            "");

                    /*
                    if ((line[indices[j]] == '|' || line[indices[j + 1]] == '|')
                        && !(line[indices[j]] == '|' && line[indices[j + 1]] == '|')
                        && ((Regex.Matches(line, "[|]").Count) % 2 == 1)
                        )
                    {
                        j += 2;
                        continue;
                    }
                    */

                    /*
                    else if ((line[indices[j]] == '|' || line[indices[j + 1]] == '|')
                        && !(line[indices[j]] == '|' && line[indices[j + 1]] == '|'))
                    {
                        j++;
                    }
                    */
                    
                

                /*
                for (int j = 0; j < splitLine.Length; j++)
                {
                    if (!string.IsNullOrEmpty(splitLine[j]))
                    {
                        count += Regex.Matches(splitLine[j], "[.]").Count();
                    }
                }
                */
            


            
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (!(loop.Exists(array => array[0] == i && array[1] == j)))
                    {
                        if (IsInLoop(lines, j, i, loop))
                        {
                            count++;
                        }
                    }            
                }
            }
            

            //Console.WriteLine(IsInLoop(lines, new int[] { 6, 2 }, loop));

            Console.WriteLine("Number of tiles within the loop: " + count);

            //Incorrect: 249 (low), 261 (low), 
        }

        public static bool IsInLoop(string[] lines, int xPos, int yPos, List<int[]> loop)
        {
            bool[] contained = new bool[4];
            string line = lines[yPos];
            

            //North
            string north = "";
            for (int k = 1; k < yPos + 1; k++)
            {
                
                if (loop.Find(array => (array[0] == yPos - k && array[1] == xPos)) != null)
                {
                    north += lines[yPos - k][xPos];
                }
            }
            string temp = Regex.Replace(north, @"\|+", "");
                north = Regex.Replace(temp, @"JF|L7|SF", "|");

                if (north.Length % 2 == 1)
                {
                    contained[0] = true;
                }

            //South
            string south = "";
            for (int k = 1; k < line.Length - yPos; k++)
            {
                
                if (loop.Find(array => (array[0] == yPos + k && array[1] == xPos)) != null)
                {
                    south += lines[yPos + k][xPos];
                }

                
            }
            south = Regex.Replace(Regex.Replace(south, @"\|+", ""), @"FJ|7L|FS", "|");

            if (south.Length % 2 == 1)
            {
                contained[1] = true;
            }
            //East
            string east = "";
            for (int k = 1; k < line.Length - xPos; k++)
            {
                
                if (loop.Find(array => (array[0] == yPos && array[1] == xPos + k)) != null)
                {
                    east += lines[yPos][xPos + k];
                }

                
            }
            east = Regex.Replace(Regex.Replace(east, @"\-+", ""), @"FJ|L7|FS", "-");
            if (east.Length % 2 == 1)
            {
                contained[2] = true;
            }
            //West
            string west = "";
            for (int k = 1; k < xPos + 1; k++)
            {
                
                if (loop.Find(array => (array[0] == yPos && array[1] == xPos - k)) != null)
                {
                    west += lines[yPos][xPos - k];
                }

                
            }
            west = Regex.Replace(Regex.Replace(west, @"\-+", ""), @"JF|7L|SF", "-");
            if (west.Length % 2 == 1)
            {
                contained[3] = true;
            }

            bool thingToReturn = Array.TrueForAll(contained, b => b);
            return thingToReturn;
        }
            

            
        
    }

    
}