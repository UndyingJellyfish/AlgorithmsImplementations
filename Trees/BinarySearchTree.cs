using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinarySearchTree
    // https://stackoverflow.com/questions/10366402/binary-search-tree-in-c-sharp-implementation
    {
        public Node Root { get; private set; }

        public BinarySearchTree(int key = 0, Node newRoot = null)
        {
            if (newRoot == null)
            {
                newRoot = new Node();
            }
            newRoot.Key = key;
            this.Root = newRoot;
        }

        public bool AddNode(Node nodeToAdd, Node currentNode = null)
        {
            if (currentNode == null)
            {
                currentNode = Root;
            }
            if (Root == null)
            {
                Root = nodeToAdd;
                return true;
            }
            else if (nodeToAdd.Key < currentNode.Key)
            {
                if (currentNode.Left == null)
                {
                    currentNode.Left = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, currentNode.Left);

            }
            else if (nodeToAdd.Key > currentNode.Key)
            {
                if (currentNode.Right == null)
                {
                    currentNode.Right = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, currentNode.Right);
            }

            return false;
        }

        public bool AddNode(int key, Node currentNode = null)
        {
            Node newNode = new Node(key);
            return AddNode(newNode, currentNode);
        }

        public void DisplayTree()
        {
            DisplayTree(Root);
        }

        public void DisplayTree(Node currentNode)
        {
            // recursively writes out the left subtree until leafs are hit
            // then writes the active node, and finally writes the right subtree until no nodes remain
            // ultimately the result is an ordered list of the keys

            //Console.WriteLine( currentNode == null ? "currentNode is null" : "currentNode is not null");

            if (currentNode != null)
            {
                DisplayTree(currentNode.Left);
                System.Console.Write(currentNode + " ");
                DisplayTree(currentNode.Right);
            }
        }

        public List<Node> GetPriorityNodes(Node currentNode)
        {
            List<Node> results = new List<Node>();
            if (currentNode != null)
            {
                results.AddRange(GetPriorityNodes(currentNode.Left));
                results.Add(currentNode);
                results.AddRange(GetPriorityNodes(currentNode.Right));
            }
            return results;

        }

    }
}
