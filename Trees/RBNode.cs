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

        public RBNode(int key = 0, Object value = null)
        {
            this.key = key;
            this.value = value;
            this.left = null;
            this.right = null;
            this.color = Color.Black;
        }

        public override string ToString()
        {
            return key.ToString();
        }

        public string ToDebugString(bool printToConsole = false)
        {
            string s = String.Format("Key: {0}\tValue: {1}", this.key, this.value);
            if (printToConsole) Console.WriteLine(s);
            return s;
        }

    }
}
