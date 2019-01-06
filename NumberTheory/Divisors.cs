using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DamsboSoftware.AlgorithmImplementations.Utilities;

namespace NumberTheory
{
    public class Divisors
    {
        public static List<int> GetListOfDivisors(int x)
        {
            var divisors = new List<int>();

            for (var i = 1; i < x / 2 + 1; i++)
            {
                if (x % i == 0)
                    divisors.Add(i);
            }
            divisors.Add(x);

            return divisors;
        }


        public static async Task<int> MostDivisibleNumber(int min, int max)
        {
            // will pick the lowest number if there are more numbers with the same amount of divisors

            return await Task.Run(() =>
            {
                var maxDivisors = new List<int>();
                var mostDivisible = int.MinValue;
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
        public static async Task<int> MostDivisibleNumber(int max)
        {
            return await MostDivisibleNumber(0, max);
        }

        public static async Task<(int md, List<int> divs)> MostDivisibleNumber()
        {
            const int batchSize = 100000;
            var maximum = 4 * batchSize;
            
            var tasks = new List<Task<int>>();

            for (var i = 1; i * batchSize <= maximum; i++)
            {
                tasks.Add(MostDivisibleNumber((i - 1) * batchSize, i * batchSize));
            }

            var results = await Task.WhenAll(tasks);
            var mostDivisible = ComparisonHelper<int>.Max(results);

            return (mostDivisible, GetListOfDivisors(mostDivisible));
        }

    }
}
