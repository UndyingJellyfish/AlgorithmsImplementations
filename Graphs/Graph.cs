using System;
using System.Collections.Generic;
using System.Linq;

namespace DamsboSoftware.AlgorithmImplementations.Graphs
{
    public class Graph<TCost, TValue> where TCost : struct, IComparable
    {
        // https://github.com/UndyingJellyfish/Elderlearn/tree/0a8f18273d26095abb2a0b68cf4cfccc35fdef5b/UserMatching
        
        public bool GraphIsDirected { get; private set; }

        public Node<TCost, TValue> SourceNode
        {
            get => _source;
            set => _source = value;
        }
        public Node<TCost, TValue> TargetNode
        {
            get => _target;
            set => _target = value;
        }
        public List<Node<TCost, TValue>> Nodes
        {
            get => _nodes;
            set => _nodes = value;
        }
        public List<Edge<TCost, TValue>> Edges => Nodes.SelectMany(x => x.OutgoingEdges).ToList();
        
        private Node<TCost, TValue> _source { get; set; }
        private Node<TCost, TValue> _target { get; set; }
        private List<Node<TCost, TValue>> _nodes { get; set; }
        private List<Edge<TCost, TValue>> _edges { get; set; }
        

        public Graph(List<Node<TCost, TValue>> nodes)
        {
            this._nodes = nodes;
            this._edges = new List<Edge<TCost, TValue>>();
        }

        public Graph(bool directed, List<Node<TCost, TValue>> nodes) : this(nodes)
        {
            this.GraphIsDirected = directed;
        }

        public Graph(List<Node<TCost, TValue>> nodes, Node<TCost, TValue> source, Node<TCost, TValue> target) : this(nodes)
        {
            this._source = source;
            this._target = target;
        }
        
        public Graph(bool directed, List<Node<TCost, TValue>> nodes, Node<TCost, TValue> source, Node<TCost, TValue> target) : this(directed, nodes)
        {
            this._source = source;
            this._target = target;
        }

    }
}