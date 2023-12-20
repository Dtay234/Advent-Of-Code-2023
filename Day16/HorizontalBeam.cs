using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    internal class HorizontalBeam : Beam
    {
        int y;
        int start;
        int end;

        public HorizontalBeam(int y, int start, int end)
        {
            this.y = y;
            this.start = start;
            this.end = end;
        }

        public override bool Energized(int x, int y)
        {
            int start = Math.Min(this.start, this.end);
            int end = Math.Max(this.start, this.end);

            if (y == this.y &&
                (x >= start && x <= end))
            {
                return true;
            }
            else { return false; }
        }

        public override string ToString()
        {
            return $"Horizontal: {y}, {start} >> {end}";
        }

        public override bool Equals(Beam other)
        {
            if (other is HorizontalBeam)
            {
                HorizontalBeam otherBeam = (HorizontalBeam) other;
                if (this.y == otherBeam.y &&
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
