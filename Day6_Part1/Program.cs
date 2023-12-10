namespace Day6_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            
            string[] timesString = lines[0].Split(':')[1].Split(' ');
            int count = 0;
            int[] times = new int[4];

            for (int i = 0; i < timesString.Length; i++)
            {
                if (timesString[i] != "")
                {
                    times[count] = int.Parse(timesString[i]);
                    count++;
                }
            }

            string[] distanceStrings = lines[1].Split(':')[1].Split(' ');
            count = 0;
            int[] distances = new int[4];

            for (int i = 0; i < distanceStrings.Length; i++)
            {
                if (distanceStrings[i] != "")
                {
                    distances[count] = int.Parse(distanceStrings[i]);
                    count++;
                }
            }

            int[] waysToWin = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int time = times[i];
                int distanceRecord = distances[i];

                for (int j = 0; j <= time; j++)
                {
                    int speed = j;
                    int distance = (time - j) * speed;

                    if (distance > distances[i])
                    {
                        waysToWin[i]++;
                    }
                }
            }

            int product = 1;

            foreach (int i in waysToWin)
            {
                product *= i;
            }

            Console.WriteLine(product);
        }
    }
}