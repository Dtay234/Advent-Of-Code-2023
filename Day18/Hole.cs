using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    internal class Hole
    {
        public List<Side> sides;
        public int[] diggerPos;

        public Hole()
        {
            sides = new List<Side>();
            diggerPos = new int[] { 0, 0 };
        }

        public void AddSide(string[] info)
        {
            int[] startPos = new int[2];
            diggerPos.CopyTo(startPos, 0);
            int[] endPos = new int[2];

            if (info[0] == "U")
            {
                endPos = new int[] { diggerPos[0], diggerPos[1] + int.Parse(info[1]) };
                startPos[1]++;
            }
            else if (info[0] == "D")
            {
                endPos = new int[] { diggerPos[0], diggerPos[1] - int.Parse(info[1]) };
                startPos[1]--;
            }
            else if (info[0] == "L")
            {
                endPos = new int[] { diggerPos[0] - int.Parse(info[1]), diggerPos[1] };
                startPos[0]--;
            }
            else if (info[0] == "R")
            {
                endPos = new int[] { diggerPos[0] + int.Parse(info[1]), diggerPos[1] };
                startPos[0]++;
            }

            sides.Add(new Side(startPos, endPos));
            diggerPos = endPos;

            
        }

        public void AddSide(string info)
        {
            int[] startPos = new int[2];
            diggerPos.CopyTo(startPos, 0);
            int[] endPos = new int[2];
            string instructions = "";
            for (int i = 1; i < 6; i++)
            {
                instructions += ((int)info[i]).ToString();
            }
            int length = int.Parse(instructions);

            if (info[6] == '3')
            {
                endPos = new int[] { diggerPos[0], diggerPos[1] + length };
                startPos[1]++;
            }
            else if (info[6] == '1')
            {
                endPos = new int[] { diggerPos[0], diggerPos[1] - length };
                startPos[1]--;
            }
            else if (info[6] == '2')
            {
                endPos = new int[] { diggerPos[0] - length, diggerPos[1] };
                startPos[0]--;
            }
            else if (info[6] == '0')
            {
                endPos = new int[] { diggerPos[0] + length, diggerPos[1] };
                startPos[0]++;
            }

            sides.Add(new Side(startPos, endPos));
            diggerPos = endPos;
        }

        public bool IsInsidePolygon(Point p)
        {
            List<Point> verticesList = new List<Point>();
            List<Point> pointsList = new List<Point>();

            foreach (Side side in sides)
            {               
                foreach (Point point in side.GetPoints())
                {
                    pointsList.Add(point);
                }
                
                verticesList.Add(new Point(side.endPos[0], side.endPos[1]));
            }

            Point[] vertices = verticesList.ToArray();
           
            bool inside = false;
            int j = vertices.Length - 1;

            
            for (int i = 0; i < vertices.Length; j = i++)
            {

                if (((vertices[i].Y > p.Y) != (vertices[j].Y > p.Y)) &&
                    (p.X < (vertices[j].X - vertices[i].X) * (p.Y - vertices[i].Y) / (vertices[j].Y - vertices[i].Y) + vertices[i].X))
                {
                    inside = !inside;
                }
            }
            
            if (inside == false && pointsList.Contains(p))
            {
                inside = true;
            }
            
            return inside;
        }

    }
}
