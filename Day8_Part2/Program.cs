using System.Linq;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Day8_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string directions = lines[0];

            //List<Node> nodes = new List<Node>();
            Node[] nodes = new Node[lines.Length - 2];
            string[,] nodesArray = new string[lines.Length - 2, 3];
            string[] destinations = new string[lines.Length - 2];

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

                nodesArray[i - 2, 0] = split[0];
                nodesArray[i - 2, 1] = leftRight[0];
                nodesArray[i - 2, 2] = leftRight[1];
                //nodes.Add(new Node(split[0], leftRight));
                //nodes[i - 2] = new Node(split[0], leftRight);

            }

            for (int i = 0; i < nodesArray.GetLength(0); i++)
            {
                destinations[i] = nodesArray[i, 0];
            }
            List<Node> paths = new List<Node>();

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
                
                
                    if (nodesArray[i, 0][2] == 'A')
                    {
                        paths.Add(new Node(nodesArray[i, 0], new string[] { nodesArray[i, 1], nodesArray[i, 2] }));
                    }
                
            }

            bool reachedEnd = false;

            long count = 0;

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
                        Node currentLocation = paths[i];

                        string newNode = null;

                        if (c == 'R')
                        {
                            newNode = currentLocation.leftRight[1];
                        }
                        if (c == 'L')
                        {
                            newNode = currentLocation.leftRight[0];
                        }
                        /*
                        foreach (Node node in nodes)
                        {
                            if (node.name == newNode)
                            {
                                paths[i] = node;
                                break;
                            }
                        }
                        */

                        int index = Array.IndexOf(destinations, newNode);
                        paths[i] = new Node(nodesArray[index, 0], new string[] { nodesArray[index, 1], nodesArray[index, 2] });
                            //Array.Find(nodes, node => node.name == newNode);
                    }

                    count++;

                    reachedEnd = false;

                    

                    if (paths.TrueForAll(node => node.name[2] == 'Z'))
                    {
                        reachedEnd = true;
                        break;
                    }
                }

            }

            Console.WriteLine(count);
        }
    }
}