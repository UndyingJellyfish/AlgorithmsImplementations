using System;
using System.Collections;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class QuickSort<T> where T : struct,  IComparable<T>
    {
        //private const int InsertionCutoff = 8;
        //private const int Median3Cutoff = 3 * InsertionCutoff;
        
        public static void Sort(IList<T> ints)
        {
            if (ints.Count == 0) return;
            ScrambleArray(ints, 0, ints.Count - 1);
            QuicksortIterative(ints);
        }

        public static void QuicksortIterative(IList<T> ints)
        {
            var stack = new Stack<int>();
            stack.Push(0);
            stack.Push(ints.Count - 1);

            while (stack.Count != 0)
            {
                var high = stack.Pop();
                var low = stack.Pop();
                if (low < high)
                {
                    var pivot = Partition(ints, low, high);
                    stack.Push(low);
                    stack.Push(pivot - 1);
                    stack.Push(pivot + 1);
                    stack.Push(high);
                }
            }
        }


        private static void ScrambleArray(IList<T> ints, int low, int high)
        {
            Random rnd = new Random();
            int n = low;

            for (int i = low; i < high; i++)
            {
                n = low + rnd.Next(high - low + 1);
                Swap(ints, i, n);
            }
        }

        private static int Partition(IList<T> ints, int low, int high)
        {
            var pivot = ints[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (ints[j].CompareTo(pivot) <= 0)
                {
                    i++;
                    Swap(ints, i, j);
                }
            }
            Swap(ints, i + 1, high);
            return i + 1;
        }

        private static void Swap(IList<T> ints, int a, int b)
        {
            var temp = ints[a];
            ints[a] = ints[b];
            ints[b] = temp;
        }

        private static void InsertionSort(IList<T> ints, int low, int high)
        {
            for (int i = low; i <= high; i++)
            for (int j = i; j > low && (ints[j].CompareTo(ints[j - 1]) < 0); j--)
                Swap(ints, j, j - 1);
        }

        private static int Median3(IList<T> ints, int i, int j, int k)
        {
            return ints[i].CompareTo(ints[j]) < 0 ? 
                (ints[j].CompareTo(ints[k]) < 0 ? j : ints[i].CompareTo(ints[k]) < 0 ? k : i) : 
                (ints[k].CompareTo(ints[j]) < 0 ? j : ints[k].CompareTo(ints[i]) < 0 ? k : i);
        }

    }
}