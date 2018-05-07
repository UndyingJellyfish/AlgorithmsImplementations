using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTrees
{
    public class PrimsAlgorithm
    {
        // A utility function to find the vertex with minimum key
        // value, from the set of vertices not yet included in MST
        private static int MinKey(int[] key, bool[] mstSet, int vert)
        {
            // Initialize min value
            int min = int.MaxValue, minIndex = -1;

            for (var v = 0; v < vert; v++)
                if (mstSet[v] == false && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }

            return minIndex;
        }

        // A utility function to print the constructed MST stored in
        // parent[]
        private static void PrintMst(int[] parent, int n, int[,] graph, int v)
        {
            Console.WriteLine("Edge   Weight");
            for (var i = 1; i < v; i++)
                Console.WriteLine(parent[i] + " - " + i + "    " +
                                   graph[i,parent[i]]);
        }

        // Function to construct and print MST for a graph represented
        //  using adjacency matrix representation
        public static void PrimMst(int[,] graph, int vert)
        {
            // Array to store constructed MST
            var parent = new int[vert];

            // Key values used to pick minimum weight edge in cut
            var key = new int[vert];

            // To represent set of vertices not yet included in MST
            var mstSet = new bool[vert];

            // Initialize all keys as INFINITE
            for (var i = 0; i < vert; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }

            // Always include first 1st vertex in MST.
            key[0] = 0;     // Make key 0 so that this vertex is
                            // picked as first vertex
            parent[0] = -1; // First node is always root of MST

            // The MST will have V vertices
            for (var count = 0; count < vert - 1; count++)
            {
                // Pick thd minimum key vertex from the set of vertices
                // not yet included in MST
                var u = MinKey(key, mstSet, vert);

                // Add the picked vertex to the MST Set
                mstSet[u] = true;

                // Update key value and parent index of the adjacent
                // vertices of the picked vertex. Consider only those
                // vertices which are not yet included in MST
                for (var v = 0; v < vert; v++)

                    // graph[u][v] is non zero only for adjacent vertices of m
                    // mstSet[v] is false for vertices not yet included in MST
                    // Update the key only if graph[u][v] is smaller than key[v]
                    if (graph[u, v] != 0 && mstSet[v] == false &&
                        graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
            }

            // print the constructed MST
            PrintMst(parent, vert, graph, vert);
        }
    }
}
