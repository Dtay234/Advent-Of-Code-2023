using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day8_Part2
{
    internal static class Memoizer
    {
        public static Func<TInput, TResult> Memoize<TInput, TResult>(this Func<TInput, TResult> func)
        {
            // create cache ("memo")
            var memo = new Dictionary<TInput, TResult>();
            

            // wrap provided function with cache handling
            return input =>
            {
                // check if result for set input was already cached

                    bool test = memo.TryGetValue(input, out var fromMemo);
                    if (test)
                        // if yes, return value
                        return fromMemo;




                // if no, call function
                var result = func(input);

                // cache the result
                memo.Add(input, result);

                // return it
                return result;
            };
        }
    }
}
