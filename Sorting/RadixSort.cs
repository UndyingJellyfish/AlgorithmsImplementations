using System;
using System.Collections.Generic;
using System.Linq;
using Byte;
using Utilities;

namespace Sorting
{
    public class RadixSort
    {
        private const int Base = 10;
        public static List<int> Sort(List<int> ints)
        {
            var intsBuckets = new List<List<int>>(Base);
            for (var i = 0; i < Base; i++) // init buckets
            {
                intsBuckets.Add(new List<int>());
            }
            var max = ints.Concat(new[] { 0 }).Max(); // find maximum value in list

            for (var power = 1; max / power != 0; power = power * Base)
            {
                foreach (var val in ints)
                {
                    // put val into a certain bucket dependent on the value of the given number
                    intsBuckets[val / power % Base].Add(val);
                }

                var index = 0;
                // intermittently sort partial list after putting new things into buckets
                foreach (var bucket in intsBuckets)
                {
                    foreach (var val in bucket)
                    {
                        ints[index++] = val;
                    }
                }
            }
            return ints;
        }
    }
    public class RadixSort<T> where T : struct, IComparable<T>
    {
        private const int Base = 10;
        private Calculator<T> Calculator { get; set; }
        private Calculator<T> C => Calculator;

        /// <summary>
        /// Generifies the specified value to any of the integral or floating point types.
        /// </summary>
        /// <param name="val">The value to be "generified".</param>
        /// <returns>A value of <c>T</c>.</returns>
        private static T Generify(int val) => GenericConversions<T>.Generify(val);
        private T Add(object val1, object val2) => C.Add((T)val1, GenericConversions<T>.Generify(val2));

        /// <summary>
        /// Initializes a new instance of the <see cref="RadixSort{T}"/> class. 
        /// It is very important that the calculator parameter corresponds to the type <c>T</c>, 
        /// otherwise none of the arithmetic functions performed by the sorting algorithm is 
        /// guaranteed to work as intended, resulting in uncertain sorting results.
        /// </summary>
        /// <param name="calc">The calculator for generic arithmetic.</param>
        public RadixSort(Calculator<T> calc)
        {
            this.Calculator = calc;
        }


        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <returns>A sorted list of type <c>T</c>, where <c>T</c> is given by the type parameter.</returns>
        /// <exception cref="NotImplementedException">Radix sort with float, double or decimal is not yet supported, use another sorting algorithm.</exception>
        public List<T> Sort(List<T> list)
        {
            // TODO: This might help: https://stackoverflow.com/questions/2685035/is-there-a-good-radixsort-implementation-for-floats-in-c-sharp
            // otherwise this might: https://webcache.googleusercontent.com/search?q=cache:DPuhAHY36CAJ:https://gist.github.com/StagPoint/44aebfb6960c3f5fdd6f25862827ec43+&cd=4&hl=en&ct=clnk&gl=dk
            if (typeof(T) == typeof(float) || typeof(T) == typeof(double) || typeof(T) == typeof(decimal))
            {
                throw new NotImplementedException("Radix sort with float, double or decimal is not yet supported, use another sorting algorithm.");
            }

            var buckets = new List<List<T>>(Base);
            for (var i = 0; i < Base; i++) // initialize buckets
            {
                buckets.Add(new List<T>());
            }
            var max = list.Concat(new[] { default(T) }).Max(); //find maximum value in list

            for (var pow = Add(default(T), 1); !C.Div(max, pow).Equals(Generify(0)); pow = C.Mult(pow, Generify(Base)))
            {
                foreach (var val in list)
                {
                    // put val into a certain bucket dependent on the value of the given number
                    var tempIndex = (int) Convert.ChangeType(C.Div(val, pow), typeof(int)) % Base;
                    buckets[tempIndex].Add(val);
                }

                var index = 0;
                // intermittently sort partial list after putting new things into buckets
                foreach (var bucket in buckets) 
                {
                    foreach (var val in bucket)
                    {
                        list[index++] = val;
                    }
                }
            }
            return list;
        }
    }
}