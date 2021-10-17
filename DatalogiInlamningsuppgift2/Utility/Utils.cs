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
    }
}
