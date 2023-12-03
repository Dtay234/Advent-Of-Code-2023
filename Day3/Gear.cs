using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    internal class Gear
    {
        public int adjacent;
        public int line;
        public int character;
        public int gearRatio;

        public Gear(int line, int character) 
        { 
            adjacent = 0;
            this.line = line;
            this.character = character;
            gearRatio = 1;
        }
    }
}
