using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace Miscellaneous
{
    public class AckermannsFunction
    {
        
        private static void Main(string[] args)
        {
            var totalTimeSpent = new TimeSpan();
            var sw = new Stopwatch();

            var timesToRun = 1000;

            for (var i = 0; i < timesToRun; i++)
            {
                Console.WriteLine("Run number {0}", i + 1);
                sw.Start();
                Ackermann(4, 2); // don't even think about running A(4,3), it's like a bajillion decimals
                sw.Stop();
                totalTimeSpent += sw.Elapsed;
                sw.Reset();
                if (i % 250 == 0)
                {
                    GC.Collect();
                }
            }
            var totalMilliseconds = totalTimeSpent.TotalMilliseconds;
            var averageTimeNanoseconds = (totalMilliseconds * 1000) / timesToRun;

            var averageTimeString = $"{averageTimeNanoseconds:n1}";
            var totalTimeString = $"{totalMilliseconds:n0}";
            
            Console.WriteLine("Calculation of Ackerman(4,2) took {0} nanoseconds average over {1} runs.\nTotal time spent was {2} milliseconds",
                averageTimeString, timesToRun, totalTimeString);

            //Console.WriteLine(Ackermann(4, 2) == BigInteger.Pow(2, 65536)-3); // known value of Ackerman for testing purposes
            
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
            var skipStack = false;
            while (stack.Count != 0)
            {
                if(!skipStack){
                    m = stack.Pop();
                } 
                skipStack = false;  // I know it's bad practice, but optimization-wise this works well
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
                else if (m == 4) // leads to a 10 times increase, even if the helper method is resursive...
                {
                    n = RecursiveExponent(2, 2, (int)n+3) - 3;
                }
                
                // non-standard permutations of Ackermann
                else if (n == 0)
                {
                    --m;
                    n = 1;
                    skipStack = true; // my eyes are burning, but at least my CPU loves me
                }
                else
                {
                    stack.Push(m - 1);
                    --n;
                    skipStack = true;
                }
            }
            return n;
        }

        private static BigInteger RecursiveExponent(BigInteger x, BigInteger n, int times)
        {
            if (times > 1)
            {
                n = RecursiveExponent(n, n, times - 1);
                x = BigInteger.Pow(x, (int)n);
            }
            return x;
        }

    }
}
