namespace DamsboSoftware.AlgorithmImplementations.MinimumSpanningTrees
{
    public class Edge
    {
        public int U { get; set; }

        public int V { get; set; }

        public int Weight { get; set; }

        public Edge(int u, int v, int weight)
        {
            this.U = u;
            this.V = v;
            this.Weight = weight;
        }

        public Edge() : this(0,0,0)
        {
        }
    }
}
