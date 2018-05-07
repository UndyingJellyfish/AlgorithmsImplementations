using System;
using System.Collections.Generic;
using Utilities;

namespace Graphs
{
    /// <summary>
    /// Contains the algorithms for calculating the single shortest path in a graph.
    /// </summary>
    public class SingleShortestPath<TCost, TValue> where TCost : struct, IComparable
    {
        private List<Node<TCost, TValue>> Nodes { get; }
        public Node<TCost, TValue> SourceNode { get; }
        public Node<TCost, TValue> TargetNode { get; }
        public DijkstraShortestPathMinimumHeap<TCost, TValue> MinHeap { get; set; }
        public Dictionary<Node<TCost, TValue>, List<Edge<TCost, TValue>>> Adjacencies { get; set; }

        private Calculator<TCost> Calculator { get; set; }
        private Calculator<TCost> C => Calculator;
        private TCost Add(object val1, object val2) => C.Add((TCost)val1, GenericConversions<TCost>.Generify(val2));

        public SingleShortestPath(List<Node<TCost, TValue>> nodes, Node<TCost, TValue> source,
            Node<TCost, TValue> target, Calculator<TCost> calc)
        {
            this.Nodes = nodes;
            this.SourceNode = source;
            this.TargetNode = target;
            this.Calculator = calc;

            // add source and target to node list if they don't exist in list
            if (Nodes.Find(x => x.Equals(SourceNode)) is null)
            {
                Nodes.Add(SourceNode);
            }
            if (Nodes.Find(x => x.Equals(TargetNode)) is null)
            {
                Nodes.Add(TargetNode);
            }

            void InitializeSingleSource()
            {
                this.MinHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(nodes);
                foreach (var v in Nodes)
                {
                    v.SetTotalDistanceAsMaxValue();
                    v.Predecessor = null;
                }
                Nodes.Find(n => n.Equals(SourceNode)).SetTotalDistanceAsMaxValue();
            }
            InitializeSingleSource();
        }

        
        /// <summary>
        /// Relaxes the node we're "standing in". (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <param name="u">The node that is being considered</param>
        /// <param name="v">The potential optimizable target</param>
        /// <param name="adjacencies">Adjacency dictionary, each node should have a corresponding key.</param>
        private void Relax(Node<TCost, TValue> u, Node<TCost, TValue> v)
        {
            var w = Adjacencies[u].Find(n => n.To.Equals(v)).Cost;

            if (v.TotalDistance.CompareTo(C.Add(u.TotalDistance, w)) > 0)
            {
                v.TotalDistance = C.Add(u.TotalDistance, w);
                v.Predecessor = u;
            }
        }


        /// <summary>
        /// Performs Dijkstra's Single Shortest Path algorithm on a supplied graph. 
        /// (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <returns>The shortest path from the source to the target.</returns>
        public List<Node<TCost, TValue>> DijkstraSingleShortestPath()
        {
            MinHeap.BuildHeap();

            while (MinHeap.Size() != 0)
            {
                var u = MinHeap.ExtractMin();
                var uAdj = Adjacencies[u];
                foreach (var adj in uAdj)
                {
                    var v = adj.To;
                    Relax(u, v);
                }
            }

            var shortestPath = new List<Node<TCost, TValue>>(); // used to store the final path
            var currentNode = Nodes.Find(n => n.Equals(TargetNode));
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