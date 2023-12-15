namespace Day13
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            List<string> horizontalReflection = new List<string>();
            List<string> verticalReflection = new List<string>();
            int total = 0;

            for (int d = 0; d < lines.Length; d++)
            {   
                if (!string.IsNullOrEmpty(lines[d]))
                {
                    horizontalReflection.Add(lines[d]);
                    while (verticalReflection.Count < lines[d].Length)
                    {
                        verticalReflection.Add("");
                    }

                    for (int i = 0; i < verticalReflection.Count; i++)
                    {
                        verticalReflection[i] += lines[d][i];
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

                    bool horizontal = GetReflection(horizontalReflection, out index);

                    if (!horizontal)
                    {
                        bool vertical = GetReflection(verticalReflection, out index);

                        total += index * 100;
                    }
                    else
                    {
                        total += index;
                    }
                    
                    horizontalReflection.Clear();
                    verticalReflection.Clear();
                }   
            }

            Console.WriteLine(total);
        }

        //Wrong answers: 14187 (low)

        public static bool GetReflection(List<string> reflection, out int reflectionIndex)
        {
            List<int> possibleReflections = new List<int>();

            for (int i = 1; i < reflection[0].Length; i++)
            {
                possibleReflections.Add(i);
            }

            //string[][] reflectionArray = new string[reflection.Count][]; 

            for (int i = 0; i < reflection.Count; i++)
            {
                for (int j = 1; j < reflection[i].Length / 2 + 1; j++)
                {
                    string tryReflect = reflection[i].Substring(0, j * 2);

                    List<char> secondHalf = tryReflect.Substring(tryReflect.Length / 2).ToList();
                    secondHalf.Reverse();
                    string secondHalfString = new string(secondHalf.ToArray());

                    if (!tryReflect.StartsWith(secondHalfString))
                    {
                        possibleReflections.Remove(j);
                    }
                }

                for (int j = reflection[i].Length / 2 + 1;
                    j < reflection[i].Length; j++)
                {
                    string tryReflect = reflection[i]
                        .Substring((int)((j - reflection[i].Length / 2.0) * 2));

                    List<char> secondHalf = tryReflect.Substring(tryReflect.Length / 2).ToList();
                    secondHalf.Reverse();
                    string secondHalfString = new string(secondHalf.ToArray());

                    if (!tryReflect.StartsWith(secondHalfString))
                    {
                        possibleReflections.Remove(j);
                    }
                }
            }

            if (possibleReflections.Count == 1)
            {
                reflectionIndex = possibleReflections[0];
                return true;
            }

            reflectionIndex = -1;
            return false;
        }

        public static bool CompareReflectionSmudge
    }
}
