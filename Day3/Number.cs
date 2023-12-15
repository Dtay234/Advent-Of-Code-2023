using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Number
    {
        public int value;
        public int line;
        public List<int> indices;

        public Number(string number, int line, int index) 
        { 
            value = int.Parse(number);
            this.line = line;
            indices = new List<int>();

            for (int i = 0; i < number.Length; i++)
            {
                indices.Add(index + i);
            }
        }

        public bool IsAdjacent(int line, int index)
        {
            bool adjacent = false;

            if (Math.Abs(line - this.line) <= 1)
            {
                foreach (int i in indices)
                {
                    if (Math.Abs(index - i) <= 1)
                    {
                        adjacent = true;
                    }
                }
            }

            return adjacent;
        }
    }
}
