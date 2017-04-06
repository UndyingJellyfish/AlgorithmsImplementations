namespace MinimumSpanningTrees
{
    public class Pair
    {
        public Pair(int u, int v)
        {
            this.U = u;
            this.V = v;
        }

        public int U { get; set; }

        public int V { get; set; }

        public override string ToString()
        {
            return "(" + U.ToString() + ", " + V.ToString() + ")";
        }
    }
}