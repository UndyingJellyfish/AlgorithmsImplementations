using System;

namespace DamsboSoftware.AlgorithmImplementations.Trees
{
    public class RbNode
    {
        public int Key { get; set; }
        public Object Value { get; set; }
        public TreeColor Color { get; set; }
        public RbNode Left { get; set; }
        public RbNode Right { get; set; }
        public bool IsRoot { get; internal set;}

        public RbNode(int key = 0, Object value = null)
        {
            this.Key = key;
            this.Value = value;
            this.Left = null;
            this.Right = null;
            this.Color = TreeColor.Black;
            this.IsRoot = false;
        }

        public override string ToString()
        {
            return Key.ToString();
        }

        public string ToPrettyString()
        {
            return $"Key: {this.Key}\tValue: {this.Value}\tColor: {this.Color}";
        }

        public string ToDebugString(bool printToConsole = false)
        {
            string s =
                $"Key: {this.Key}\tValue: {this.Value}\tColor: {this.Color}\tLeft color: {this.Left.Color}\tRight color: {this.Right.Color}";
            if (printToConsole) Console.WriteLine(s);
            return s;
        }
        public bool ValidateNode(){
            // 1. Node is either Red or Black (always true when using enum)
            // 2. Root is always Black
            // 3. Every leaf (NULL) is Black ()
            // 4. A red note has only black children
            // 5. For each path, all simple paths to a descendant node has the same amount of black nodes (can't be checked from the node itself)
            var rootColorCorrect = this.IsRoot ? this.Color == Trees.TreeColor.Black : true;
            var childrenColorCorrect = this.Color == Trees.TreeColor.Red ? this.Left.Color == Trees.TreeColor.Black && this.Right.Color == Trees.TreeColor.Black : true;

            return rootColorCorrect && childrenColorCorrect;
        }

    }
}
