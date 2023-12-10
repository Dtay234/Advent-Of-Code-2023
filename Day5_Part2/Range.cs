using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Part2
{
    /// <summary>
    /// A class for a range of numbers. Has methods for splitting into multiple different ranges, 
    /// getting overlap, moving a range a certain amount, and if it contains a certain number.
    /// </summary>
    internal class Range
    {
        public long start;
        public long end;

        public long Length
        {
            get { return end - start + 1; }
        }

        public long Start
        {
            get { return start; }
        }

        public Range(long start, long length) 
        {
            
            this.start = start;
            this.end = start + length - 1;

            if (Length == 0)
            {
                throw new Exception("A range cannot have no length.");
            }
        }

        /// <summary>
        /// Split the range into multiple different ranges.
        /// </summary>
        /// <param name="rangestart"></param>
        /// <param name="rangeend"></param>
        /// <returns></returns>
        public Range[] Split(Range range)
        {
            Range[] result = new Range[3];

            if (range.start > start && range.end < end)
            {
                result[0] = (new Range(start, range.start - start));
                result[1] = (new Range(range.start, range.end + 1 - range.start));
                result[2] = (new Range(range.end + 1, end - range.end));
            }
            else if (range.start > start && range.start <= end) 
            {               
                result[0] = (new Range(start, range.start - start));
                result[1] = (new Range(range.start, end - range.start + 1));
                result[2] = (null);
            }     
            else if (range.end < end && range.end >= start)
            {
                result[0] = (null);
                result[1] = (new Range(start, range.end - start + 1));
                result[2] = (new Range(range.end + 1, end - range.end));
            }
            else if (range.start <= start && range.end >= end)
            {
                result[0] = null;
                result[1] = this;
                result[2] = null;
            }
            else
            {
                return null;
            }

            return result;
        }
        /*
        /// <summary>
        /// Get the overlapping range of two ranges.
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public Range GetOverlap(Range range)
        {
            long first;
            long last = range.end;

            if (range.start >= start)
            {
                first = range.start;
            }
            else
            {
                first = start;
            }

            if (range.end <= end)
            {
                last = range.end;
            }
            else
            {
                last = end;
            }

            return new Range(first, last - first + 1);
        }
        */
        public Range Overlap(Range range)
        {
            
            if (Split(range) != null)
                return Split(range)[1];
            else
            {
                return null;
            }


        }

        public void ConvertIDs(Map map, long originalStart)
        {
            long difference = map.sources.Start - originalStart;
            long length = Length;
            start = map.destination - difference;
            end = start + length - 1;
        }

        public void ConvertIDs(Map map)
        {
            long difference = map.sources.Start - start;
            long length = Length;
            start = map.destination - difference;
            end = start + length - 1;
        }

        public bool Contains(long number)
        {
            if (number >= start && number <= end)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            if (Length > 1)
                return $"{start} >> {end}";
            else
                return start.ToString();
        }
    }
}
