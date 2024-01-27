using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day18
{
    internal class Side
    {
        public int[] startPos;
        public int[] endPos;

        public Side(int[] startPos, int[] endPos)
        {
            this.startPos = startPos;
            this.endPos = endPos;
        }

        public int maxX
        { 
            get
            {
                return Math.Max(startPos[0], endPos[0]);
            }
        }

        public int maxY
        {
            get
            {
                return Math.Max(startPos[1], endPos[1]);
            }
        }

        public int minX
        {
            get
            {
                return Math.Min(startPos[0], endPos[0]);
            }
        }

        public int minY
        {
            get
            {
                return Math.Min(startPos[1], endPos[1]);
            }
        }

        public List<Point> GetPoints()
        {
            List<Point> points = new List<Point>();

            if (endPos[0] - startPos[0] > 0) 
            {
                for (int i = 0; i < maxX - minX + 1; i++)
                {
                    points.Add(new Point(startPos[0] + i, maxY));
                }
            }
            else if (endPos[0] - startPos[0] < 0)
            {
                for (int i = 0; i > minX - maxX - 1; i--)
                {
                    points.Add(new Point(startPos[0] + i, maxY));
                }
            }
            else if (endPos[1] - startPos[1] > 0) 
            { 
                for (int i = 0; i < maxY - minY + 1; i++)
                {
                    points.Add(new Point(startPos[0], startPos[1] + i));
                }
            }
            else
            {
                for (int i = 0; i > minY - maxY - 1; i--)
                {
                    points.Add(new Point(startPos[0], startPos[1] + i));
                }
            }

            return points;
        }
 
        public override string ToString()
        {
            return $"{startPos[0]}, {startPos[1]} >> {endPos[0]}, {endPos[1]}";
        }
    }
}
