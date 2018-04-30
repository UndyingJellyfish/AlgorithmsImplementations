using System;
using System.Collections.Generic;
using static Graphs.GraphType;

namespace Graphs
{
    public class Graph<TCost, TValue> where TCost : IComparable
    {
        // https://github.com/UndyingJellyfish/Elderlearn/tree/0a8f18273d26095abb2a0b68cf4cfccc35fdef5b/UserMatching

        public GraphType GraphType { get; private set; }
        public bool GraphIsDirected { get; private set; }
        public Node<TCost, string> Source { get; set; }
        public Node<TCost, string> Target { get; set; }
        public List<Node<TCost, TValue>> Nodes { get; private set; }
        public List<Edge<TCost, TValue>> Edges { get; private set; }


        public Graph()
        {
            this.GraphType = Generic;
            this.GraphIsDirected = true;
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
    }
}