namespace DamsboSoftware.AlgorithmImplementations.Trees
{
    public class RedBlackTree
    {
        private RbNode Root { get; set; }

        public RedBlackTree(){
            this.Root = new RbNode {IsRoot = true};
        }
        public RedBlackTree(int key = 0, RbNode newRoot = null)
        {
            if (newRoot == null)
            {
                newRoot = new RbNode();
            }
            this.Root = newRoot;
            Root.Key = key;
        }



        public void DisplayTree()
        {
            DisplayTree(Root);
        }

        public void DisplayTree(RbNode currentNode)
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

        public bool ValidateTree(){
            return ValidateTree(Root);
        }
        public bool ValidateTree(RbNode currentNode){
            if (currentNode == null) return true;
            return ValidateTree(this.Root.Left) && this.Root.ValidateNode() && ValidateTree(this.Root.Right);
        }
         
    }
}
