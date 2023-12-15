namespace Day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            List<string> verticalReflect = new List<string>();
            List<string> horizontalReflect = new List<string>();
            int total = 0;

            for (int d = 0; d < lines.Length; d++)
            {   
                if (!string.IsNullOrEmpty(lines[d]))
                {
                    verticalReflect.Add(lines[d]);
                    while (horizontalReflect.Count < lines[d].Length)
                    {
                        horizontalReflect.Add("");
                    }

                    for (int i = 0; i < horizontalReflect.Count; i++)
                    {
                        horizontalReflect[i] += lines[d][i];
                    }
                }
                
                if (string.IsNullOrEmpty(lines[d]) || d == lines.Length - 1)
                {
                    //Write reflection to the console
                    /*
                    for (int i = 0; i < verticalReflection[i].Length; i++)
                    {
                        for (int j = 0; j < verticalReflection.Count; j++)
                        {
                            Console.Write(verticalReflection[j][i]);
                        }
                        Console.WriteLine();
                    }
                    */

                    int index;

                    bool horizontal = GetReflection(verticalReflect, out index);

                    if (!horizontal)
                    {
                        bool vertical = GetReflection(horizontalReflect, out index);

                        if (vertical)
                        {
                            total += index;
                        }
                    }
                    else
                    {
                        total += index * 100;
                    }
                    
                    verticalReflect.Clear();
                    horizontalReflect.Clear();
                }   
            }

            Console.WriteLine(total);
        }

        //Wrong answers: 14187 (low)

        public static bool GetReflection(List<string> reflection, out int reflectionIndex)
        {
            List<int> indices = new List<int>();

            for (int i = 1; i < reflection.Count; i++)
            {
                indices.Add(i);
            }

            for (int i = 1; i < reflection.Count; i++)
            {
                List<string> newReflection = new List<string>();

                if (i <=  reflection.Count / 2)
                {
                    for (int j = 0; j < i * 2; j++)
                    {
                        newReflection.Add(reflection[j]);
                    }
                }
                else
                {
                    for (int j = reflection.Count - (reflection.Count - i) * 2; 
                        j < reflection.Count; j++)
                    {
                        newReflection.Add(reflection[j]);
                    }
                }

                if (!CompareReflection(newReflection))
                {
                    indices.Remove(i);
                }
            }

            if (indices.Count == 1) 
            {
                reflectionIndex = indices[0];
                return true;
            }
            else
            {
                reflectionIndex = -1;
                return false;
            }
            
        }

        public static bool CompareReflection(List<string> reflection)
        {
            const int AllowedSmudges = 1;
            int smudges = 0;

            for (int i = 0; i < reflection.Count/2; i++)
            {
                for (int j = 0; j < reflection[i].Length; j++)
                {
                    if (reflection[i][j] != reflection[^(i + 1)][j])
                    {
                        smudges++;
                    }
                }
            }

            if (smudges == AllowedSmudges)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
