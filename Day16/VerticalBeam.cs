using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    internal class VerticalBeam : Beam
    {
        int x;
        int start;
        int end;

        public VerticalBeam(int x, int start, int end)
        {
            this.x = x;
            this.start = start;
            this.end = end;
        }

        public override bool Energized(int x, int y)
        {
            int start = Math.Min(this.start, this.end);
            int end = Math.Max(this.start, this.end);

            if (x == this.x &&
                (y >= start && y <= end))
            {
                return true;
            }
            else { return false; }
        }

        public override string ToString()
        {
            return $"Vertical: {x}, {start} >> {end}";
        }

        public override bool Equals(Beam other)
        {
            if (other is VerticalBeam)
            {
                VerticalBeam otherBeam = (VerticalBeam)other;
                if (this.x == otherBeam.x &&
                    (this.start == otherBeam.start &&
                    this.end == otherBeam.end))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
