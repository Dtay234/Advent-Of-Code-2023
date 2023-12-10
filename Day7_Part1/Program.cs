using System.Linq;

namespace Day7_Part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string[] lines = File.ReadAllLines("../../../text.txt");
            string labels = "23456789TJQKA";
            //Hand[] hands = new Hand[lines.Length];
            List<Hand> list = new List<Hand>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] parts = line.Split(' ');

                //hands[i] = new Hand(parts[0], int.Parse(parts[1]));
                list.Add(new Hand(parts[0], int.Parse(parts[1])));

            }

            list = list
                .OrderBy(hand => hand.HandRank)
                .ThenBy(h => h.LabelRank[0])
                .ThenBy(h => h.LabelRank[1])
                .ThenBy(h => h.LabelRank[2])
                .ThenBy(h => h.LabelRank[3])
                .ThenBy(h => h.LabelRank[4])
                .ToList();
            //list.Sort((h1, h2) => h1.HandRank.CompareTo(h2.HandRank));

            int totalWinnings = 0;
            foreach (Hand hand in list )
            {
                hand.bet *= list.IndexOf(hand) + 1;
                totalWinnings += hand.bet;
            }

            
            Console.WriteLine("Total winnings: " + totalWinnings);
        }
    }
}