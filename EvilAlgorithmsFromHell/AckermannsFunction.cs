using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EvilAlgorithmsFromHell
{
    public class AckermannsFunction
    {
        static void Main(string[] args)
        {
            long totalTimeSpent = 0L;
            Stopwatch sw = new Stopwatch();

            int timesToRun = 666;

            for (int i = 0; i < timesToRun; i++)
            {
                Console.WriteLine("Run number {0}", i+1);
                sw.Start();
                Ackermann(4, 2);
                sw.Stop();
                totalTimeSpent += sw.ElapsedMilliseconds;
                sw.Reset();
            }

            long averageTime = totalTimeSpent / timesToRun;
            
            Console.WriteLine("Calculation of Ackerman(4,2) took {0} milliseconds on average over {1} runs", averageTime, timesToRun);

            Console.ReadLine();
        }

        public static void printAckermann(int m, int n)
        {
            Console.WriteLine("Ackerman of m={0}, n={1} is {2}", m, n, Ackermann(m, n));
        }

        public static BigInteger Ackermann(BigInteger m, BigInteger n)
        {
            // https://stackoverflow.com/questions/12186672/how-can-i-prevent-my-ackerman-function-from-overflowing-the-stack
            // this implementation will calculate Ackermann(4,2) in about 1/4 second on an Intel Core i7 4770K standard clock
            
            Stack<BigInteger> stack = new Stack<BigInteger>();
            stack.Push(m);
            while (stack.Count != 0)
            {
                m = stack.Pop();
                skipStack: // I know it's bad practice, but optimization-wise this works

                /*
                 * typical TV cook cheating, using some very simple permutations in order to reduce stack pressure
                 */
                if (m == 0)
                    n = n + 1;
                else if (m == 1)
                    n = n + 2;
                else if (m == 2)
                    n = n * 2 + 3;

                // non-standard permutations of Ackermann
                else if (n == 0)
                {
                    --m;
                    n = 1;
                    goto skipStack;
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

    }
}
