using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    public class EnumerableHelper<T> where T : IComparable<T>
    {
        public static bool ListIsSorted(IEnumerable<T> list) => list.Zip(list.Skip(1), (curr, next) => curr.CompareTo(next) <= 0).All(x => x);
        
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

        public static string PrettyPrintList(object list)
        {
            if (list.GetType().IsInstanceOfType(typeof(IEnumerable))) return "";
            var output = $"{{ ";
            var sb = new StringBuilder();
            foreach (var item in (IEnumerable) list)
            {
                if (item is IEnumerable)
                {
                    sb.Append(PrettyPrintList(item));
                    sb.Append(" ");
                }
                else
                {
                    sb.Append(item.ToString());
                    sb.Append(" ");
                }
            }

            output += sb.ToString();
            output += $"}}";
            return output;
        }

        public static string PrettyPrintArray(T[] arr)
        {
            return PrettyPrintList(arr.ToList());
        }

        public static string PrettyPrintMatrix(T[,] mat)
        {
            var list = new List<List<T>>();
            for (var i = 0; i < mat.GetLength(0); i++)
            {
                var temp = new T[mat.GetLength(1)];
                for (int n = 0; n < temp.Length; n++)
                {
                    temp[n] = mat[i, n];
                }

                list.Add(temp.ToList());
            }
            return PrettyPrintList(list);
        }
    }
}