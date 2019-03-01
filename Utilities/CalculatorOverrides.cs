namespace DamsboSoftware.AlgorithmImplementations.Utilities
{
    public class Calculator<T>
    {
        public T Add(T a, T b)
        {
            dynamic n1 = a;
            dynamic n2 = b;
            return n1 + n2;
        }

        public T Sub(T a, T b)
        {
            dynamic n1 = a;
            dynamic n2 = b;
            return n1 - n2;
        }

        public T Mult(T a, T b)
        {
            dynamic n1 = a;
            dynamic n2 = b;
            return n1 * n2;
        }

        public T Div(T a, T b)
        {
            dynamic n1 = a;
            dynamic n2 = b;
            return n1 / n2;
        }
    }
}