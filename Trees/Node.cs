
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Node
    {
        public int key { get; set; }
        public Object value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int key = 0, Object value = null)
        {
            this.key = key;
            this.value = value;
            this.left = null;
            this.right = null;
        }

        public override string ToString()
        {
            return key.ToString();
        }
    }
}
