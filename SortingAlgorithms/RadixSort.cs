using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    public class RadixSort
    {
        private const int Base = 10;
        public static List<int> Sort(List<int> ints)
        {
            var intsBuckets = new List<List<int>>(Base);

            for (var i = 0; i < Base; i++)
            {
                intsBuckets.Add(new List<int>());
            }

            var max = ints.Concat(new[] {0}).Max();

            var index = 0;

            for (var pow = 1; max / pow != 0; pow *= max)
            {
                foreach (var bucket in intsBuckets)
                {
                    foreach (var i in bucket)
                    {
                        ints[index++] = i;
                    }
                }
            }

            foreach (var bucket in intsBuckets)
            {
                bucket.Clear();
            }

            return ints;
        }
    }
}