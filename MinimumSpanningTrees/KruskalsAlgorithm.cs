using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTrees
{
    public class KruskalsAlgorithm
    {
        private static int[,] createWeightedAdjacencyMatrix(Adjacency adj)
        {
            int dims = adj.n;
            int[,] adjancencies = new int[dims, dims];

            for (int i = 0; i < dims; i++)
            {
                for (int j = 0; j < dims; j++)
                {
                    adjancencies[i, j] = adj.getWeight(i, j);
                    if (!adj.getElementAt(i,j))
                    {
                        adjancencies[i, j] = int.MaxValue;
                    }
                }
            }
            return adjancencies;
        }


        private static void quickSort(int p, int r, int aLength, Edge[] edges)
        {
            int i = p, j = r, m = (i + j) / 2;
            Edge x = edges[m];

            do
            {
                while (edges[i].Weight < x.Weight)
                    i++;

                while (edges[j].Weight > x.Weight)
                    j--;

                if (i <= j)
                {
                    Edge temp = edges[i];

                    edges[i] = edges[j];
                    edges[j] = temp;
                    i++;
                    j--;
                }
            }
            while (i <= j);

            if (p < j)
                quickSort(p, j, aLength, edges);

            if (i < r)
                quickSort(i, r, aLength, edges);
        }

        public static Pair[] kruskalMST(int n, Adjacency adjacency)
        {
            bool uFound, vFound;
            int i, j, k, l, m, u, v;
            int ULength, count = 0;
            int[] U = new int[n];
            int[] SLength = new int[n];
            int[,] S = new int[n, n];
            Pair[] A = new Pair[n * n];

            int ALength = 0;

            for (v = 0; v < n; v++)
            {
                SLength[v] = 1;
                S[v, 0] = v;
            }

            for (u = 0; u < n - 1; u++)
                for (v = u + 1; v < n; v++)
                    if (adjacency.getElementAt(u, v))
                        count++;

            Edge[] edges = new Edge[count];

            for (i = 0; i < count; i++)
                edges[i] = new Edge();

            for (i = u = 0; u < n - 1; u++)
            {
                for (v = u + 1; v < n; v++)
                {
                    if (adjacency.getElementAt(u, v))
                    {
                        edges[i].U = u;
                        edges[i].V = v;
                        edges[i++].Weight = adjacency.getWeight(u, v);
                    }
                }
            }

            quickSort(0, count - 1, ALength, edges);

            for (i = 0; i < count; i++)
            {
                int jIndex = -1, lIndex = -1;

                u = edges[i].U;
                v = edges[i].V;

                for (uFound = false, j = 0; !uFound && j < n; j++)
                {
                    for (k = 0; !uFound && k < SLength[j]; k++)
                    {
                        uFound = u == S[j, k];
                        if (uFound)
                            jIndex = j;
                    }
                }
                for (vFound = false, l = 0; !vFound && l < n; l++)
                {
                    for (m = 0; !vFound && m < SLength[l]; m++)
                    {
                        vFound = v == S[l, m];
                        if (vFound)
                            lIndex = l;
                    }
                }

                if (jIndex != lIndex)
                {
                    Pair pair = new Pair(u, v);

                    for (j = 0; j < ALength; j++)
                        if (A[j].Equals(pair))
                            break;
                    if (j == ALength)
                        A[ALength++] = pair;

                    ULength = SLength[jIndex];

                    for (u = 0; u < ULength; u++)
                        U[u] = S[jIndex, u];

                    for (u = 0; u < SLength[lIndex]; u++)
                    {
                        v = S[lIndex, u];

                        for (vFound = false, j = 0; j < ULength; j++)
                            vFound = v == U[j];

                        if (!vFound)
                            U[ULength++] = v;
                    }

                    SLength[jIndex] = ULength;

                    for (j = 0; j < ULength; j++)
                        S[jIndex, j] = U[j];
                    SLength[lIndex] = 0;
                }
            }


            return A;
        }

        public static void printKruskalMST(Pair[] kruskalResult)
        {
            for (int i = 0; i < kruskalResult.Length; i++)
            {
                if (kruskalResult[i] != null)
                {
                    Console.WriteLine(kruskalResult[i].ToString() + "\r");
                }
            }
        }

        public static void calculateAndPrintKruskalMST(int n, Adjacency adjacency, out Pair[] pairs)
        {
            pairs = kruskalMST(n, adjacency);
            printKruskalMST(pairs);
        }
    }
}
