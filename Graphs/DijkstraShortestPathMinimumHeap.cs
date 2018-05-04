using System;
using System.Collections.Generic;

namespace Graphs
{
    public class DijkstraShortestPathMinimumHeap<TCost,TValue> where TCost : struct, IComparable
    {
        public int HeapSize { get; private set; }
        public List<Node<TCost, TValue>> Nodes { get; private set; }
        public int Size() => HeapSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="DijkstraShortestPathMinimumHeap{TCost,TValue}"/> class.
        /// </summary>
        /// <param name="vertices">The vertices in the graph structure.</param>
        public DijkstraShortestPathMinimumHeap(List<Node<TCost, TValue>> vertices)
        {
            HeapSize = vertices.Count;
            Nodes = new List<Node<TCost, TValue>>();
            foreach (var v in vertices)
            {
                Nodes.Add(v);
            }
        }

        /// <summary>
        /// Swaps the values in the heap at index i and j
        /// </summary>
        /// <param name="i">First swap index</param>
        /// <param name="j">Second swap index.</param>
        private void Exchange(int i, int j)
        {
            var temp = Nodes[i];
            Nodes[i] = Nodes[j];
            Nodes[j] = temp;
        }

        /// <summary>
        /// Maintain the heap structure
        /// </summary>
        /// <param name="i">Index at which maintainance should start, defaults to 0.</param>
        private void Heapify(int i = 0)
        {
            while (true)
            {
                var l = 2 * i + 1;
                var r = 2 * i + 2;
                int largest;


                if (l < HeapSize && Nodes[l].TotalDistance.CompareTo(Nodes[i].TotalDistance) > 0)
                    largest = l;
                else
                    largest = i;
                if (r < HeapSize && Nodes[r].TotalDistance.CompareTo(Nodes[largest].TotalDistance) > 0)
                    largest = r;
                if (largest == i) return;

                Exchange(i, largest);
                i = largest;
            }
        }

        /// <summary>
        /// Builds the heap, should be used immediately after populating the heap.
        /// </summary>
        public void BuildHeap()
        {
            for (var i = HeapSize / 2; i >= 0; i--)
            {
                Heapify(i);
            }
        }

        /// <summary>
        /// Searches the heap for the index of a node.
        /// </summary>
        /// <param name="n">The node to be found.</param>
        /// <returns>Index of n.</returns>
        public int HeapSearch(Node<TCost, TValue> n)
        {
            for (var i = 0; i < HeapSize; i++)
            {
                var temp = Nodes[i];
                if (n.Equals(temp))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Sorts the heap.
        /// </summary>
        public void HeapSort()
        {
            var temp = HeapSize;

            BuildHeap();

            for (var i = HeapSize - 1; i >= 1; i--)
            {
                Exchange(0, i);
                HeapSize--;
                Heapify();
            }

            HeapSize = temp;
        }

        /// <summary>
        /// Sorts the heap and then extracts the minimum value in the heap.
        /// </summary>
        /// <returns>Minimum value in the heap.</returns>
        public Node<TCost, TValue> ExtractMin()
        {
            if (HeapSize < 1)
                return null;

            HeapSort();

            Exchange(0, HeapSize - 1);
            HeapSize--;
            return Nodes[HeapSize];
        }

        /// <summary>
        /// Finds the index of the specified node using a heap search.
        /// </summary>
        /// <param name="n">The node to be found.</param>
        /// <returns>The index of n.</returns>
        public int Find(Node<TCost, TValue> n)
        {
            return HeapSearch(n);
        }

        
    }
}