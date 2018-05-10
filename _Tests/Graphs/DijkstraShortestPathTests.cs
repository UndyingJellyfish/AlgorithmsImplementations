using System;
using System.Collections.Generic;
using System.Linq;
using Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _Tests.Sorting
{
    [TestClass]
    public class UnitTestDijkstras
    {
        [TestMethod]
        public void TestDistanceAndLengthWithIntsNodeListParams()
        {
            var ns = new Node<int, char>('s');
            var n1 = new Node<int, char>('1');
            var n2 = new Node<int, char>('2');
            var n3 = new Node<int, char>('3');
            var n4 = new Node<int, char>('4');
            var n5 = new Node<int, char>('5');
            var n6 = new Node<int, char>('6');
            var nt = new Node<int, char>('t');

            var nodes = new List<Node<int, char>> { ns, n1, n2, n3, n4, n5, n6, nt };

            var es1 = new Edge<int, char>(ns, n1, 5);
            var es3 = new Edge<int, char>(ns, n3, 8);
            var es6 = new Edge<int, char>(ns, n6, 9);
            var e12 = new Edge<int, char>(n1, n2, 15);
            var e13 = new Edge<int, char>(n1, n3, 4);
            var e14 = new Edge<int, char>(n1, n4, 12);
            var e2t = new Edge<int, char>(n2, nt, 9);
            var e34 = new Edge<int, char>(n3, n4, 7);
            var e35 = new Edge<int, char>(n3, n5, 6);
            var e4t = new Edge<int, char>(n4, nt, 11);
            var e54 = new Edge<int, char>(n5, n4, 1);
            var e5t = new Edge<int, char>(n5, nt, 13);
            var e63 = new Edge<int, char>(n6, n3, 5);
            var e65 = new Edge<int, char>(n6, n5, 4);
            var e6t = new Edge<int, char>(n6, nt, 20);

            var edges = new List<Edge<int, char>> { es1, es3, es6, e12, e13, e14, e2t, e34, e35, e4t, e54, e5t, e63, e65, e6t };

            ns.AddEdge(es1);
            ns.AddEdge(es3);
            ns.AddEdge(es6);
            n1.AddEdge(e12);
            n1.AddEdge(e13);
            n1.AddEdge(e14);
            n2.AddEdge(e2t);
            n3.AddEdge(e34);
            n3.AddEdge(e35);
            n4.AddEdge(e4t);
            n5.AddEdge(e54);
            n5.AddEdge(e5t);
            n6.AddEdge(e63);
            n6.AddEdge(e65);
            n6.AddEdge(e6t);

            var graph = new Graph<int, char>(nodes, ns, nt);
            var calc = new Int32.Calculator();

            var expected = new List<Node<int, char>> { ns, n6, n5, n4, nt };

            var dijkstra = new SingleShortestPath<int, char>(nodes, ns, nt, calc);
            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;
            Assert.AreEqual(25, length);
            CollectionAssert.AreEqual(result, expected);
        }

        [TestMethod]
        public void TestDistanceAndLengthWithIntsGraphParam()
        {
            var ns = new Node<int, char>('s');
            var n1 = new Node<int, char>('1');
            var n2 = new Node<int, char>('2');
            var n3 = new Node<int, char>('3');
            var n4 = new Node<int, char>('4');
            var n5 = new Node<int, char>('5');
            var n6 = new Node<int, char>('6');
            var nt = new Node<int, char>('t');

            var nodes = new List<Node<int, char>> { ns, n1, n2, n3, n4, n5, n6, nt };

            var es1 = new Edge<int, char>(ns, n1, 5);
            var es3 = new Edge<int, char>(ns, n3, 8);
            var es6 = new Edge<int, char>(ns, n6, 9);
            var e12 = new Edge<int, char>(n1, n2, 15);
            var e13 = new Edge<int, char>(n1, n3, 4);
            var e14 = new Edge<int, char>(n1, n4, 12);
            var e2t = new Edge<int, char>(n2, nt, 9);
            var e34 = new Edge<int, char>(n3, n4, 7);
            var e35 = new Edge<int, char>(n3, n5, 6);
            var e4t = new Edge<int, char>(n4, nt, 11);
            var e54 = new Edge<int, char>(n5, n4, 1);
            var e5t = new Edge<int, char>(n5, nt, 13);
            var e63 = new Edge<int, char>(n6, n3, 5);
            var e65 = new Edge<int, char>(n6, n5, 4);
            var e6t = new Edge<int, char>(n6, nt, 20);

            var edges = new List<Edge<int, char>> { es1, es3, es6, e12, e13, e14, e2t, e34, e35, e4t, e54, e5t, e63, e65, e6t };

            ns.AddEdge(es1);
            ns.AddEdge(es3);
            ns.AddEdge(es6);
            n1.AddEdge(e12);
            n1.AddEdge(e13);
            n1.AddEdge(e14);
            n2.AddEdge(e2t);
            n3.AddEdge(e34);
            n3.AddEdge(e35);
            n4.AddEdge(e4t);
            n5.AddEdge(e54);
            n5.AddEdge(e5t);
            n6.AddEdge(e63);
            n6.AddEdge(e65);
            n6.AddEdge(e6t);

            var graph = new Graph<int, char>(nodes, ns, nt);
            var calc = new Int32.Calculator();

            var expected = new List<Node<int, char>> { ns, n6, n5, n4, nt };

            var dijkstra = new SingleShortestPath<int, char>(graph, calc);
            dijkstra.DijkstraSingleShortestPath();
            var newResult = dijkstra.ShortestPath;
            var newLength = dijkstra.ShortestPathDistance;
            Assert.AreEqual(25, newLength);
            CollectionAssert.AreEqual(newResult, expected);
        }


    }
}
