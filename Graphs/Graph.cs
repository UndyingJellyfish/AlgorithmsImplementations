using System;
using System.Collections.Generic;
using System.Linq;
using static Graphs.GraphType;

namespace Graphs
{
    public class Graph<TCost, TValue> where TCost : struct, IComparable
    {
        // https://github.com/UndyingJellyfish/Elderlearn/tree/0a8f18273d26095abb2a0b68cf4cfccc35fdef5b/UserMatching

        public GraphType GraphType { get; private set; }
        public bool GraphIsDirected { get; private set; }

        public List<Node<TCost, TValue>> Nodes
        {
            get => _nodes;
            private set => _nodes = value;
        }

        public List<Edge<TCost, TValue>> Edges
        {
            get => Nodes.SelectMany(x => x.Edges).ToList();
            private set => _edges = value;
        }

        private List<Node<TCost, TValue>> _nodes { get; set; }
        private List<Edge<TCost, TValue>> _edges { get; set; }
        
        public Graph()
        {
            this.GraphType = Generic;
            this.GraphIsDirected = true;
            this.Nodes = new List<Node<TCost, TValue>>();
            this._edges = new List<Edge<TCost, TValue>>();
        }

        public Graph(GraphType type) : this()
        {
            this.GraphType = type;
        }

        public Graph(bool directed) : this()
        {
            this.GraphIsDirected = directed;
        }

        public Graph(GraphType type, bool directed)
        {
            this.GraphType = type;
            this.GraphIsDirected = directed;
        }

        public Graph(GraphType type, bool directed, List<Node<TCost, TValue>> nodes) : this(type, directed)
        {
            this.Nodes = nodes;
            this.Edges = new List<Edge<TCost, TValue>>();
        }
    }
}