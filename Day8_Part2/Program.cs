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

            //List<Node> nodes = new List<Node>();
            //Node[] nodes = new Node[lines.Length - 2];
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
                //nodes.Add(new Node(split[0], leftRight));
                //nodes[i - 2] = new Node(split[0], leftRight);

            }

           
            List<string[]> paths = new List<string[]>();
            List<string[]> paths2 = new List<string[]>();

            //List<Node> ends = new List<Node>();
            /*
            foreach (Node node in nodes)
            {
                if (node.name[2] == 'A')
                {
                    paths.Add(node);
                }
            }*/

            for (int i = 0; i < nodesArray.GetLength(0); i++)
            {
                if (nodesArray[i][0][2] == 'A')
                {
                    paths.Add(new string[] { nodesArray[i][0], nodesArray[i][1], nodesArray[i][2] } );
                    paths2.Add(new string[] { nodesArray[i][0], nodesArray[i][1], nodesArray[i][2] });
                }
            }

            bool reachedEnd = false;

            BigInteger count = 0;
            /*
            while (!reachedEnd)
            {
                foreach (char c in directions)
                {
                    if (reachedEnd)
                    {
                        break;
                    }
                    for (int i = 0; i < paths.Count; i++)
                    {
                        string[] currentLocation = paths[i];

                        string newNode = null;

                        if (c == 'R')
                        {
                            newNode = currentLocation[2];
                        }
                        if (c == 'L')
                        {
                            newNode = currentLocation[1];
                        }
                        paths[i] = Array.Find(nodesArray, node => node[0] == newNode);

                        //int index = Array.IndexOf(destinations, newNode);
                        //paths[i] = new string[] {nodesArray[index, 0], nodesArray[index, 1], nodesArray[index, 2] };
                            //Array.Find(nodes, node => node.name == newNode);
                    }

                    count++;

                    reachedEnd = false;

                    

                    if (paths.TrueForAll(node => node[0][2] == 'Z'))
                    {
                        reachedEnd = true;
                        break;
                    }
                }

            }
            */

            
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

                        if (c == 'R')
                        {
                            newNode = currentLocation[2];
                        }
                        if (c == 'L')
                        {
                            newNode = currentLocation[1];
                        }
                        paths[i] = Array.Find(nodesArray, node => node[0] == newNode);

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

            while (!reachedEnd)
            {
                for (int i = 0; i < factors.Max(); i++)
                {
                    char c = directions[(int)((count + i) % directions.Length)];

                    for (int j = 0; j < paths2.Count; j++)
                    {

                        
                        string[] currentLocation = paths2[j];

                        string newNode = null;

                        if (c == 'R')
                        {
                            newNode = currentLocation[2];
                        }
                        if (c == 'L')
                        {
                            newNode = currentLocation[1];
                        }

                        paths2[j] = Array.Find(nodesArray, node => node[0] == newNode);

                    }

                    //count++;
                }

                count += factors.Max();

                if (paths2.TrueForAll(node => node[0][2] == 'Z'))
                {
                    reachedEnd = true;
                    break;
                }
            }

            foreach (long factor in factors)
            {
                if (count % factor != 0)
                {
                    count *= factor;
                }
            }
            if (count == long.MinValue)
            {
                Console.WriteLine();
            }

            
            Console.WriteLine(count);
        }
    }
}