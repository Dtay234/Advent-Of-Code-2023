namespace Day6_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            string[] timesString = lines[0].Split(':')[1].Split(' ');
            

            string[] distanceStrings = lines[1].Split(':')[1].Split(' ');

            string timeString = "";
            string distanceString = "";

            foreach ( string s in timesString )
            {
                timeString += s;
            }

            foreach ( string s in distanceStrings )
            {
                distanceString += s;
            }

            long timeRecord = int.Parse(timeString);
            long distanceRecord = long.Parse(distanceString);

            long waysToWin = 0;
            for (int j = 0; j <= timeRecord; j++)
            {
                long speed = j;
                long time = timeRecord - j;

                long distance = time * speed;

                
                if (distance > distanceRecord)
                {
                    waysToWin++;
                }
            }

            Console.WriteLine($"Number of ways to win: {waysToWin}");
        }
    }
}