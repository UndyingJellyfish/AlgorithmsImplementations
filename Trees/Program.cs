using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree bst = new BinarySearchTree(5);
            bst.AddNode(12);
            bst.AddNode(15);
            bst.AddNode(210);
            bst.AddNode(85);
            bst.AddNode(105);
            bst.AddNode(25);
            bst.AddNode(34);
            bst.AddNode(73);
            bst.AddNode(1997);

            bst.DisplayTree(bst.root);

            List<Node> priorityList = bst.GetPriorityNodes(bst.root);
            Console.WriteLine();
            printList(priorityList);

            Console.ReadLine();

        }

        static void printList<T>(List<T> listToPrint)
        {
            foreach (var item in listToPrint)
            {
                Console.Write(item + " ");
            }
            Console.Write("\n");
        }
    }
}
