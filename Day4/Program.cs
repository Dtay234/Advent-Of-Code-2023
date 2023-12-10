namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            //StreamWriter writer = new StreamWriter("../../../newCards.txt");
            //StreamReader reader = new StreamReader("../../../newCards.txt");
            string[] newCards = null;

            /* PART 1
            int total = 0;

            foreach (string line in lines)
            {
                string[] splitLine = line.Split('|');
                string[] winners = splitLine[0].Substring(8).Trim().Split(' ');
                string[] numbersHad = splitLine[1].Trim().Split(' ');
                int points = 0;

                foreach (string number in winners) 
                { 
                    if (numbersHad.Contains(number) && number != "")
                    {                      
                        if (points == 0)
                        {
                            points = 1;
                        }
                        else
                        {
                            points *= 2;
                        }
                    }
                }

                total += points;
            }

            Console.WriteLine(total);
            */

            //PART 2

            List<int> cardNumbers = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                cardNumbers.Add(1);
            }

            for (int i = 0; i < lines.Length; i++)
            {
                string thisLine = lines[i];
                string[] splitLine = lines[i].Split('|');
                string[] winners = splitLine[0].Substring(8).Trim().Split(' ');
                string[] numbersHad = splitLine[1].Trim().Split(' ');
                int matches = 0;
                

                foreach (string number in winners)
                {
                    if (numbersHad.Contains(number) && number != "")
                    {
                        matches++;
                    }
                }

                for (int j = 0; j < matches; j++)
                {
                    for (int k = 0; k < cardNumbers[i]; k++)
                    {
                        cardNumbers[1 + i + j]++;
                    }
                }
               

            }

            int sum = 0;
            foreach (int  i in cardNumbers)
            {
                sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}