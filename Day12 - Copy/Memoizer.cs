using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public static class Memoizer
    {
        public static Func<Tuple<string, int[]>, TResult> Memoize<TInput, TResult>(this Func<Tuple<string, int[]>, TResult> func)
        {
            // create cache ("memo")
            var memo = new Dictionary<Tuple<string, int[]>, TResult>();

            // wrap provided function with cache handling
            return input =>
            {
                // check if result for set input was already cached
                List<Tuple<string, int[]>> dictionary = memo.Keys.ToList();
                bool triedAlready = true;
                string line = input.Item1;

                if (dictionary.Contains(dictionary.Find(x => x.Item1 == line)))
                {
                    triedAlready = true;
                }


                var key = dictionary.Find(x => triedAlready && CheckEquality(x.Item2, input.Item2));
                if(key != null)
                {
                    bool test = memo.TryGetValue(key, out var fromMemo);
                    if (test)
                        // if yes, return value
                        return fromMemo;
                }
                
                
                

                // if no, call function
                var result = func(input);

                // cache the result
                memo.Add(input, result);

                // return it
                return result;
            };
        }

        public static bool CheckEquality(int[] a, int[] b)
        {
            bool matches = true;
            int counter = 0;

            if (a.Length != b.Length)
            {
                matches = false;
            }

            try
            {
                while (a.Length == b.Length
                    && matches)
                {
                    if (a[counter] != b[counter])
                    {
                        matches = false;
                        break;
                    }
                    counter++;
                }
            }
            catch (IndexOutOfRangeException e)
            {

            }

            return matches;
        }
    }
}
