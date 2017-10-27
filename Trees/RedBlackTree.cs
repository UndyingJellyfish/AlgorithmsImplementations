using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class RedBlackTree
    {
        public RBNode root { get; private set; }

        public RedBlackTree(int key = 0, RBNode newRoot = null)
        {
            if (newRoot == null)
            {
                newRoot = new RBNode();
            }
            this.root = newRoot;
            root.key = key;
            
        }




        public void DisplayTree()
        {
            DisplayTree(root);
        }

        public void DisplayTree(RBNode currentNode)
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
    }
}
