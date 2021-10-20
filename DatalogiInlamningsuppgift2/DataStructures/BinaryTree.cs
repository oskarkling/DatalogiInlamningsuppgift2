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

        //_____________________________________________________________________________________________________________________
        //public Node Find(long val)
        //{
        //    return this.Find(val, this.Root);
        //}

        //public void Remove(long val)
        //{
        //    this.Root = Remove(this.Root, val);
        //}


        // Gets the max value in the binary tree
        //public long MaxVal()
        //{
        //    long maxVal = this.Root.Data;
        //    Node newNode = this.Root;

        //    while(newNode.Right != null)
        //    {
        //        maxVal = newNode.Right.Data;
        //        newNode = newNode.Right;
        //    }

        //    return maxVal;
        //}

        // Recursive Remove method
        //private Node Remove(Node parent, long val)
        //{
        //    if(parent == null)
        //    {
        //        return parent;
        //    }

        //    if(val < parent.Data)
        //    {
        //        parent.Left = Remove(parent.Left, val);
        //    }
        //    else if(val > parent.Data)
        //    {
        //        parent.Right = Remove(parent.Right, val);
        //    }

        //    // If value is the same as parent.Data. This is the node to be deleted.
        //    else
        //    {
        //        // Node only haas one child or no children
        //        if (parent.Left == null)
        //        {
        //            return parent.Right;
        //        }
        //        else if (parent.Right == null)
        //        {
        //            return parent.Left;
        //        }

        //        parent.Data = MinVal(parent.Right);

        //        parent.Right = Remove(parent.Right, parent.Data);
        //    }

        //    return parent;
        //}

        // Gets the node with the smallest value
        //private long MinVal(Node node)
        //{
        //    long minVal = node.Data;
        //    while(node.Left != null)
        //    {
        //        minVal = node.Left.Data;
        //        node = node.Left;
        //    }

        //    return minVal;
        //}

        // Recursive method of finding the node with the Value
        // If no node is found, return null
        //private Node Find(long val, Node parent)
        //{
        //    if(parent != null)
        //    {
        //        if(val == parent.Data)
        //        {
        //            return parent;
        //        }

        //        if(val < parent.Data)
        //        {
        //            return Find(val, parent.Left);
        //        }
        //        else
        //        {
        //            return Find(val, parent.Right);
        //        }
        //    }

        //    return null;
        //}
    }
}
