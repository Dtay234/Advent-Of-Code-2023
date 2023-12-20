using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    abstract internal class Beam
    {
        public abstract bool Energized(int x, int y);
        public abstract bool Equals(Beam other);
    }
}
