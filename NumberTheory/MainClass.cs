using System;

namespace NumberTheory
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            var (mostDivisible, divisors) = Divisors.MostDivisibleNumber().Result;
            Console.WriteLine($"Most divisible: {mostDivisible}\nNumber of divisors: {divisors.Count}");

            Console.ReadLine();
        }
    }
}