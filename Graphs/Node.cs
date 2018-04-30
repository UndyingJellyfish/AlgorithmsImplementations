using System;
using System.Collections.Generic;

namespace Graphs
{
    public class Node<TCost, TValue> where TCost : IComparable
    {
        public TValue Value { get; set; }
        public List<Edge<TCost, TValue>> Edges { get; set; }
        
        public Node(TValue val)
        {
            Value = val;
        }
    }
}