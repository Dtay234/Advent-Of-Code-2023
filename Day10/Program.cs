using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Day10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
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

            for (int i = 0; i < loop.Count; i++)
            {
                int[] tile = loop[i];

                if (lines[tile[0]][tile[1]] == '-') 
                {
                    loop.RemoveAt(i);
                    i--;
                }
            }

            loop.OrderBy(element => element[1])
                .ThenBy(element => element[0]);

            int count = 0;

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
                
                int[][] tempIndices = loop.FindAll(array => array[0] == i)
                    .OrderBy(x => x[1]).ToArray();
                int[] indices = new int[tempIndices.GetLength(0)];

                for (int k = 0; k < tempIndices.GetLength(0); k++)
                {
                     indices[k] = tempIndices[k][1];
                }

                string[] splitLine = new string[indices.Length / 2];

                try
                {
                    for (int j = 0; j < indices.Length; j += 2)
                    {
                        int test1 = indices[j];
                        int test2 = indices[j + 1];
                        splitLine[j / 2] =
                            Regex.Replace(
                                line.Substring
                                    (indices[j], indices[j + 1] - indices[j] + 1),
                                @"[SF7JL|-]",
                                "");
                    }
                }
                catch (IndexOutOfRangeException e)
                {
                    for (int j = 1; j < indices.Length; j += 2)
                    {
                        splitLine[j / 2] =
                            Regex.Replace(
                                line.Substring(indices[0], indices[1] - indices[0] + 1),
                                @"[SF7JL|-]",
                                "");
                    }
                }


                for (int j = 0; j < splitLine.Length; j++)
                {
                    if (!string.IsNullOrEmpty(splitLine[j]))
                    {
                        count += splitLine[j].Length;
                    }
                }
            }

            Console.WriteLine("Number of tiles within the loop: " + count);

        }
    }
}