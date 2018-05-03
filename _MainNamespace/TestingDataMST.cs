using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02105AlgorithmsImplementations
{
    public class TestingDataMst
    {
        public static int[,] createTestingAdjacencyMatrix()
        {
            var V = 9;
            var adjacencyMatrix = new int[V, V];

            #region adjacency adding
            // create adjacencies
            adjacencyMatrix[0, 1] = 4;
            adjacencyMatrix[0, 7] = 8;
            adjacencyMatrix[1, 2] = 3;
            adjacencyMatrix[1, 7] = 11;
            adjacencyMatrix[2, 3] = 7;
            adjacencyMatrix[2, 5] = 5;
            adjacencyMatrix[2, 8] = 2;
            adjacencyMatrix[3, 4] = 9;
            adjacencyMatrix[3, 5] = 14;
            adjacencyMatrix[4, 5] = 10;
            adjacencyMatrix[5, 6] = 12;
            adjacencyMatrix[6, 7] = 1;
            adjacencyMatrix[6, 8] = 6;
            adjacencyMatrix[7, 8] = 13;

            // remember the diagonalised matrix!
            adjacencyMatrix[1, 0] = 4;
            adjacencyMatrix[7, 0] = 8;
            adjacencyMatrix[2, 1] = 3;
            adjacencyMatrix[7, 1] = 11;
            adjacencyMatrix[3, 2] = 7;
            adjacencyMatrix[5, 2] = 5;
            adjacencyMatrix[8, 2] = 2;
            adjacencyMatrix[4, 3] = 9;
            adjacencyMatrix[5, 3] = 14;
            adjacencyMatrix[5, 4] = 10;
            adjacencyMatrix[6, 5] = 12;
            adjacencyMatrix[7, 6] = 1;
            adjacencyMatrix[8, 6] = 6;
            adjacencyMatrix[8, 7] = 13;
            #endregion

            return adjacencyMatrix;
        }
    }
}
