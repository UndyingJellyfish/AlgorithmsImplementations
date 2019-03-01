using System;
using System.Collections.Generic;

namespace NumberTheory
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var results = Divisors.MostDivisibleNumberNew(10000);
            foreach (var (n, exponents) in results)
            {
                Console.WriteLine($"Possible HCN: {n}");
            }

            Console.ReadLine();
        }
    }
}