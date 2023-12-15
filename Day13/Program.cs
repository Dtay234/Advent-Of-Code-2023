using System.Text.RegularExpressions;
/*
namespace Day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
            List<string> horizontalReflection = new List<string>();
            List<string> verticalReflection = new List<string>();
            int temp = 0;

            for (int d = 0; d < lines.Length; d++)
            {
                
                if (!string.IsNullOrEmpty(lines[d]))
                {
                    horizontalReflection.Add(lines[d]);
                    
                }
                
                if (string.IsNullOrEmpty(lines[d]) || d == lines.Length - 1)
                {
                    
                    List<int> possibleReflection = new List<int>();

                    for (int i = 1; i < horizontalReflection[0].Length; i++)
                    {
                        possibleReflection.Add(i);
                    }

                    bool foundReflection = false;

                    for (int i = 0; i < horizontalReflection.Count; i++)
                    {
                        string line = horizontalReflection[i];

                        for (int j = 0; j < horizontalReflection[0].Length; j++)
                        {
                            if (j < horizontalReflection[0].Length / 2.0)
                            {
                                string tempString = line.Substring(0, j);
                                string tempString2 = line.Substring(j, j);

                                char[] array = tempString.ToCharArray();
                                array = array.Reverse().ToArray();
                                tempString = new string(array);

                                if (tempString != tempString2)
                                {
                                    possibleReflection.Remove(j);
                                }
                            }


                            else
                            {
                                string tempString = tempString = line.Substring(j);
                                string tempString2 = line.Substring(j - tempString.Length, tempString.Length);

                                char[] array = tempString2.ToCharArray();
                                array = array.Reverse().ToArray();
                                tempString2 = new string(array);


                                if (tempString != null &&
                                    tempString != tempString2)
                                {
                                    possibleReflection.Remove(j);
                                }
                            }

                        }

                        
                    }

                    if (possibleReflection.Count == 1)
                    {
                        foundReflection = true;
                        horizontalReflection.Clear();
                    }

                    if (!foundReflection)
                    {

                        //ADD COLUMNS TO VERTICAL REFLECTION

                        string[] lines2 = new string[lines[0].Length];

                        for (int k = 0; k < lines2.Length; k++)
                        {
                            string line = "";

                            for (int j = 0; j < (d - temp + 1); j++)
                            {
                                line += lines[j + temp][k];
                            }

                            lines2[k] = line;
                        }


                        for (int i = 1; i < lines2.Length ; i++)
                        {
                            possibleReflection.Add(i);
                        }

                        for (int i = 0; i < lines2.Length; i++)
                        {
                            string column = lines[i];

                            for (int j = 0; j < lines2[0].Length; j++)
                            {

                                if (j <= lines2[0].Length / 2.0)
                                {
                                    string tempString = column.Substring(0, j);
                                    string tempString2 = column.Substring(j, j);

                                    char[] array = tempString.ToCharArray();
                                    array = array.Reverse().ToArray();
                                    tempString = new string(array);

                                    if (tempString != tempString2)
                                    {
                                        possibleReflection.Remove(j);
                                    }
                                }
                                

                                else
                                {
                                    string tempString = tempString = column.Substring(j);
                                    string tempString2 = column.Substring(j - tempString.Length, tempString.Length);

                                    char[] array = tempString2.ToCharArray();
                                    array = array.Reverse().ToArray();
                                    tempString2 = new string(array);


                                    if (tempString != null &&
                                        tempString != tempString2)
                                    {
                                        possibleReflection.Remove(j);
                                    }
                                }
                                
                            }
                        }
                        
                    }

                    temp = d + 1;
                }


                
            }

            
            



            /*
            char[,] notes = new char[reflection.Count, reflection[0].Length];

            for (int i = 0; i < reflection.Count; i++)
            {
                for (int j = 0; j < reflection[i].Length; j++)
                {
                    notes[i, j] = reflection[i][j];
                }
            }

            for (int i = 0;i < reflection.Count; i++)
            {
                if ()
            }
            *
        }
    }
}
*/