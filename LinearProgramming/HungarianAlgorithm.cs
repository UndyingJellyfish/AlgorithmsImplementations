using System;

namespace LinearProgramming
{
    public static class HungarianAlgorithm
    {
        

        public static int[] FindAssignments(this int[,] costs)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            var rowCount = costs.GetLength(0);
            var colCount = costs.GetLength(1);

            for (var i = 0; i < rowCount; i++)
            {
                var min = int.MaxValue;

                for (var j = 0; j < colCount; j++)
                {
                    min = Math.Min(min, costs[i, j]);
                }

                for (var j = 0; j < colCount; j++)
                {
                    costs[i, j] -= min;
                }
            }

            var masks = new byte[rowCount, colCount];
            var rowsCovered = new bool[rowCount];
            var colsCovered = new bool[colCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                    {
                        masks[i, j] = 1;
                        rowsCovered[i] = true;
                        colsCovered[j] = true;
                    }
                }
            }

            ClearCovers(rowsCovered, colsCovered, colCount, rowCount);

            var path = new Location[colCount * rowCount];
            var pathStart = default(Location);
            var step = HungarianStep.Step1;

            while (step != HungarianStep.None)
            {
                switch (step)
                {
                    case HungarianStep.Step1:
                        step = RunStep1(masks, colsCovered, colCount, rowCount);
                        break;

                    case HungarianStep.Step2:
                        step = RunStep2(costs, masks, rowsCovered, colsCovered, colCount, rowCount, ref pathStart);
                        break;

                    case HungarianStep.Step3:
                        step = RunStep3(masks, rowsCovered, colsCovered, colCount, rowCount, path, pathStart);
                        break;

                    case HungarianStep.Step4:
                        step = RunStep4(costs, rowsCovered, colsCovered, colCount, rowCount);
                        break;
                }
            }

            var agentsTasks = new int[rowCount];

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (masks[i, j] != 1) continue;
                    agentsTasks[i] = j;
                    break;
                }
            }

            return agentsTasks;
        }

        private static HungarianStep RunStep1(byte[,] masks, bool[] colsCovered, int w, int h)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    if (masks[i, j] == 1)
                        colsCovered[j] = true;
                }
            }

            var colsCoveredCount = 0;

            for (var j = 0; j < w; j++)
            {
                if (colsCovered[j])
                    colsCoveredCount++;
            }

            return colsCoveredCount == h ? HungarianStep.None : HungarianStep.Step2;
        }
        private static HungarianStep RunStep2(int[,] costs, byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount, ref Location pathStart)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            while (true)
            {
                var loc = FindZero(costs, rowsCovered, colsCovered, colCount, rowCount);
                if (loc.Row == -1)
                    return HungarianStep.Step4;

                masks[loc.Row, loc.Column] = 2;

                var starCol = FindStarInRow(masks, colCount, loc.Row);
                if (starCol != -1)
                {
                    rowsCovered[loc.Row] = true;
                    colsCovered[starCol] = false;
                }
                else
                {
                    pathStart = loc;
                    return HungarianStep.Step3;
                }
            }
        }
        private static HungarianStep RunStep3(byte[,] masks, bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount, Location[] path, Location pathStart)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var pathIndex = 0;
            path[0] = pathStart;

            while (true)
            {
                var row = FindStarInColumn(masks, rowCount, path[pathIndex].Column);
                if (row == -1)
                    break;

                pathIndex++;
                path[pathIndex] = new Location(row, path[pathIndex - 1].Column);

                var col = FindPrimeInRow(masks, colCount, path[pathIndex].Row);

                pathIndex++;
                path[pathIndex] = new Location(path[pathIndex - 1].Row, col);
            }

            ConvertPath(masks, path, pathIndex + 1);
            ClearCovers(rowsCovered, colsCovered, colCount, rowCount);
            ClearPrimes(masks, colCount, rowCount);

            return HungarianStep.Step1;
        }
        private static HungarianStep RunStep4(int[,] costs, bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var minValue = FindMinimum(costs, rowsCovered, colsCovered, colCount, rowCount);

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (rowsCovered[i])
                        costs[i, j] += minValue;
                    if (!colsCovered[j])
                        costs[i, j] -= minValue;
                }
            }
            return HungarianStep.Step2;
        }

        private static int FindMinimum(int[,] costs, bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            var minValue = int.MaxValue;

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (!rowsCovered[i] && !colsCovered[j])
                        minValue = Math.Min(minValue, costs[i, j]);
                }
            }

            return minValue;
        }
        private static int FindStarInRow(byte[,] masks, int colCount, int row)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var j = 0; j < colCount; j++)
            {
                if (masks[row, j] == 1)
                    return j;
            }

            return -1;
        }
        private static int FindStarInColumn(byte[,] masks, int rowCount, int col)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var i = 0; i < rowCount; i++)
            {
                if (masks[i, col] == 1)
                    return i;
            }

            return -1;
        }
        private static int FindPrimeInRow(byte[,] masks, int colCount, int row)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var j = 0; j < colCount; j++)
            {
                if (masks[row, j] == 2)
                    return j;
            }

            return -1;
        }
        private static Location FindZero(int[,] costs, bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount)
        {
            if (costs == null)
                throw new ArgumentNullException(nameof(costs));

            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (costs[i, j] == 0 && !rowsCovered[i] && !colsCovered[j])
                        return new Location(i, j);
                }
            }

            return new Location(-1, -1);
        }
        private static void ConvertPath(byte[,] masks, Location[] path, int pathLength)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            if (path == null)
                throw new ArgumentNullException(nameof(path));

            for (var i = 0; i < pathLength; i++)
            {
                if (masks[path[i].Row, path[i].Column] == 1)
                {
                    masks[path[i].Row, path[i].Column] = 0;
                }
                else if (masks[path[i].Row, path[i].Column] == 2)
                {
                    masks[path[i].Row, path[i].Column] = 1;
                }
            }
        }
        private static void ClearPrimes(byte[,] masks, int colCount, int rowCount)
        {
            if (masks == null)
                throw new ArgumentNullException(nameof(masks));

            for (var i = 0; i < rowCount; i++)
            {
                for (var j = 0; j < colCount; j++)
                {
                    if (masks[i, j] == 2)
                        masks[i, j] = 0;
                }
            }
        }
        private static void ClearCovers(bool[] rowsCovered, bool[] colsCovered, int colCount, int rowCount)
        {
            if (rowsCovered == null)
                throw new ArgumentNullException(nameof(rowsCovered));

            if (colsCovered == null)
                throw new ArgumentNullException(nameof(colsCovered));

            for (var i = 0; i < rowCount; i++)
            {
                rowsCovered[i] = false;
            }

            for (var j = 0; j < colCount; j++)
            {
                colsCovered[j] = false;
            }
        }

        private struct Location
        {
            internal readonly int Row;
            internal readonly int Column;

            internal Location(int row, int col)
            {
                Row = row;
                Column = col;
            }
        }
    }
}