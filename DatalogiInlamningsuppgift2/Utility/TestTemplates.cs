using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatalogiInlamningsuppgift2.Utility
{
    internal class TestTemplates
    {
        // For testing purposes only. O(n*n)
        internal void TwoForLoops(string input, string[][] documents)
        {
            // testing for in for O(n*n) Speed
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            int counter = 0;
            bool found = false;
            for (int i = 0; i < documents.Length; i++)
            {
                for (int j = 0; j < documents[i].Length; j++)
                {
                    if (documents[i][j] == input)
                    {
                        counter++;
                        found = true;
                    }
                }
            }

            stopwatch.Stop();
            Console.WriteLine("\nFor loop counter = " + counter);
            Console.WriteLine("Found word in " + stopwatch.Elapsed + "\n");
        }
    }
}
