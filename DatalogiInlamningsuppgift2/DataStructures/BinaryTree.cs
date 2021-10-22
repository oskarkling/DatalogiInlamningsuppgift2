using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.DataStructures
{
    // This class is a template for a string binary tree.
    internal class BinaryTree
    {
        public Node Root { get; set; }
        public Node NodeToFind { get; set; }

        // Adds a value to the binary tree, thus creating a Node
        public bool Add(string val)
        {
            Node before = null;
            Node next = this.Root;

            while (next != null)
            {
                before = next;
                // Checks if the new node is in the left of the tree
                if (string.Compare(val, next.Data) < 0)
                {
                    next = next.Left;
                }
                // Checks if the new node is in the right of the tree
                else if (string.Compare(val, next.Data) > 0)
                {
                    next = next.Right;
                }
                else
                {
                    // If the string already exists
                    before.Count++;
                    return false;
                }
            }

            Node newNode = new Node();
            newNode.Data = val;

            // Checks if the tree is empty
            if (this.Root == null)
            {
                this.Root = newNode;
            }
            else
            {
                if (string.Compare(val, before.Data) < 0)
                {
                    before.Left = newNode;
                }
                else
                {
                    before.Right = newNode;
                }
            }

            return true;
        }

        // Finds a node with Node.Data same as string input
        // Calls recurse overloaded method FindNode to retrieve this node.
        // Also returns int count as how many times this word was added into the binary tree.
        public bool FindNode(out int count, string input)
        {
            count = 0;

            NodeToFind = FindNode(this.Root, input);

            if(NodeToFind.Data == input)
            {
                count = NodeToFind.Count;
                return true;
            }
            else
            {
                return false;
            }
        }

        // Recursive method. Returns the node with node.data == string input.
        // else it returns the node.data as null.
        private Node FindNode(Node node, string input)
        {
            if (node == null)
            {
                return new Node();
            }
            else if (input.CompareTo(node.Data) < 0)
            {
                return FindNode(node.Left, input);
            }
            else if (input.CompareTo(node.Data) > 0)
            {
                return FindNode(node.Right, input);
            }

            return node;
        }
    }
}
