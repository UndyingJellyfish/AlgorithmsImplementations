
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Node
    {
        private int key { get; set; }
        private Object value { get; set; }
        private Node parent { get; set; }
        private Node left { get; set; }
        private Node right { get; set; }
        private List<Node> children { get; set; }

    }
}
