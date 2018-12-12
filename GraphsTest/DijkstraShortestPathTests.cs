using System;
using System.Collections.Generic;
using DamsboSoftware.AlgorithmImplementations.Graphs;
using DamsboSoftware.AlgorithmImplementations.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DamsboSoftware.AlgorithmImplementations.GraphsTest
{
    [TestClass]
    public class UnitTestDijkstras
    {
        //TODO: USE THESE FOR ILLUSTRATIONS: https://en.wikipedia.org/wiki/Template:Unicode_chart_Arrows
        
        [TestMethod]
        public void TestSourceTargetIsSameNode()
        {
            // naming scheme for nodes is "nx" where
            // "n" is short for node and "x" is the char value
            var nst = new Node<int, char>('s'); // source node and target node
            var nodes = new List<Node<int, char>> { nst };
            var calc = new Calculator<int>();
            var expectedPath = new List<Node<int, char>> { nst };
            var expectedLength = 0; // no movement means no costs
            var dijkstra = new SingleShortestPath<int, char>(nodes, nst, nst, calc);

            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(expectedPath, result);
        }

        [TestMethod]
        public void TestSourceAndTargetIsDirectlyConnected()
        {
            // naming scheme for nodes is "nx" where
            // "n" is short for node and "x" is the char value
            var ns = new Node<int, char>('s'); // source node
            var nt = new Node<int, char>('t'); // target node
            var nodes = new List<Node<int, char>> { ns, nt };

            // naming scheme for edges is "exy" 
            // where "e" is short for "edge", 
            // "x" corresponds to the origin node and
            // "y" corresponds to the destination node
            var est = new Edge<int, char>(ns, nt, 100);
            ns.AddEdge(est);
            var calc = new Calculator<int>();
            var expectedPath = new List<Node<int, char>> { ns, nt };
            var expectedLength = est.Cost;
            var dijkstra = new SingleShortestPath<int, char>(nodes, ns, nt, calc);

            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(expectedPath, result);
        }

        [TestMethod]
        public void TestSourceHasSimplePathToTarget()
        {
            // naming scheme for nodes is "nx" where
            // "n" is short for node and "x" is the char value
            var ns = new Node<int, char>('s'); // source node
            var n1 = new Node<int, char>('1');
            var n2 = new Node<int, char>('2');
            var n3 = new Node<int, char>('3');
            var nt= new Node<int, char>('t'); // source node
            var nodes = new List<Node<int, char>> { ns, n1, n2, n3, nt };
            // naming scheme for edges is "exy" 
            // where "e" is short for "edge", 
            // "x" corresponds to the origin node and
            // "y" corresponds to the destination node
            var es1 = new Edge<int, char>(ns, n1, 1);
            var e12 = new Edge<int, char>(n1, n2, 2);
            var e23 = new Edge<int, char>(n2, n3, 3);
            var e3t = new Edge<int, char>(n3, nt, 4);
            ns.AddEdge(es1);
            n1.AddEdge(e12);
            n2.AddEdge(e23);
            n3.AddEdge(e3t);
            var calc = new Calculator<int>();
            // simple path through a long thin line of nodes
            var expectedPath = new List<Node<int, char>> { ns, n1, n2, n3, nt };
            var expectedLength = es1.Cost + e12.Cost + e23.Cost + e3t.Cost;
            var dijkstra = new SingleShortestPath<int, char>(nodes, ns, nt, calc);

            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;

            Assert.AreEqual(expectedLength, length);
            CollectionAssert.AreEqual(expectedPath, result);
        }

        [TestMethod]
        public void TestComplexWithIntsNodeListParams()
        {
            /*
              (s)------5----->(1)------15---->(2)
               | \           /   \           ↗ |
               |  \         /     \         /  |
               |   8       4       12      3   |
               |    \     /         \     /    |
               |     ↘   ↙           ↘   /     |
               9      (3)------7----->(4)      9
               |     ↗   \           ↗   \     |
               |    /     \         /     \    |
               |   5       6       1       11  |
               |  /         \     /         \  |
               ↓ /           ↘   /           ↘ ↓
              (6)------4----->(5)-----13----->(t)

               Shortest path: s-6-5-4-t
               Cost: 9 + 4 + 1 + 11 = 25

             */

            // naming scheme for nodes is "nx" where
            // "n" is short for node and "x" is the char value
            var ns = new Node<int, char>('s'); // source node
            var n1 = new Node<int, char>('1');
            var n2 = new Node<int, char>('2');
            var n3 = new Node<int, char>('3');
            var n4 = new Node<int, char>('4');
            var n5 = new Node<int, char>('5');
            var n6 = new Node<int, char>('6');
            var nt = new Node<int, char>('t'); // target node
            var nodes = new List<Node<int, char>> { ns, n1, n2, n3, n4, n5, n6, nt };

            // naming scheme for edges is "exy" 
            // where "e" is short for "edge", 
            // "x" corresponds to the origin node and
            // "y" corresponds to the destination node
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

            var calc = new Calculator<int>();
            var expectedPath = new List<Node<int, char>> { ns, n6, n5, n4, nt };
            var expectedCost = es6.Cost + e65.Cost + e54.Cost + e4t.Cost;
            var dijkstra = new SingleShortestPath<int, char>(nodes, ns, nt, calc);

            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;

            Assert.AreEqual(expectedCost, length);
            CollectionAssert.AreEqual(expectedPath, result);
        }

        [TestMethod]
        public void TestComplexGraphWithIntsGraphParam()
        {
            /*
              (s)------5----->(1)------15---->(2)
               | \           /   \           ↗ |
               |  \         /     \         /  |
               |   8       4       12      3   |
               |    \     /         \     /    |
               |     ↘   ↙           ↘   /     |
               9      (3)------7----->(4)      9
               |     ↗   \           ↗   \     |
               |    /     \         /     \    |
               |   5       6       1       11  |
               |  /         \     /         \  |
               ↓ /           ↘   /           ↘ ↓
              (6)------4----->(5)-----13----->(t)

               Shortest path:  s - 6 - 5 - 4 - t
               Cost:           9 + 4 + 1 + 11 = 25

             */

            // naming scheme for nodes is "nx" where
            // "n" is short for node and "x" is the char value
            var ns = new Node<int, char>('s'); // source node
            var n1 = new Node<int, char>('1');
            var n2 = new Node<int, char>('2');
            var n3 = new Node<int, char>('3');
            var n4 = new Node<int, char>('4');
            var n5 = new Node<int, char>('5');
            var n6 = new Node<int, char>('6');
            var nt = new Node<int, char>('t'); // target node

            var nodes = new List<Node<int, char>> { ns, n1, n2, n3, n4, n5, n6, nt };

            // naming scheme for edges is "exy" 
            // where "e" is short for "edge", 
            // "x" corresponds to the origin node and
            // "y" corresponds to the destination node
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
            var calc = new Calculator<int>();
            var expectedPath = new List<Node<int, char>> { ns, n6, n5, n4, nt };
            var expectedCost = es6.Cost + e65.Cost + e54.Cost + e4t.Cost;
            var dijkstra = new SingleShortestPath<int, char>(graph, calc);

            dijkstra.DijkstraSingleShortestPath();
            var result = dijkstra.ShortestPath;
            var length = dijkstra.ShortestPathDistance;
            
            Assert.AreEqual(expectedCost, length);
            CollectionAssert.AreEqual(expectedPath, result);
        }
    }
}
