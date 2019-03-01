using System;

namespace DamsboSoftware.AlgorithmImplementations.Trees
{
    public class RedBlackTree
    {
        protected Guid Id;
        private RbNode Root { get; set; }
        
        public RedBlackTree(int key = 0, RbNode newRoot = null)
        {
            Id = Guid.NewGuid();
            if (newRoot == null)
            {
                newRoot = new RbNode
                {
                    IsRoot = true
                };
            }
            this.Root = newRoot;
            Root.Key = key;
        }

        public void DisplayTree(TraversalOrder order)
        {
            Console.WriteLine(PrettyStringTree(order));
        }

        public void DisplayTree(RbNode node, TraversalOrder order)
        {
            Console.WriteLine(PrettyStringTree(node, order));
        }

        public string PrettyStringTree(TraversalOrder order)
        {
            return PrettyStringTree(Root, order);
        }

        public string PrettyStringTree(RbNode node, TraversalOrder order)
        {
            string output;
            switch (order)
            {
                case TraversalOrder.PreOrder:
                    output = PrettyStringTreePreOrder(Root);
                    break;
                case TraversalOrder.InOrder:
                    output = PrettyStringTreeInOrder(Root);
                    break;
                case TraversalOrder.OutOrder:
                    output = PrettyStringTreeOutOrder(Root);
                    break;
                case TraversalOrder.PostOrder:
                    output = PrettyStringTreePostOrder(Root);
                    break;
                default:
                    throw new ArgumentException($"Could not get pretty string for tree with Id={Id} because traversal order had unexpected value.");
            }

            return output;
        }

        public string PrettyStringTreePreOrder(RbNode currentNode)
        {
            var output = "";
            if (currentNode == null) return "";
            output += currentNode.ToPrettyString() + "\n";
            output += PrettyStringTreePreOrder(currentNode.Left);
            output += PrettyStringTreePreOrder(currentNode.Right);
            return output;
        }

        public string PrettyStringTreeInOrder(RbNode currentNode)
        {
            var output = "";
            if (currentNode == null) return "";
            output += PrettyStringTreeInOrder(currentNode.Left);
            output += currentNode.ToPrettyString() + "\n";
            output += PrettyStringTreeInOrder(currentNode.Right);
            return output;
        }

        public string PrettyStringTreeOutOrder(RbNode currentNode)
        {
            var output = "";
            if (currentNode == null) return "";
            output += PrettyStringTreeOutOrder(currentNode.Right);
            output += currentNode.ToPrettyString() + "\n";
            output += PrettyStringTreeOutOrder(currentNode.Left);
            return output;
        }

        public string PrettyStringTreePostOrder(RbNode currentNode)
        {
            var output = "";
            if (currentNode == null) return "";
            output += PrettyStringTreePostOrder(currentNode.Left);
            output += PrettyStringTreePostOrder(currentNode.Right);
            output += currentNode.ToPrettyString() + "\n";
            return output;
        }

        public bool ValidateTree()
        {
            return ValidateTree(Root);
        }
        public bool ValidateTree(RbNode currentNode)
        {
            if (currentNode == null) return true;
            return ValidateTree(this.Root.Left) && this.Root.ValidateNode() && ValidateTree(this.Root.Right);
        }

    }
}
