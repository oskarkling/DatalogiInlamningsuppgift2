using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.DataStructures
{
    // This class is a template for a Node which contains string data and int count.
    // Count is for how many times this string.data gets added into the binary tree.
    internal class Node
    {
        public Node Left { get; set; }
        public Node Right { get; set; }
        public string Data { get; set; }
        public int Count { get; set; }

        internal Node()
        {
            Count = 1;
        }
    }
}