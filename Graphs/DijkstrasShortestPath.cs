using System;
using System.Collections.Generic;
using DamsboSoftware.AlgorithmImplementations.Utilities;

namespace DamsboSoftware.AlgorithmImplementations.Graphs
{
    /// <summary>
    /// Calculates the single shortest path in a given graph.
    /// </summary>
    public class SingleShortestPath<TCost, TValue> where TCost : struct, IComparable
    {
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
            // initialize fields using params
            this._nodes = nodes;
            this._sourceNode = source;
            this._targetNode = target;
            this._calculator = calc;

            // initialize fields that has no corresponding param
            this._shortestPath = new List<Node<TCost, TValue>>();
            this._minHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(_nodes);
            
            // add source and target to node list if they don't exist in list
            if (_nodes.Find(x => x.Equals(_sourceNode)) is null)
            {
                _nodes.Add(_sourceNode);
            }
            if (_nodes.Find(x => x.Equals(_targetNode)) is null)
            {
                _nodes.Add(_targetNode);
            }
            
            InitializeSingleSource();
        }

        public SingleShortestPath(Graph<TCost,TValue> graph ,Calculator<TCost> calc)
        {
            // deconstruct the graph object and initialize fields
            this._nodes = graph.Nodes;
            this._sourceNode = graph.SourceNode;
            this._targetNode = graph.TargetNode;
            this._calculator = calc;

            // initialize fields that has no corresponding param
            this._shortestPath = new List<Node<TCost, TValue>>();
            this._minHeap = new DijkstraShortestPathMinimumHeap<TCost, TValue>(_nodes);
            
            // add source and target to node list if they don't exist in list
            if (_nodes.Find(x => x.Equals(_sourceNode)) is null)
            {
                _nodes.Add(_sourceNode);
            }
            if (_nodes.Find(x => x.Equals(_targetNode)) is null)
            {
                _nodes.Add(_targetNode);
            }
            
            InitializeSingleSource();
        }

        /// <summary>
        /// Initializes the single source shortest path graph. 
        /// (Cormen, Leiserson, Rivst, Stein; "Introduction to Algorithms"; 3rd edition, 2009)
        /// </summary>
        private void InitializeSingleSource()
        {
            foreach (var v in _nodes)
            {
                // each node must have no predecessor and be initialized with the highest possible maximum distance
                v.Predecessor = null; 
                v.SetTotalDistanceAsMaxValue();
            }
            // the distance to the source node is set to default(TCost) which is some variation of 0
            // this is done such that the final distance from the source to target is the sum of costs of all edges connecting the path
            _nodes.Find(n => n.Equals(_sourceNode)).SetTotalDistanceAsDefaultValue();
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
        /// Backtracks the path going from target to source via each node's predecessor.
        /// </summary>
        private void BacktrackPath()
        {
            var currentNode = _nodes.Find(n => n.Equals(_targetNode));
            if (currentNode is null)
            {
                throw new Exception("Backtracking failed. The graph does not contain a valid target node.");
            }
            ShortestPath.Add(currentNode);

            // trace our path backwards through the predecessors until a predecessor is undefined
            // the only node on the path without a predecessor is the source
            while (currentNode.Predecessor != null)
            {
                if (ShortestPath.Contains(currentNode.Predecessor))
                {
                    // is a node's predecessor is already contained in the shortest path there is a cycle
                    throw new Exception("Backtracking failed. Cycle in shortest path detected at node: " + currentNode);
                }

                // for every step we add the currentNode's predecessor and step onto that predecessor as the new currentNode
                ShortestPath.Add(currentNode.Predecessor);
                currentNode = currentNode.Predecessor;
            }
            ShortestPath.Reverse();
        }
    }
}