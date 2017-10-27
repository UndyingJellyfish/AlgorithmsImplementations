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
        public Node root { get; private set; }

        public BinarySearchTree(int key = 0, Node newRoot = null)
        {
            if (newRoot == null)
            {
                newRoot = new Node();
            }
            newRoot.key = key;
            this.root = newRoot;
        }

        public bool AddNode(Node nodeToAdd, Node currentNode = null)
        {
            if (currentNode == null)
            {
                currentNode = root;
            }
            if (root == null)
            {
                root = nodeToAdd;
                return true;
            }
            else if (nodeToAdd.key < currentNode.key)
            {
                if (currentNode.left == null)
                {
                    currentNode.left = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, currentNode.left);

            }
            else if (nodeToAdd.key > currentNode.key)
            {
                if (currentNode.right == null)
                {
                    currentNode.right = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, currentNode.right);
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
            DisplayTree(root);
        }

        public void DisplayTree(Node currentNode)
        {
            // recursively writes out the left subtree until leafs are hit
            // then writes the active node, and finally writes the right subtree until no nodes remain
            // ultimately the result is an ordered list of the keys

            //Console.WriteLine( currentNode == null ? "currentNode is null" : "currentNode is not null");

            if (currentNode != null)
            {
                DisplayTree(currentNode.left);
                System.Console.Write(currentNode + " ");
                DisplayTree(currentNode.right);
            }
        }

        public List<Node> GetPriorityNodes(Node currentNode)
        {
            List<Node> results = new List<Node>();
            if (currentNode != null)
            {
                results.AddRange(GetPriorityNodes(currentNode.left));
                results.Add(currentNode);
                results.AddRange(GetPriorityNodes(currentNode.right));
            }
            return results;

        }

    }
}
