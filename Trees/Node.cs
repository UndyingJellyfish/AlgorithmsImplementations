
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Node
    {
        public int Key { get; set; }
        public Object Value { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int key = 0, Object value = null)
        {
            this.Key = key;
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}
