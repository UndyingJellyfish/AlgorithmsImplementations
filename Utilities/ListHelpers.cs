using System;
using System.Collections.Generic;
using System.Linq;

namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    public class ListHelpers<T> where T : IComparable<T>
    {
        public static bool ListIsSorted(List<T> list) => list.Zip(list.Skip(1), (curr, next) => curr.CompareTo(next) <= 0).All(x => x);
        

        public static List<T> ScrambleList(List<T> list, int? seed = null)
        {
            var rnd = seed.HasValue ? new Random(seed.GetValueOrDefault()) : new Random();

            for (var i = 0; i < list.Count; i++)
            {
                var index = rnd.Next(0, list.Count - 1);
                var temp = list[i];
                list[i] = list[index];
                list[index] = temp;
            }

            return list;
        }
    }
}