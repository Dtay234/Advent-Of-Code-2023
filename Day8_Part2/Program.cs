using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Numerics;

namespace Day8_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string directions = lines[0];

            string[][] nodesArray = new string[lines.Length - 2][];
            for (int i = 0; i < lines.Length - 2; i++)
            {
                nodesArray[i] = new string[3];
            }

            for (int i = 2; i < lines.Length; i++)
            {
                lines[i] = lines[i].Remove(Array.IndexOf(lines[i].ToArray(), '('), 1);
                lines[i] = lines[i].Remove(Array.IndexOf(lines[i].ToArray(), ')'), 1);

                while (lines[i].Contains(' '))
                {
                    lines[i] = lines[i].Remove(Array.IndexOf(lines[i].ToArray(), ' '), 1);
                }

                string[] split = lines[i].Split('=');
                string[] leftRight = split[1].Split(',');

                nodesArray[i - 2][0] = split[0];
                nodesArray[i - 2][1] = leftRight[0];
                nodesArray[i - 2][2] = leftRight[1];

            }


            List<string[]> paths = new List<string[]>();
            List<string[]> paths2 = new List<string[]>();

            for (int i = 0; i < nodesArray.GetLength(0); i++)
            {
                if (nodesArray[i][0][2] == 'A')
                {
                    paths.Add(new string[] { nodesArray[i][0], nodesArray[i][1], nodesArray[i][2] });
                    paths2.Add(new string[] { nodesArray[i][0], nodesArray[i][1], nodesArray[i][2] });
                }
            }

            bool reachedEnd = false;

            BigInteger count = 0;           

            long[] factors = new long[paths.Count];

            for (int i = 0; i < paths.Count; i++)
            {
                reachedEnd = false;
                long onePath = 0;

                while (!reachedEnd)
                {
                    foreach (char c in directions)
                    {
                        string[] currentLocation = paths[i];

                        string newNode = null;

                        Tuple<string, string, char> input = 
                            new Tuple<string, string, char>(currentLocation[1], currentLocation[2], c);

                        newNode = GetNodeMemo(input);

                        Tuple<string, string[][]> input2 = 
                            new Tuple<string, string[][]>(newNode, nodesArray);

                        paths[i] = SetNodeMemo(input2);

                        onePath++;

                        if (paths[i][0][2] == 'Z')
                        {
                            reachedEnd = true;
                            break;
                        }
                    }
                }



                factors[i] = onePath;
            }

            reachedEnd = false;

            paths = null;
            bool[] ends = new bool[paths2.Count];
            
            while (!reachedEnd)
            {
                for (int i = 0; i < paths2.Count; i++)
                {
                    bool multiple = true;

                    foreach (long l in factors)
                    {
                        if ((count % l) != 0 )
                        {
                            multiple = false;
                        }
                    }

                    if (!multiple)
                    {
                        break;
                    }

                    Tuple<string[][], long, string, BigInteger, int> tuple =
                        new Tuple<string[][], long, string, BigInteger, int>
                            (nodesArray, factors.Max(), directions, count, i);

                    if (PathEnd(tuple, paths2))
                    {
                        ends[i] = true;
                    }
                    else
                    {
                        ends[i] = false;
                    }

                    
                }

                count += factors.Max();

                reachedEnd = TrueForAll(ends);
            }
            
           
            

            Console.WriteLine(count);
        }

        #region Getting the name of the next node

        public static Func<Tuple<string, string, char>, string> GetNextNode =
                    (tuple => GetNode(tuple));

        public static Func<Tuple<string, string, char>, string> GetNodeMemo =
            GetNextNode.Memoize();

        public static string GetNode(Tuple<string, string, char> tuple)
        {
            char c = tuple.Item3;
            string left = tuple.Item1;
            string right = tuple.Item2;
            string newNode = null;

            if (c == 'R')
            {
                newNode = right;
            }
            if (c == 'L')
            {
                newNode = left;
            }

            return newNode;
        }

        #endregion

        #region Getting the next node based on the node

        public static Func<Tuple<string, string[][]>, string[]> SetNodeFunction = 
            x => SetNode(x);

        public static Func<Tuple<string, string[][]>, string[]> SetNodeMemo = 
            SetNodeFunction.Memoize();

        public static string[] SetNode(Tuple<string, string[][]> tuple)
        {

            string[][] nodes = tuple.Item2;
            string nodeName = tuple.Item1;
            string[] thingToReturn = Array.Find(nodes, node => node[0] == nodeName);

            return thingToReturn;
        }

        #endregion

        public static bool PathEnd
            (Tuple<
                string[][], 
                long, 
                string, 
                BigInteger, 
                int> 
            tuple, 
            List<string[]> paths)
        {
            long repetitions = tuple.Item2;
            string directions = tuple.Item3;
            BigInteger count = tuple.Item4;
            string[][] nodesArray = tuple.Item1;
            bool end = false;
            string[] currentLocation = paths[tuple.Item5];

            for (int i = 0; i < count; i++)
            {
                char c = directions[(int)((count + i) % directions.Length)];

                string newNode = null;

                Tuple<string, string, char> input =
                    new Tuple<string, string, char>(currentLocation[1], currentLocation[2], c);

                newNode = GetNodeMemo(input);

                Tuple<string, string[][]> input2 =
                    new Tuple<string, string[][]>(newNode, nodesArray);

                currentLocation = SetNodeMemo(input2);
                paths[tuple.Item5] = currentLocation;
                

            }

            if (currentLocation[0][2] == 'Z')
            {
                end = true;
            }


            return end;
        }


        public static Func<bool[], bool> TempFunc = 
            x => TrueForAll(x);

        public static Func<bool[], bool> TrueForAllMemo =
            TempFunc.Memoize();

        public static bool TrueForAll(bool[] array)
        {
            if (array.ToList().TrueForAll(x => x))
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