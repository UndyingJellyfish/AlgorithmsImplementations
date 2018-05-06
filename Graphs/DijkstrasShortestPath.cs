using System;
using System.Collections.Generic;

namespace Graphs
{
    /// <summary>
    /// Contains the algorithms for calculating the single shortest path in a graph.
    /// </summary>
    public class SingleShortestPath<TCost, TValue> where TCost : struct, IComparable
    {

        private List<Node<TCost, TValue>> AllNodes { get; set; }
        public Node<TCost, TValue> SourceNode { get; private set; }
        public Node<TCost, TValue> TargetNode { get; private set; }


        /// <summary>
        /// Initializes the single source shortest path.
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
        private void Relax(Node<TCost, TValue> u, Node<TCost, TValue> v, Dictionary<Node<TCost, TValue>, List<Edge<TCost, TValue>>> adjacencies)
        {

            // TODO: find out how to handle adjacencies in a generic graph
            var w = adjacencies[u].Find(n => n.To.Equals(v)).Cost;
            // TODO: Consider constraining TCost to be an arithmetic type
            /*
            if (v.TotalDistance.CompareTo(u.TotalDistance + w) > 0)
            {
                v.TotalDistance = u.TotalDistance + w;
                v.Predecessor = u;
            }
            */
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
        public List<Node<TCost, TValue>> DijkstraSingleShortestPath(List<Node<TCost, TValue>> nodes, Dictionary<Node<TCost, TValue>, List<Edge<TCost, TValue>>> adjacencies)
        {
            // don't actually need this, as we are initializing the nodes with the correct fields instead
            //InitializeSingleSource(nodes, 0, 0); 

            var minHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(nodes);
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

            var shortestPath = new List<Node<TCost, TValue>>(); // used to store the final path
            var currentNode = nodes.Find(n => n.Equals(TargetNode));
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