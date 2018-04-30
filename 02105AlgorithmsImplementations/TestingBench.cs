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
            int V = 9;
            /*
            int[,] graph = new int[,] {{0, 2, 0, 6, 0},
                                    {2, 0, 3, 8, 5},
                                    {0, 3, 0, 0, 7},
                                    {6, 8, 0, 0, 9},
                                    {0, 5, 7, 9, 0},
                                   };
            MinimumSpanningTrees.PrimsAlgorithm.primMST(graph, V);
            */
            MinimumSpanningTrees.Adjacency adjacency = new MinimumSpanningTrees.Adjacency(9);

            adjacency.setElementAt(true, 0, 1);
            adjacency.setElementAt(true, 0, 7);
            adjacency.setElementAt(true, 1, 2);
            adjacency.setElementAt(true, 1, 7);
            adjacency.setElementAt(true, 2, 3);
            adjacency.setElementAt(true, 2, 5);
            adjacency.setElementAt(true, 2, 8);
            adjacency.setElementAt(true, 3, 4);
            adjacency.setElementAt(true, 3, 5);
            adjacency.setElementAt(true, 4, 5);
            adjacency.setElementAt(true, 5, 6);
            adjacency.setElementAt(true, 6, 7);
            adjacency.setElementAt(true, 6, 8);
            adjacency.setElementAt(true, 7, 8);
            adjacency.setWeight(0, 1, 4);
            adjacency.setWeight(0, 7, 8);
            adjacency.setWeight(1, 2, 3);
            adjacency.setWeight(1, 7, 11);
            adjacency.setWeight(2, 3, 7);
            adjacency.setWeight(2, 5, 5);
            adjacency.setWeight(2, 8, 2);
            adjacency.setWeight(3, 4, 9);
            adjacency.setWeight(3, 5, 14);
            adjacency.setWeight(4, 5, 10);
            adjacency.setWeight(5, 6, 12);
            adjacency.setWeight(6, 7, 1);
            adjacency.setWeight(6, 8, 6);
            adjacency.setWeight(7, 8, 13);

            int[,] adjacencyMatrix = _02105AlgorithmsImplementations.TestingDataMST.createTestingAdjacencyMatrix();


            MinimumSpanningTrees.Pair[] kruskalMST = new MinimumSpanningTrees.Pair[V];
            Console.WriteLine("Kruskal MST:");
            MinimumSpanningTrees.KruskalsAlgorithm.calculateAndPrintKruskalMST(V, adjacency, out kruskalMST);

            Console.WriteLine("Prim MST:");
            MinimumSpanningTrees.PrimsAlgorithm.PrimMst(adjacencyMatrix, V);

            Console.ReadLine();

        }
    }
}
