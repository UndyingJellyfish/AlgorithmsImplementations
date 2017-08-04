
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
        private Node parent { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        private List<Node> children { get; set; }

    }
}
