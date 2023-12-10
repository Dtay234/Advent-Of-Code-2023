using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Part2
{
    internal class Map
    {
        public long destination;
        public Range sources;

        public Map(long destination, Range sources) 
        { 
            this.destination = destination;
            this.sources = sources;
        }

        public override string ToString()
        {
            return $"{destination}, {sources}";
        }
    }


}
