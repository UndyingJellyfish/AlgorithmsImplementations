using System;
using System.Collections.Generic;
using DamsboSoftware.AlgorithmImplementations.Utilities;

namespace DamsboSoftware.AlgorithmImplementations.Sorting
{
    public static class Bogosort<T> where T : IComparable<T>
    {
        public static List<T> PerformSort(List<T> list)
        {
            while (!ListHelpers<T>.ListIsSorted(list))
            {
                var seedGen = new Random();
                ListHelpers<T>.ScrambleList(list, seedGen.Next());
            }

            return list;
        }
    }
}