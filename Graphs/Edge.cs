using System;
using System.Runtime.CompilerServices;

namespace Graphs
{

    public class Edge<TCost, TValue> : IComparable<Edge<TCost, TValue>> where TCost : struct, IComparable
    {
        public bool GraphIsDirected { get; private set; }
        public TCost Cost { get; set; }
        //public TCost Flow { get; set; }
        //public TCost Capacity { get; set; }
        public Node<TCost, TValue> From { get; set; }
        public Node<TCost, TValue> To { get; set; }

        /// <summary>
        /// Creates a new edge going from one note to another for some cost.
        /// </summary>
        /// <param name="from">Where edge starts.</param>
        /// <param name="to">Where edge ends.</param>
        /// <param name="cost">Cost of edge.</param>
        /// <param name="directed">Whether the graph is directed or not.</param>
        public Edge(Node<TCost, TValue> from, Node<TCost, TValue> to, TCost cost = default(TCost), bool directed = true)
        {
            this.GraphIsDirected = directed;
            this.From = from;
            this.To = to;
            this.Cost = cost;
        }

        public int CompareTo(object obj)
        {
            return this.CompareTo(obj as Edge<TCost,TValue>);
        }
        
        public int CompareTo(Edge<TCost, TValue> other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            
            return this.Cost.CompareTo(other.Cost);
        }
    }
}