using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.DataStructures
{
    internal class BinaryTree
    {
        public Node Root { get; set; }
        public string TreeAsString { get; set; }
        public int Counter { get; set; }
        public Node MostWordNode { get; set; }
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
                //else if (string.Compare(val, next.Data) == 0)
                //{
                //    before.Count++;
                //}
                else
                {
                    before.Count++;
                    // If the value already exists
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
        public string TraversePreOrder()
        {
            TreeAsString = "";
            TraversePreOrder(this.Root);
            return TreeAsString;
        }

        public string TraverseInOrder()
        {
            TreeAsString = "";
            TraverseInOrder(this.Root);
            return TreeAsString;
        }

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

        public string GetHighestCountOfWord(out int count)
        {
            Counter = 1;
            GetHighestCountOfWord(this.Root);
            count = MostWordNode.Count;
            return MostWordNode.Data;
        }

        // Recursive method of finding the highest count of a node
        private void GetHighestCountOfWord(Node parent)
        {
            if(parent != null)
            {
                if(parent.Count >= Counter)
                {
                    Counter = parent.Count;
                    MostWordNode = parent;
                }
                GetHighestCountOfWord(parent.Left);
                GetHighestCountOfWord(parent.Right);
            }
        }

        private void TraverseInOrder(Node parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.Left);
                TreeAsString += parent.Data + "(" + parent.Count + ")" + " ";
                TraverseInOrder(parent.Right);
            }
        }

        private void TraversePreOrder(Node parent)
        {
            if (parent != null)
            {
                TreeAsString += parent.Data + "(" + parent.Count + ")" + " ";
                TraversePreOrder(parent.Left);
                TraversePreOrder(parent.Right);
            }
        }
    }
}
