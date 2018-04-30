using System;
using System.Runtime.CompilerServices;

namespace Graphs
{

    public class Edge<TCost, TValue> : IComparable<Edge<TCost, TValue>> where TCost : IComparable
    {
        public bool GraphIsDirected { get; private set; }
        public TCost Cost { get; set; }
        public TCost Flow { get; set; }
        public TCost Capacity { get; set; }
        public Node<TCost, TValue> From { get; set; }
        public Node<TCost, TValue> To { get; set; }

        protected Edge(bool directed, Node<TCost, TValue> from, Node<TCost, TValue> to, TCost tco)
        {
            this.GraphIsDirected = directed;
            this.From = from;
            this.To = to;
            this.Cost = tco;
        }

        protected Edge(bool directed, Node<TCost, TValue> from, Node<TCost, TValue> to, TCost tco, TCost tf) : this(directed, from, to, tco)
        {
            this.Flow = tf;
        }

        protected Edge(bool directed, Node<TCost, TValue> from, Node<TCost, TValue> to, TCost tco, TCost tf, TCost tca) : this( directed, from, to, tco, tf)
        {
            this.Capacity = tca;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj);
        }
        
        public int CompareTo(Edge<TCost, TValue> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            
            return this.Cost.CompareTo(other.Cost);
        }
    }
}