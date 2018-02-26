using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    enum Color
    {
        Red,
        Black
    }
    enum RotationDirection
    {
        Left,
        Right
    }
    public class RedBlackTree
    {
        private RBNode root { get; set; }
        internal RBNode Root => root;

        public RedBlackTree(){
            this.root = new RBNode();
            this.root.isRoot = true;
        }
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

        public bool ValidateTree(){
            return ValidateTree(root);
        }
        public bool ValidateTree(RBNode currentNode){
            if (currentNode == null) return true;
            return ValidateTree(this.root.left) && this.root.ValidateNode() && ValidateTree(this.root.right);
        }
         
    }
}
