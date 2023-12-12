using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
            string symbols = "@#$%&*/+=-";
            string[] nums = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            //List<int> numbers = new List<int>();
            int total = 0;
            //List<Gear> gears = new List<Gear>();

            /*
            char[,] input = new char[lines.Length, lines[0].Length];

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    input[i, j] = lines[i][j];
                }
            }
            */

            int[][] numbers = new int[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] numStrings = Regex.Split(lines[i], @"\D+").Where(s => !string.IsNullOrEmpty(s)).ToArray(); 

                numbers[i] = new int[numStrings.Length];

                

                for (int j = 0; j < numStrings.Length; j++)
                {

                    numbers[i][j] = int.Parse(numStrings[j]);
                }
            }
            

            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[0].Length; j++)
                {
                    int adjacentNums = 0;

                    
                }
            }
            /*
            foreach (int i in numbers)
            {
                total += i;
            }
            Console.WriteLine(total);

            int gearTotal = 0;

            foreach (Gear g in gears)
            {
                if (g.adjacent == 2)
                {
                    gearTotal += g.gearRatio;
                }
            }
            

            Console.WriteLine(gearTotal);
            */
        }
    }
}