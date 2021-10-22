using DatalogiInlamningsuppgift2.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.Utility
{
    internal static class Utils
    {
        // Reads a .txt file and saves the data in a string[] array.
        // Any failure of doing so results in an error message.
        internal static bool ReadTxtFile(string filepath, out string[] allLinesArr, out string errormsg)
        {
            errormsg = "";
            allLinesArr = null;
            try
            {
                string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + filepath;
                allLinesArr = File.ReadAllLines(projectDirectory);
                return true;
            }
            catch(Exception ex)
            {
                errormsg = "Failed to load txt file from " + filepath + "\n" + ex.Message;
                return false;
            }
        }

        // This method removes unvalid characters and splits the argument string[] into an string[] arr where each word is their own element.
        internal static bool TxtToArr(string filePath, out string[] arrToSend, out string errormsg)
        {
            arrToSend = null;
            string[] doc1;
            if (Utils.ReadTxtFile(filePath, out doc1, out errormsg))
            {
                string[] charsToRemove = new string[] { "@", ",", ".", ";", "/" };
                foreach (var c in charsToRemove)
                {
                    doc1[0] = doc1[0].Replace(c, string.Empty);
                }

                arrToSend = doc1[0].Split(' ');

                return true;
            }
            else
            {
                return false;
            }
        }

        // Initializes a generic array - makes so the declared and initialzed array does not cointain null objects. But new objects of said type.
        // https://stackoverflow.com/questions/3301678/how-to-declare-an-array-of-objects-in-c-sharp
        internal static T[] InitializeArray<T>(int length) where T : new()
        {
            T[] array = new T[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new T();
            }

            return array;
        }

        // Sorts arrays of arguments in alphabetical order.
        // Then returns a 2d array of sorted arrays.
        internal static string[][] SortArrays(string[] doc1Arr, string[] doc2Arr, string[] doc3Arr)
        {
            // HEAP sort O(n log n)
            Array.Sort(doc1Arr);
            Array.Sort(doc2Arr);
            Array.Sort(doc3Arr);
            return new string[][] { doc1Arr, doc2Arr, doc3Arr };
        }

        // Inserts a sorted array into a binary tree. But inserts in a sorted order so the result is a sorted binary tree with as low height as possible.
        // Algorithm below - results in a sorted binary tree for quick binary searches.
        // Then returns an array of sorted binary trees.
        internal static BinaryTree[] InsertIntoBinaryTree(string[][] documents)
        {
            BinaryTree[] bintrees = InitializeArray<BinaryTree>(documents.Length);

            // Iteration for each documents
            for (int i = 0; i < documents.Length; i++)
            {
                string root;
                int nextLeftEven = -2;
                int nextLeftOdd = -1;
                int CounterWeight = 2;
                int nextRightEven = 2;
                int nextRightOdd = 1;
                int middle;
                bool useEvenLeft = true;
                bool useEvenRight = true;
                bool insertLeftTree = true;

                root = documents[i][documents[i].Length / 2];
                middle = documents[i].Length / 2;
                bintrees[i].Add(root);

                // Iteration for each documentH
                for (int j = 0; j < documents[i].Length; j++)
                {
                    
                    if(insertLeftTree)
                    {
                        if (useEvenLeft)
                        {
                            bintrees[i].Add(documents[i][middle + nextLeftEven]);
                            nextLeftEven = nextLeftEven - CounterWeight;
                            useEvenLeft = false;
                        }
                        else
                        {
                            bintrees[i].Add(documents[i][middle + nextLeftOdd]);
                            nextLeftOdd = nextLeftOdd - CounterWeight;
                            useEvenLeft = true;
                        }

                        insertLeftTree = false;
                    }
                    else
                    {
                        if (useEvenRight)
                        {
                            if (middle + nextRightEven != documents[i].Length)
                            {
                                bintrees[i].Add(documents[i][middle + nextRightEven]);
                                nextRightEven = nextRightEven + CounterWeight;
                            }

                            useEvenRight = false;
                        }
                        else
                        {
                            bintrees[i].Add(documents[i][middle + nextRightOdd]);
                            nextRightOdd = nextRightOdd + CounterWeight;
                            useEvenRight = true;
                        }

                        insertLeftTree = true;
                    }
                }
            }
            return bintrees;
        }

        // Creates new sorted .txt files in the Textfiles folder
        // Overwrites existing files.
        internal static bool WriteToFiles(string[][] documents)
        {
            string filepath1= @"\Textfiles\text1000sorted.txt";
            string filepath2 = @"\Textfiles\text1500sorted.txt";
            string filepath3 = @"\Textfiles\text3000sorted.txt";
            string[] filepaths = new string[3] { filepath1, filepath2, filepath3 };

            int successfulWrites = 0;

            for(int i = 0; i < documents.Length; i++)
            {
                try
                {
                    string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + filepaths[i];
                    File.WriteAllLines(projectDirectory, documents[i]);
                    successfulWrites++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }

            if(successfulWrites > 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
