namespace Day8_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string directions = lines[0];

            List<Node> nodes = new List<Node>();
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

                nodes.Add(new Node(split[0], leftRight));

            }

            Node end = null;

            foreach (Node node in nodes)
            {
                if (node.name == "ZZZ")
                {
                    end = node;
                    break;
                }
            }

            Node current = null;

            foreach (Node node in nodes)
            {
                if (node.name == "AAA")
                {
                    current = node;
                    break;
                }
            }

            int count = 0;

            while (current != end)
            {
                foreach (char c in directions)
                {
                    string newNode = null;

                    if (c == 'R')
                    {
                        newNode = current.leftRight[1];
                    }
                    if (c == 'L')
                    {
                        newNode = current.leftRight[0];
                    }

                    foreach (Node node in nodes)
                    {
                        if (node.name == newNode)
                        {
                            current = node;
                            break;
                        }
                    }

                    count++;
                }
            }

            Console.WriteLine(count);
        }
    }
}