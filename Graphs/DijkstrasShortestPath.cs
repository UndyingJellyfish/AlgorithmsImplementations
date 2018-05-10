using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Utilities;

namespace Graphs
{
    /// <summary>
    /// Calculates the single shortest path in a given graph.
    /// </summary>
    public class SingleShortestPath<TCost, TValue> where TCost : struct, IComparable
    {
        public Graph<TCost,TValue> Graph { get; set; } // TODO: ACTUALLY USE THIS
        
        public List<Node<TCost, TValue>> Nodes
        {
            get => _nodes;
            set => _nodes = value;
        }
        public Node<TCost, TValue> SourceNode
        {
            get => _sourceNode;
            set => _sourceNode = value;
        }
        public Node<TCost, TValue> TargetNode
        {
            get => _targetNode;
            set => _targetNode = value;
        }
        public Calculator<TCost> Calculator => _calculator;
        public List<Node<TCost, TValue>> ShortestPath => _shortestPath;
        public TCost ShortestPathDistance => _targetNode.TotalDistance;
        
        private List<Node<TCost, TValue>> _nodes { get; set; }
        private List<Node<TCost, TValue>> _shortestPath { get; }
        private Node<TCost, TValue> _sourceNode { get; set; }
        private Node<TCost, TValue> _targetNode { get; set; }
        private Calculator<TCost> _calculator { get; }
        private DijkstraShortestPathMinimumHeap<TCost, TValue> _minHeap { get; set; }
        private Calculator<TCost> C => Calculator;

        public SingleShortestPath(List<Node<TCost, TValue>> nodes, Node<TCost, TValue> source,
            Node<TCost, TValue> target, Calculator<TCost> calc)
        {
            this._nodes = nodes;
            this._sourceNode = source;
            this._targetNode = target;
            this._calculator = calc;
            this._shortestPath = new List<Node<TCost, TValue>>();

            // add source and target to node list if they don't exist in list
            if (_nodes.Find(x => x.Equals(_sourceNode)) is null)
            {
                _nodes.Add(_sourceNode);
            }
            if (_nodes.Find(x => x.Equals(_targetNode)) is null)
            {
                _nodes.Add(_targetNode);
            }

            void InitializeSingleSource()
            {
                this._minHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(_nodes);
                foreach (var v in _nodes)
                {
                    v.Predecessor = null;
                }
                _nodes.Find(n => n.Equals(_sourceNode)).SetTotalDistanceAsDefaultValue();

            }

            InitializeSingleSource();
        }

        public SingleShortestPath(Graph<TCost,TValue> graph ,Calculator<TCost> calc)
        {
            this._nodes = graph.Nodes;
            this._sourceNode = graph.SourceNode;
            this._targetNode = graph.TargetNode;
            this._calculator = calc;
            this._shortestPath = new List<Node<TCost, TValue>>();

            // add source and target to node list if they don't exist in list
            if (_nodes.Find(x => x.Equals(_sourceNode)) is null)
            {
                _nodes.Add(_sourceNode);
            }
            if (_nodes.Find(x => x.Equals(_targetNode)) is null)
            {
                _nodes.Add(_targetNode);
            }

            var adjacencies = new Dictionary<Node<TCost, TValue>, List<Edge<TCost, TValue>>>();
            foreach (var edge in graph.Edges)
            {
                if (!adjacencies.ContainsKey(edge.From))
                {
                    adjacencies.Add(edge.From, new List<Edge<TCost,TValue>>());
                }

                adjacencies[edge.From].Add(edge);
            }

            void InitializeSingleSource()
            {
                this._minHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(_nodes);
                foreach (var v in _nodes)
                {
                    v.Predecessor = null;
                }
                _nodes.Find(n => n.Equals(_sourceNode)).SetTotalDistanceAsDefaultValue();
            }

            InitializeSingleSource();
        }

        

        /// <summary>
        /// Relaxes the node we're "standing in". (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <param name="u">The node that is being considered</param>
        /// <param name="v">The potential optimizable target</param>
        private void Relax(Node<TCost, TValue> u, Node<TCost, TValue> v)
        {
            var w = u.OutgoingEdges.Find(e => e.To.Equals(v)).Cost;

            if (v.TotalDistance.CompareTo(C.Add(u.TotalDistance, w)) <= 0) return;

            v.TotalDistance = C.Add(u.TotalDistance, w);
            v.Predecessor = u;
        }
        
        /// <summary>
        /// Performs Dijkstra's Single Shortest Path algorithm on a supplied graph. 
        /// (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        /// <returns>The shortest path from the source to the target.</returns>
        public List<Node<TCost, TValue>> DijkstraSingleShortestPath()
        {
            _minHeap.BuildHeap();

            while (_minHeap.Size() != 0)
            {
                var u = _minHeap.ExtractMin();

                foreach (var adj in u.OutgoingEdges)
                {
                    var v = adj.To;
                    Relax(u, v);
                }
            }
            BacktrackPath();
            return _shortestPath;
        }

        /// <summary>
        /// Backtracks the path.
        /// </summary>
        private void BacktrackPath()
        {
            var currentNode = _nodes.Find(n => n.Equals(_targetNode));
            ShortestPath.Add(currentNode);

            while (currentNode.Predecessor != null)
            {
                // trace our path backwards through the predecessors until a predecessor is undefined
                // the only node on the path without a predecessor is the source
                if (ShortestPath.Contains(currentNode.Predecessor)) throw new Exception("Cycle in shortest path detected at node: " + currentNode);

                ShortestPath.Add(currentNode.Predecessor);
                currentNode = currentNode.Predecessor;
            }
            ShortestPath.Reverse();

        }

    }
}