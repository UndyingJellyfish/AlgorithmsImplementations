using System;
using System.Collections.Generic;

namespace Graphs
{
    /// <summary>
    /// Contains the algorithms for calculating the single shortest path in a graph.
    /// </summary>
    public class SingleShortestPath<TValue>
    {

        private List<Node<int, TValue>> AllNodes { get; set; }
        public Node<int, TValue> SourceNode { get; private set; }
        public Node<int, TValue> TargetNode { get; private set; }


        /// <summary>
        /// Initializes the single source shortest path. Deprecated due to optimizations in graph generation.
        /// </summary>
        /// <param name="nodes">A list of nodes in the graph structure.</param>
        /// <param name="sourceX">The source x coordinate.</param>
        /// <param name="sourceY">The source y coordinate.</param>
        private void InitializeSingleSource(List<Node<int, TValue>> nodes)
        {
            foreach (var v in nodes)
            {
                v.SetTotalDiostanceAsMaxValue();
                v.Predecessor = null;
            }
            nodes.Find(n => n.Equals(SourceNode)).TotalDistance = 0;
        }

        /// <summary>
        /// Relaxes the node weøre "standing in". (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <param name="u">The node that is being considered</param>
        /// <param name="v">The potential optimizable target</param>
        /// <param name="adjacencies">Adjacency dictionary, each node should have a corresponding key.</param>
        private static void Relax(Node u, Node v, Dictionary<Node, List<Edge>> adjacencies)
        {
            var w = adjacencies[u].Find(n => n.To.X == v.X && n.To.Y == v.Y).Cost;
            if (v.D > u.D + w)
            {
                v.D = u.D + w;
                v.Predecessor = u;
            }
        }


        /// <summary>
        /// Performs Dijkstra's Single Shortest Path algorithm on a supplied graph. 
        /// (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <param name="nodes">The list of nodes is treated as a graph.</param>
        /// <param name="adjacencies">Adjacency dictionary, each node should have a corresponding key.</param>
        /// <param name="targetX">The destination x coordinate.</param>
        /// <param name="targetY">The destination y coordinate.</param>
        /// <returns>The shortest path from the source to the target.</returns>
        public static List<Node> DijkstraSingleShortestPath(List<Node> nodes, Dictionary<Node, List<Edge>> adjacencies, int targetX, int targetY)
        {
            // don't actually need this, as we are initializing the nodes with the correct fields instead
            //InitializeSingleSource(nodes, 0, 0); 

            var minHeap = new MinimumHeap(nodes);
            minHeap.BuildHeap();

            while (minHeap.Size() != 0)
            {
                var u = minHeap.ExtractMin();
                var uAdj = adjacencies[u];
                foreach (var adj in uAdj)
                {
                    var v = adj.To;
                    Relax(u, v, adjacencies);
                }
            }

            var shortestPath = new List<Node>(); // used to store the final path
            var currentNode = nodes.Find(n => n.X == targetX && n.Y == targetY);
            shortestPath.Add(currentNode);

            while (currentNode.Predecessor != null)
            {
                // trace our path backwards through the predecessors until a predecessor is undefined
                // the only node on the path without a predecessor is the source
                shortestPath.Add(currentNode.Predecessor);
                currentNode = currentNode.Predecessor;
            }
            shortestPath.Reverse();

            return shortestPath;
        }
    }
}