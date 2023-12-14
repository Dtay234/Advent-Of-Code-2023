using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14
{
    internal static class Memoizer
    {
        public static Func<TInput, TResult> Memoize<TInput, TResult>(this Func<TInput, TResult> func)
        {
            var memo = new Dictionary<TInput, TResult>();

            return input =>
            {
                if (memo.TryGetValue(input, out var fromMemo))
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

