using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class BinarySearchTree
    // https://stackoverflow.com/questions/10366402/binary-search-tree-in-c-sharp-implementation
    {
        public Node root { get; private set; }
        private static int count = 0;

        public BinarySearchTree(Node newRoot = null)
        {
            root = newRoot;
        }

        public bool AddNode(Node nodeToAdd, Node startingNode)
        {
            if (root == null)
            {
                root = nodeToAdd;
                return true;
            }
            else if (nodeToAdd.key < startingNode.key)
            {
                if (startingNode.left == null)
                {
                    startingNode.left = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, startingNode.left);

            }
            else if (nodeToAdd.key > startingNode.key)
            {
                if (startingNode.right == null)
                {
                    startingNode.right = nodeToAdd;
                    return true;
                }
                return AddNode(nodeToAdd, startingNode.right);
            }

            return false;
        }



        public void DisplayTree(Node tempRoot = null)
        {
            //Console.WriteLine( tempRoot == null ? "tempRoot is null" : "tempRoot is not null");

            if (root == null) return;

            DisplayTree(root.left);
            System.Console.Write(root.key + " ");
            DisplayTree(root.right);

        }

    }
}
