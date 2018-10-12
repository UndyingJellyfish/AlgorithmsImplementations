using System;

namespace DamsboSoftware.AlgorithmImplementations.MinimumSpanningTrees
{
    public class KruskalsAlgorithm
    {
        private static int[,] CreateWeightedAdjacencyMatrix(Adjacency adj)
        {
            var dims = adj.n;
            var adjancencies = new int[dims, dims];

            for (var i = 0; i < dims; i++)
            {
                for (var j = 0; j < dims; j++)
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


        private static void QuickSort(int p, int r, int aLength, Edge[] edges)
        {
            int i = p, j = r, m = (i + j) / 2;
            var x = edges[m];

            do
            {
                while (edges[i].Weight < x.Weight)
                    i++;

                while (edges[j].Weight > x.Weight)
                    j--;

                if (i > j) continue;

                var temp = edges[i];
                edges[i] = edges[j];
                edges[j] = temp;
                i++;
                j--;
            }
            while (i <= j);

            if (p < j)
                QuickSort(p, j, aLength, edges);

            if (i < r)
                QuickSort(i, r, aLength, edges);
        }

        public static Pair[] KruskalMst(int n, Adjacency adjacency)
        {
            int i, j, k, l, m, u, v;
            int ULength, count = 0;
            var U = new int[n];
            var SLength = new int[n];
            var S = new int[n, n];
            var A = new Pair[n * n];

            var aLength = 0;

            for (v = 0; v < n; v++)
            {
                SLength[v] = 1;
                S[v, 0] = v;
            }

            for (u = 0; u < n - 1; u++)
                for (v = u + 1; v < n; v++)
                    if (adjacency.getElementAt(u, v))
                        count++;

            var edges = new Edge[count];

            for (i = 0; i < count; i++)
                edges[i] = new Edge();

            for (i = u = 0; u < n - 1; u++)
            {
                for (v = u + 1; v < n; v++)
                {
                    if (!adjacency.getElementAt(u, v)) continue;
                    edges[i].U = u;
                    edges[i].V = v;
                    edges[i++].Weight = adjacency.getWeight(u, v);
                }
            }

            QuickSort(0, count - 1, aLength, edges);

            for (i = 0; i < count; i++)
            {
                int jIndex = -1, lIndex = -1;

                u = edges[i].U;
                v = edges[i].V;

                bool uFound;
                for (uFound = false, j = 0; !uFound && j < n; j++)
                {
                    for (k = 0; !uFound && k < SLength[j]; k++)
                    {
                        uFound = u == S[j, k];
                        if (uFound)
                            jIndex = j;
                    }
                }
                bool vFound;
                for (vFound = false, l = 0; !vFound && l < n; l++)
                {
                    for (m = 0; !vFound && m < SLength[l]; m++)
                    {
                        vFound = v == S[l, m];
                        if (vFound)
                            lIndex = l;
                    }
                }

                if (jIndex == lIndex) continue;
                var pair = new Pair(u, v);

                for (j = 0; j < aLength; j++)
                    if (A[j].Equals(pair))
                        break;
                if (j == aLength)
                    A[aLength++] = pair;

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


            return A;
        }

        public static void PrintKruskalMst(Pair[] kruskalResult)
        {
            foreach (var p in kruskalResult)
            {
                if (p != null)
                {
                    Console.WriteLine(p.ToString() + "\r");
                }
            }
        }

        public static void CalculateAndPrintKruskalMst(int n, Adjacency adjacency, out Pair[] pairs)
        {
            pairs = KruskalMst(n, adjacency);
            PrintKruskalMst(pairs);
        }
    }
}
