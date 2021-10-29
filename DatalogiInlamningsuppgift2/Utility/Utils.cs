﻿using DatalogiInlamningsuppgift2.DataStructures;
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
            // Quick sort?



            Array.Sort(doc1Arr);
            Array.Sort(doc2Arr);
            Array.Sort(doc3Arr);
            return new string[][] { doc1Arr, doc2Arr, doc3Arr };
        }

        // Inserts a sorted array into a binary tree. But inserts in a sorted order so the result is a sorted binary tree with as low height as possible.
        // Algorithm below - results in a sorted binary tree for quick binary searches.
        // Then returns an array of sorted binary trees.

        // = N^2 + N^3
        // ordo O(N+N^2) 
       
        internal static BinaryTree[] InsertIntoBinaryTree(string[][] documents)
        {
            BinaryTree[] bintrees = InitializeArray<BinaryTree>(documents.Length);
            
            string root;
            int nextLeftEven;
            int nextLeftOdd;
            int CounterWeight;
            int nextRightEven;
            int nextRightOdd;
            int middle;
            bool useEvenLeft;
            bool useEvenRight;
            bool insertLeftTree;

            // Iteration for each documents
            for (int i = 0; i < documents.Length; i++)
            {
                nextLeftEven = -2;
                nextLeftOdd = -1;
                CounterWeight = 2;
                nextRightEven = 2;
                nextRightOdd = 1;
                useEvenLeft = true;
                useEvenRight = true;
                insertLeftTree = true;
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

        public static double[] StringToValue(string[] array)
        {
            double[] numArray = new double[array.Length];
            double value = 0;
            double total = 0;

            for (int i = 0; i < array.Length; i++)
            {
                char[] chars = array[i].ToCharArray();

                for (int c = 0; c < chars.Length; c++)
                {
                    if (chars[c] == 'A' || chars[c] == 'a') { value = 1; }
                    else if (chars[c] == 'B' || chars[c] == 'b') { value = 2; }
                    else if (chars[c] == 'C' || chars[c] == 'c') { value = 3; }
                    else if (chars[c] == 'D' || chars[c] == 'd') { value = 4; }
                    else if (chars[c] == 'E' || chars[c] == 'e') { value = 5; }
                    else if (chars[c] == 'F' || chars[c] == 'f') { value = 6; }
                    else if (chars[c] == 'G' || chars[c] == 'g') { value = 7; }
                    else if (chars[c] == 'H' || chars[c] == 'h') { value = 8; }
                    else if (chars[c] == 'I' || chars[c] == 'i') { value = 9; }
                    else if (chars[c] == 'J' || chars[c] == 'j') { value = 10; }
                    else if (chars[c] == 'K' || chars[c] == 'k') { value = 11; }
                    else if (chars[c] == 'L' || chars[c] == 'l') { value = 12; }
                    else if (chars[c] == 'M' || chars[c] == 'm') { value = 13; }
                    else if (chars[c] == 'N' || chars[c] == 'n') { value = 14; }
                    else if (chars[c] == 'O' || chars[c] == 'o') { value = 15; }
                    else if (chars[c] == 'P' || chars[c] == 'p') { value = 16; }
                    else if (chars[c] == 'Q' || chars[c] == 'q') { value = 17; }
                    else if (chars[c] == 'R' || chars[c] == 'r') { value = 18; }
                    else if (chars[c] == 'S' || chars[c] == 's') { value = 19; }
                    else if (chars[c] == 'T' || chars[c] == 't') { value = 20; }
                    else if (chars[c] == 'U' || chars[c] == 'u') { value = 21; }
                    else if (chars[c] == 'V' || chars[c] == 'v') { value = 22; }
                    else if (chars[c] == 'X' || chars[c] == 'x') { value = 23; }
                    else if (chars[c] == 'Y' || chars[c] == 'y') { value = 24; }
                    else if (chars[c] == 'Z' || chars[c] == 'z') { value = 25; }
                    else { value = 0; }

                    if (c > 0)
                    {
                        value *= Math.Pow(10, -c);
                    }
                    total += value;
                }
                numArray[i] = total;
            }
            return numArray;
        }
    }
}
