using System;
using System.Collections.Generic;

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


        public static int MostDivisibleNumber(int min, int max, out List<int> maxDivisors)
        {
            // will pick the lowest number if there are more numbers with the same amount of divisors
            maxDivisors = new List<int>();
            var mostDivisible = int.MinValue;
            for (var i = min; i <= max; i++)
            {
                var currDivisors = GetListOfDivisors(i);
                if (currDivisors.Count <= maxDivisors.Count) continue;

                mostDivisible = i;
                maxDivisors = currDivisors;
            }

            return mostDivisible;
        }
        public static int MostDivisibleNumber(int min, int max)
        {
            return MostDivisibleNumber(min, max, out var ignored);
        }

        public static int MostDivisibleNumber(int max, out List<int> maxDivisors)
        {
            return MostDivisibleNumber(0, max, out maxDivisors);
        }

        public static int MostDivisibleNumber(int max)
        {
            return MostDivisibleNumber(0, max);
        }
    }
}
