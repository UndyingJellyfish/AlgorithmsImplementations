using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DamsboSoftware.AlgorithmImplementations.Utilities;

namespace NumberTheory
{
    public class Divisors
    {
        public static readonly List<ulong> PrimesLessThan100 = new List<ulong>
        {
            2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41,
            43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97
        };

        public static List<ulong> GetListOfDivisors(ulong x)
        {
            var divisors = new List<ulong>();

            for (var i = 1ul; i < x / 2ul + 1ul; i++)
            {
                if (x % i == 0)
                    divisors.Add(i);
            }
            divisors.Add(x);

            return divisors;
        }


        public static async Task<ulong> MostDivisibleNumber(ulong min, ulong max)
        {
            // will pick the lowest number if there are more numbers with the same amount of divisors

            return await Task.Run(() =>
            {
                var maxDivisors = new List<ulong>();
                var mostDivisible = ulong.MinValue;
                for (var i = min; i <= max; i++)
                {
                    Console.WriteLine($"Checking {i}");
                    var currDivisors = GetListOfDivisors(i);
                    if (currDivisors.Count <= maxDivisors.Count) continue;

                    mostDivisible = i;
                    maxDivisors = currDivisors;
                }

                return mostDivisible;
            });
        }
        public static async Task<ulong> MostDivisibleNumber(ulong max)
        {
            return await MostDivisibleNumber(0, max);
        }

        public static async Task<(ulong md, List<ulong> divs)> MostDivisibleNumber()
        {
            const ulong batchSize = 100000;
            var maximum = 4 * batchSize;
            
            var tasks = new List<Task<ulong>>();

            for (var i = 1ul; i * batchSize <= maximum; i++)
            {
                tasks.Add(MostDivisibleNumber((i - 1) * batchSize, i * batchSize));
            }

            var results = await Task.WhenAll(tasks);
            var mostDivisible = ComparisonHelper<ulong>.Max(results);

            return (mostDivisible, GetListOfDivisors(mostDivisible));
        }


        public static List<(ulong n, List<ulong> exponents)> MostDivisibleNumberNew(ulong max, List<(ulong n, List<ulong> exponents)> possibles = null, List<ulong> exponents = null)
        {
            // make sure default of null is not used
            if (possibles == null)
            {
                possibles = new List<(ulong n, List<ulong> exponents)>();
            }
            if (exponents == null)
            {
                exponents = new List<ulong>();
            }

            var length = exponents.Count;

            if (length == PrimesLessThan100.Count) return possibles;

            var n = 1ul;
            var div = 1ul;
            for (var i = 0; i < length; i++)
            {
                n *= (ulong) Math.Pow(PrimesLessThan100[i], exponents[i]);
                div *= exponents[i] + 1ul;
            }

            if (n > max)
            {
                return possibles;
            }
                

            possibles.Add((n, exponents));
            var maxExponent = 100ul;

            if (length >= 1)
            {
                maxExponent = exponents[length - 1];
            }

            for (var e = 1ul; e < maxExponent; e++)
            {
                var exponents_new = new List<ulong>();
                exponents.ForEach(x => exponents_new.Append(x));
                exponents_new.Add(e);
                possibles.AddRange(MostDivisibleNumberNew(max, possibles, exponents_new));
                possibles = possibles.GroupBy(x => new {x.n}).Select(g => g.First()).ToList();
            }

            return possibles;
        }
    }
}
