using System;
using System.Collections.Generic;
using DamsboSoftware.AlgorithmImplementations.Utilities;

namespace DamsboSoftware.AlgorithmImplementations.Sorting
{
    public class QuickSort<T> where T : struct,  IComparable<T>
    {
        //private const int InsertionCutoff = 8;
        //private const int Median3Cutoff = 3 * InsertionCutoff;
        
        public static void Sort(List<T> list)
        {
            if (list.Count == 0) return;
            EnumerableHelper<T>.ScrambleList(list, 0, list.Count - 1);
            QuicksortIterative(list);
        }

        public static void QuicksortIterative(List<T> ints)
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
    }
}