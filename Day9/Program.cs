using System.Text.RegularExpressions;

namespace Day9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");


            int totalForwards = 0;
            int totalBackwards = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                int[] data = Array.ConvertAll(Regex.Split(lines[i], " ")
                    .Where(s => !string.IsNullOrEmpty(s)).ToArray(), item => int.Parse(item));

                List<int> lastElement = new List<int>();
                List<int> firstElement = new List<int>();

                while (!data.All(i => int.Equals(data[0], i)))
                {
                    int[] differences = new int[data.Length - 1];

                    for (int j = 0; j < data.Length - 1; j++)
                    {
                        differences[j] = data[j + 1] - data[j];
                    }

                    lastElement.Add(data.Last());
                    firstElement.Add(data[0]);

                    data = differences;
                }

                lastElement.Add(data.Last());
                firstElement.Add(data[0]);

                while (lastElement.Count > 1)
                {
                    lastElement[^2] += lastElement[^1];
                    lastElement.RemoveAt(lastElement.Count - 1);
                }

                while (firstElement.Count > 1)
                {
                    firstElement[^2] -= firstElement[^1];
                    firstElement.RemoveAt(firstElement.Count - 1);
                }

                totalForwards += lastElement[0];
                totalBackwards += firstElement[0];
            }

            Console.WriteLine("Total of end predictions: " + totalForwards);
            Console.WriteLine("Total of start predictions: " + totalBackwards);

            //Incorrect answers: 1854 (high)
        }
    }
}