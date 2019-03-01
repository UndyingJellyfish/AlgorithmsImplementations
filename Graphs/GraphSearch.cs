using System;
using System.Collections.Generic;
using System.Linq;

namespace DamsboSoftware.AlgorithmImplementations.Graphs
{
    public abstract class GraphSearch<TCost, TValue> where TCost : struct, IComparable
    {
        private IEnumerable<Node<TCost, TValue>> AllNodes;
        private IEnumerable<Node<TCost, TValue>> GoalStates;
        private IEnumerable<Node<TCost, TValue>> Frontier;
        private IEnumerable<Node<TCost, TValue>> Visited;

        public GraphSearch(IEnumerable<Node<TCost, TValue>> nodes, IEnumerable<Node<TCost, TValue>> goalStates)
        {
            AllNodes = nodes;
            GoalStates = goalStates;
        }
        
    }
}