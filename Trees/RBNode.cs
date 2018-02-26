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

    class RBNode
    {
        public int key { get; set; }
        public Object value { get; set; }
        public Color color { get; set; }
        public RBNode left { get; set; }
        public RBNode right { get; set; }
        public bool isRoot { get; internal set;}

        public RBNode(int key = 0, Object value = null)
        {
            this.key = key;
            this.value = value;
            this.left = null;
            this.right = null;
            this.color = Color.Black;
            this.isRoot = false;
        }

        public override string ToString()
        {
            return key.ToString();
        }

        public string ToDebugString(bool printToConsole = false)
        {
            string s = String.Format("Key: {0}\tValue: {1}\tColor: {2}\tLeft color: {3}\tRight color: {4}", this.key, this.value, this.color, this.left.color, this.right.color);
            if (printToConsole) Console.WriteLine(s);
            return s;
        }
        protected bool ValidateNode(){
            // 1. Node is either Red or Black
            // 2. Root is always Black
            // 3. Every leaf (NULL) is Black
            // 4. A red note has only black children
            // 5. For each path, all simple paths to a descendant node has the same amount of black nodes
            var colorCorrect = this.color == Trees.Color.Black || this.color == Trees.Color.Red; 
            var rootColorCorrect = this.isRoot ? this.color == Trees.Color.Black : true;
            var childrenColorCorrect = this.color == Trees.Color.Red ? this.left.color == Trees.Color.Black && this.right.color == Trees.Color.Black : true;


            return true;
        }

    }
}
