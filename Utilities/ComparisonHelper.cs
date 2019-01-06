using System;
using System.Collections.Generic;
using System.Linq;

namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    public class ComparisonHelper<T> where T : IComparable
    {
        public static bool EqualToAtLeastOne(T x, IEnumerable<T> xs)
        {
            return xs.Any(elem => x.Equals(elem));
        }

        public static bool DifferentFromAll(T x, IEnumerable<T> xs)
        {
            return !EqualToAtLeastOne(x, xs);
        }

        public static T Max(IEnumerable<T> list)
        {
            return list.Max(x => x);
        }
    }
}