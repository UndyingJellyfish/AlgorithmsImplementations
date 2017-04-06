using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace _MainNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Let us create the following graph
               2    3
            (0)--(1)--(2)
            |    / \   |
           6|  8/   \5 |7
            |  /     \ |
            (3)-------(4)
                 9          
            */

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
