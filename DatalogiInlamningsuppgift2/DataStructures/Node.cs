using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.DataStructures
{
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