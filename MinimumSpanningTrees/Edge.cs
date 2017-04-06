using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumSpanningTrees
{
    class Edge
    {
        public Edge()
        {
            U = V = Weight = 0;
        }

        public Edge(int u, int v, int weight)
        {
            this.U = u;
            this.V = v;
            this.Weight = weight;
        }

        public int U { get; set; }

        public int V { get; set; }

        public int Weight { get; set; }
    }
}
