using System.Drawing;
using System.Text.RegularExpressions;

namespace Day18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../test.txt");
            Hole hole = new Hole();

            for (int i = 0; i < lines.Length; i++)
            {
                string[] splitLine = lines[i].Split(' ');


                hole.AddSide(splitLine[2]);
            }

            int maxX;
            int maxY;
            int minX;
            int minY;
            List<Side> sides = hole.sides;

            hole.sides = hole.sides.OrderBy(x => x.maxX).ToList();
            maxX = hole.sides.Last().maxX;
            hole.sides = hole.sides.OrderBy(x => x.maxY).ToList();
            maxY = hole.sides.Last().maxY;
            hole.sides = hole.sides.OrderByDescending(x => x.minX).ToList();
            minX = hole.sides.Last().minX;
            hole.sides = hole.sides.OrderByDescending(x => x.minY).ToList();
            minY = hole.sides.Last().minY;

            hole.sides = sides;

            int total = 0;

            for (int j = maxY; j >= minY; j--)
            {
                for (int i = minX; i <= maxX; i++)
                {
                    if (hole.IsInsidePolygon(new Point(i, j)))
                    {
                        total++;
                        //Console.Write('#');
                    }
                    else
                    {
                        //Console.Write(".");
                    }
                }
                //Console.WriteLine();
            }
            Console.WriteLine(total);
        }      
        
    }
}