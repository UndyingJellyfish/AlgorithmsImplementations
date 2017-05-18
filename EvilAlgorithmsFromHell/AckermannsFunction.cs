using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace EvilAlgorithmsFromHell
{
    public class AckermannsFunction
    {
        private static void Main(string[] args)
        {
            var totalTimeSpent = new TimeSpan();
            var sw = new Stopwatch();

            var timesToRun = 1850;

            for (var i = 0; i < timesToRun; i++)
            {
                Console.WriteLine("Run number {0}", i + 1);
                sw.Start();
                Ackermann(4, 2);
                sw.Stop();
                totalTimeSpent += sw.Elapsed;
                sw.Reset();
            }
            var totalMilliseconds = totalTimeSpent.TotalMilliseconds;
            var averageTimeNanoseconds = (totalMilliseconds * 1000) / timesToRun;

            var averageTimeString = String.Format("{0:n1}", averageTimeNanoseconds);
            var totalTimeString = String.Format("{0:n0}", totalMilliseconds);


            
            Console.WriteLine("Calculation of Ackerman(4,2) took {0} nanoseconds average over {1} runs.\nTotal time spent was {2} milliseconds",
                averageTimeString, timesToRun, totalTimeString);

            Console.ReadLine();
        }

        public static void PrintAckermann(int m, int n)
        {
            Console.WriteLine("Ackerman of m={0}, n={1} is {2}", m, n, Ackermann(m, n));
        }

        public static BigInteger Ackermann(BigInteger m, BigInteger n)
        {
            // https://stackoverflow.com/questions/12186672/how-can-i-prevent-my-ackerman-function-from-overflowing-the-stack
            // this implementation will calculate Ackermann(4,2) in about 1/4 second on an Intel Core i7 4770K standard clock

            var stack = new Stack<BigInteger>();
            stack.Push(m);
            while (stack.Count != 0)
            {
                m = stack.Pop();
                skipStack:  // I know it's bad practice, but optimization-wise this works well
                            // the idea being that we don't have to pop anything if we can find
                            // a well-known value of Ackermann
                            
                /*
                 * typical TV cook cheating, using some very simple permutations in order to reduce stack pressure
                 */
                if (m == 0)
                {
                    n = n + 1;
                }
                else if (m == 1)
                {
                    n = n + 2;
                }
                
                else if (m == 2) //without this the code won't even run; throws out of memory excpetions on stack at 1.5 GB RAM usage
                {
                    n = n * 2 + 3;
                }
                else if (m == 3) // makes 10^3 increase in speed compared to having special cases for only 0, 1 and 2
                {
                    n = BigInteger.Pow(2, (int) n + 3);
                }
                
                // non-standard permutations of Ackermann
                else if (n == 0)
                {
                    --m;
                    n = 1;
                    goto skipStack; // my eyes are burning, but at least my CPU loves me
                }
                else
                {
                    stack.Push(m - 1);
                    --n;
                    goto skipStack;
                }
            }
            return n;
        }

        public static BigInteger StandardAckermann(BigInteger m, BigInteger n)
        {
            if (m == 0 && n == 0) return 1;
            if (m == 0 && n == 1) return 2;
            if (m == 0 && n == 2) return 3;
            if (m == 0 && n == 3) return 4;
            if (m == 0 && n == 4) return 5;
            if (m == 1 && n == 0) return 2;
            if (m == 1 && n == 1) return 3;
            if (m == 1 && n == 2) return 4;
            if (m == 1 && n == 3) return 5;
            if (m == 1 && n == 4) return 6;
            if (m == 2 && n == 0) return 3;
            if (m == 2 && n == 1) return 5;
            if (m == 2 && n == 2) return 7;
            if (m == 2 && n == 3) return 9;
            if (m == 2 && n == 4) return 11;
            if (m == 3 && n == 0) return 5;
            if (m == 3 && n == 1) return 13;
            if (m == 3 && n == 2) return 29;
            if (m == 3 && n == 3) return 61;
            if (m == 3 && n == 4) return 125;


            return 0;
        }

    }
}