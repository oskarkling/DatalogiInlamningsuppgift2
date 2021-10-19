using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using DatalogiInlamningsuppgift2.Utility;
using DatalogiInlamningsuppgift2.DataStructures;

namespace DatalogiInlamningsuppgift2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Core core = new Core();

            //https://www.geeksforgeeks.org/how-to-handle-duplicates-in-binary-search-tree/

            BinaryTree bintree = new BinaryTree();

            bintree.Add("b");
            bintree.Add("x");
            bintree.Add("y");
            bintree.Add("a");
            bintree.Add("e");
            bintree.Add("p");
            bintree.Add("d");
            bintree.Add("l");
            bintree.Add("y");
            bintree.Add("a");
            bintree.Add("p");
            bintree.Add("d");
            bintree.Add("l");
            bintree.Add("y");
            bintree.Add("a");
            bintree.Add("a");
            bintree.Add("p");
            bintree.Add("d");
            bintree.Add("l");
            bintree.Add("y");
            bintree.Add("a");

            Console.WriteLine(bintree.TraversePreOrder() + "in tree as is");
            Console.WriteLine(bintree.TraverseInOrder() + "in tree as in order");

            Console.WriteLine(bintree.Root.Data);

            int count;
            string s = bintree.GetHighestCountOfWord(out count);

            Console.WriteLine("HIGHEST :" + s + " number of times " + count);



            // TODO
            // 1. Sortera array i bokstavsordning.
            // 2. Lägg in array i bintree.
            // arr / 2 = middle
            // next = middle - 2;
            // next = middle + 2;
            // next = middle - 1;
            // next = middle +1;
            // next = middle + 4;
            // next = middle - 4;
            // next = middle + 3;
            // nest = middle - 3;

            // 3. Fixa så man kan söka på ord med kmp algo ?


        }
    }
}
