﻿using System;
using System.Collections.Generic;
using System.Linq;
using Utilities;

namespace SortingAlgorithms
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
            var max = ints.Concat(new[] { 0 }).Max();

            for (var power = 1; max / power != 0; power = power * Base)
            {
                foreach (var val in ints)
                {
                    intsBuckets[val / power % Base].Add(val);
                }
                var index = 0;

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
        private Calculator<T> _c => Calculator;
        
        public RadixSort(Calculator<T> calc)
        {
            this.Calculator = calc;
        }
        
        public List<T> Sort(List<T> list)
        {
            var buckets = new List<List<T>>(Base);

            for (var i = 0; i < Base; i++)
            {
                buckets.Add(new List<T>());
            }
            var max = list.Concat(new[] { default(T) }).Max();
            var index = 0;

            var startValue = _c.Add(default(T), (T) Convert.ChangeType(1, typeof(T)));

            for (var pow = startValue; ! _c.Div(max, pow).Equals(GenericConversions<T>.Generify(0)); pow = _c.Mult(pow, max))
            {
                foreach (var bucket in buckets)
                {
                    foreach (var i in bucket)
                    {
                        list[index++] = i;
                    }
                }
            }

            return list;
        }
    }
}