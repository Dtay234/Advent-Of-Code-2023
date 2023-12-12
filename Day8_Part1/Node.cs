using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Part1
{
    internal class Node
    {
        public string name;
        public string[] leftRight;

        public Node(string name, string[] leftRight) 
        { 
            this.name = name;
            this.leftRight = leftRight;
        }

        public override string ToString()
        {
            return name + " = (" + leftRight[0] + ", " + leftRight[1] + ')';
        }
    }
}
