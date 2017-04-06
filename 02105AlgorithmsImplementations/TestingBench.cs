using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace _MainNamespace
{
    class TestingBench
    {
        static void Main(string[] args)
        {

            int V = 5;
             
            int[,] graph = new int[,] {{0, 2, 0, 6, 0},
                                    {2, 0, 3, 8, 5},
                                    {0, 3, 0, 0, 7},
                                    {6, 8, 0, 0, 9},
                                    {0, 5, 7, 9, 0},
                                   };
            MinimumSpanningTrees.PrimsAlgorithm.primMST(graph, V);




            Console.ReadLine();

        }
    }
}
